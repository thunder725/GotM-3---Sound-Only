using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControllersInputs inputs;
    float movementInputs;
    Vector3 _newPosition = Vector3.zero;

    [Header("Values")]
    [SerializeField] float movementSpeed;
    [SerializeField] float cameraHeightMultiplicator, cameraWalkSpeed;
    [SerializeField] float fogReappearanceSpeed, turnaroundSpeed;
    [SerializeField] float followerFlashRange, followerPushDistance, forwardFlashRange;
    bool isTurningAround, isLookingForward;

    [Header("Phone-Related")]
    [SerializeField] PhoneScript _phone;
    [SerializeField] Vector3 phoneVisiblePosition;
    [SerializeField] float phoneMovementSpeed;
    [SerializeField] bool isPhoneUp;

    bool ResetFogDensity, isPhoneVisible; // PhoneVisible = either up or moving (up or down)

    // A nice value is 0.037 if wanted
    float defaultFogDensity;

    // 1 for up, -1 for down
    float phoneDirection;


    [Header("Debug Mode")]
    [SerializeField] bool DebugModEnabled;
    

    [Header("References")]
    [SerializeField] GameManager gm;
    [SerializeField] GameObject Phone;
    // Layer Mask for The Follower, The Witness and The Brazen that all react to the flash
    [SerializeField] LayerMask LightSensitiveLayers;
    [SerializeField] The_Eleventh eleventh;

    // ============= [GENERAL UNITY METHODS] ===============
    
    void Awake()
    {
        // Create the inputs
        inputs = new PlayerControllersInputs();
        inputs.Enable();
        inputs.Default.PullUpPhone.started += PullUpPhone_Input;
        inputs.Default.Flash.started += Flash;
        inputs.Default.DisableFog.started += DisableFog;
        inputs.Default.RejectCall.started += RejectCall;
        inputs.Default.AcceptCall.started += AcceptCall;
        inputs.Default.TurnAround.started += TurnAround_Input;
        inputs.Default.SwitchTrack.started += SwitchTrack;
    }

    void Start()
    {
        RenderSettings.fog = true;

        // Set the phone at 0,0,1
        Phone.transform.localPosition = new Vector3(0, 3, 1);

        // Say that the phone is at the bottom, so at -1. It'll get inverted afterwards
        phoneDirection = -1;

        // Reset the boolean variables
        isPhoneUp = isPhoneVisible = isTurningAround = false;
        isLookingForward = true;

        // Get the current fog density value
        defaultFogDensity = RenderSettings.fogDensity;
    }
    
    void Update()
    {
        // Save the inputs in a pre-made variable because it's used every frame so no need to create one every frame
        movementInputs = inputs.Default.Move.ReadValue<float>();

        // Don't even listen to the inputs if the phone is moving
        if (!isPhoneVisible && !GameManager.PlayerDead)
        {
            if (movementInputs > 0)
            {
                if (isLookingForward)
                {
                    // Move Forward
                    MoveForward();
                }
            }
        }
        
        if (ResetFogDensity)
        {
            if (RenderSettings.fogDensity < defaultFogDensity)
            {
                RenderSettings.fogDensity += Time.deltaTime * fogReappearanceSpeed;
            }
            else
            {
                ResetFogDensity = false;
            }
        }

    }

    // ============ [MOVEMENT METHODS] ==============

    void MoveForward()
    {
        // Use the _newPosition vector to compute the next position
        // The z (Forward) is just increasing the current position with a movement speed
        _newPosition.z = transform.position.z + (movementSpeed * Time.deltaTime);
        
        // The y is a Sin so that it starts at 0
        _newPosition.y = Mathf.Sin(_newPosition.z * cameraWalkSpeed) * cameraHeightMultiplicator; 

        transform.position = _newPosition;
    }

    void TurnAround_Input(InputAction.CallbackContext callbackContext)
    {
        if (!isTurningAround && !isPhoneVisible && !GameManager.PlayerDead)
        {
            // Debug.Log("Starting Turn");
            StartCoroutine(TurnAround());
        }
    }

    IEnumerator TurnAround()
    {
        isTurningAround = true;

        // Select which way to turn
        if (transform.eulerAngles.y == 0)
        {
            // While the player is above 0° but under 180°
            // Because the eulerAngles variable sometimes goes from -180 to 180...
            // ...But sometimes it goes from -130 to 230 without any reason so what the hell is going on
            while (transform.eulerAngles.y < 180 && transform.eulerAngles.y >= 0)
            {
                // Rotate each frame
                transform.Rotate(0, turnaroundSpeed * Time.deltaTime, 0);
                yield return new WaitForEndOfFrame();
            }

            // Put a clean value at the end
            transform.rotation = Quaternion.Euler(0, 180, 0);
            
            // Don't allow to move forward
            isLookingForward = false;
        }
        else
        {
            while (transform.eulerAngles.y <= 180 && transform.eulerAngles.y > 0)
            {
                // Rotate each frame
                transform.Rotate(0, -turnaroundSpeed * Time.deltaTime, 0);
                yield return new WaitForEndOfFrame();
            }

            // Put a clean value at the end
            transform.rotation = Quaternion.Euler(0, 0, 0);

            // Allow to move forward
            isLookingForward = true;
        }
        

        isTurningAround = false;
        yield return null;
        StopCoroutine(TurnAround());
    }

    // ========== [PHONE METHODS] ==============

    void PullUpPhone_Input(InputAction.CallbackContext c)
    {
        PullUpPhone();
    }

    void PullUpPhone()
    {
        if (!isTurningAround && !GameManager.PlayerDead)
        {
            // Both pulling up and down the phone

            // Stop coroutines to avoid weird position jittering
            StopAllCoroutines();

            // Turn a 1 to a -1
            phoneDirection = -phoneDirection;

            // Start the movement
            StartCoroutine(PhoneMovementCoroutine());
        }
    }

    void RejectCall(InputAction.CallbackContext c)
    {
        if (isPhoneUp && GameManager.VoltergeistSpawned)
        {
            _phone.RejectCall();

            PullUpPhone();
        }
    }

    void AcceptCall(InputAction.CallbackContext c)
    {
        if (isPhoneUp && GameManager.VoltergeistSpawned)
        {
            PullUpPhone();
            _phone.VoltergeistKill();
        }
    }

    IEnumerator PhoneMovementCoroutine()
    {
        // Create the temporary new position
        Vector3 newPos = Vector3.forward;

        // The phone's LOCAL coordinates are ALWAYS 0, y, 1
        // The height moves from 3 (off camera) and phoneVisiblePosition.x (around 5);

        // If the phone should go up
        if (phoneDirection == 1)
        {
            // Prevent movement
            isPhoneVisible = true;

            // While the phone is not at the top
            while (Phone.transform.localPosition.y != phoneVisiblePosition.y)
            {
                // Offset the localPosition upwards
                newPos = Phone.transform.localPosition + Vector3.up * Time.deltaTime * phoneMovementSpeed;
                
                // Clamp so that the while can finish at some point
                newPos.y = Mathf.Clamp(newPos.y, 3, phoneVisiblePosition.y);
                
                // Set the localPosition
                Phone.transform.localPosition = newPos;

                // Wait for the next frame
                yield return new WaitForEndOfFrame();
            }
            
            // Say the phone is up
            isPhoneUp = true;
        }

        // If the phone should go down
        else
        {
            // Say the phone is down, but still visible
            isPhoneUp = false;

            // While the phone is not at the top
            while (Phone.transform.localPosition.y != 3)
            {
                // Offset the localPosition downwards
                newPos = Phone.transform.localPosition - Vector3.up * Time.deltaTime * phoneMovementSpeed;
                
                // Clamp so that the while can finish at some point
                newPos.y = Mathf.Clamp(newPos.y, 3, phoneVisiblePosition.y);
                
                // Set the localPosition
                Phone.transform.localPosition = newPos;

                // Wait for the next frame
                yield return new WaitForEndOfFrame();
            }

            // The phone is now hidden
            isPhoneVisible = false;
        }

        StopCoroutine(PhoneMovementCoroutine());
        yield return null;

    }

    void Flash(InputAction.CallbackContext c)
    {
        if (isPhoneUp && _phone.isFlashReady)
        {
            // Not entirely 0 so it still looks realistic, somewhat
            RenderSettings.fogDensity = 0.002f;
            ResetFogDensity = true;

            // Pull down the phone to prevent the flash's visibility to be useless
            PullUpPhone();

            // Play the sound
            _phone.PlayFlashSound();

            // If i'm looking back
            if (!isLookingForward)
            {
                // Search for The Follower
                FlashForFollower();
            }
            else
            {
                // Search for The Witness and The Brazen
                FlashForWitnessAndBrazen();
            }
            
        }
    }

    void FlashForFollower()
    {
        // Debug.Log("Searching for The Follower");
        Vector3 fromPos = transform.position + Vector3.up * 3;

        // Check if The Follower is here
        if (Physics.Raycast(fromPos, Vector3.back, out RaycastHit _hit ,followerFlashRange, LightSensitiveLayers))
        {
            // Debug.Log("Hit");
            // Push it back
            _hit.transform.position += Vector3.back * followerPushDistance;
        }
    }

    void FlashForWitnessAndBrazen()
    {
        // Debug.Log("Searching for The Witness and The Brazen");

        Vector3 fromPos = transform.position + Vector3.up * 3;

        // Check if The Witness or The Brazen are here
        if (Physics.Raycast(fromPos, Vector3.forward, out RaycastHit _hit, forwardFlashRange, LightSensitiveLayers))
        {
            // Debug.Log("Hit");
            
            // If I hit The Witness
            if (_hit.transform.gameObject.tag == "The_Witness")
            {
                var _script = _hit.transform.gameObject.GetComponent<The_Witness>();
                _script.Flashed();
            }
            // If I hit The Brazen
            else if (_hit.transform.gameObject.tag == "The_Brazen") 
            {
                var _script = _hit.transform.gameObject.GetComponent<The_Brazen>();
                _script.Flashed();
            }
            // If I hit... something else??
            else
            {
                Debug.LogWarning("Hit an unknown object " + _hit.transform.gameObject.name + ".");
            }
        }
    }

    // ================ [COLLISION & TRIGGER METHODS] ================

    void OnTriggerEnter(Collider trigger)
    {
        // Debug.Log(trigger.gameObject.tag);
        switch (trigger.gameObject.tag)
        {
            case "Thresholds":
            EnteringThreshold(trigger.gameObject.name);
            break;

            case "The_Follower":
            trigger.transform.position = Vector3.up * 500;
            Debug.LogError("THE FOLLOWER KILLED YOU");
            GameManager.KillPlayer();
            break;

            case "The_Witness":
            trigger.gameObject.GetComponent<The_Witness>().Flashed();
            break;

            case "The_Brazen":
            trigger.gameObject.GetComponent<The_Brazen>().KillPlayer();
            break;

            default:
            // Debug.Log("Entered a non-configured trigger: " + trigger.gameObject.name);
            break;
        }
    }

    void EnteringThreshold(string thresholdName)
    {  
        // Debug.Log(thresholdName);

        // There probably is a way to do it with string.Contains or something but I like using switches
        // The monsters spawn at the following thresholds. Then add a threshold for the end of the level

        // The game manager has a way of checking the exact percentage using the end coordinate (and we start at 0)...
        // But this way I can control it VISUALLY which is important for me, so I'll keep using this system
        switch (thresholdName)
        {
            case "Voltergeist":
            // Spawn The Voltergeist
            gm.SpawnVoltergeist();

            break;

            case "Follower":
            // Spawn The Follower
            gm.SpawnFollower();

            break;

            case "Brazen":
            // Spawn The Brazen
            gm.SpawnBrazen();

            break;

            case "Eleventh":
            // Spawn The Eleventh
            gm.SpawnEleventh();

            break;

            case "Witness":
            // Spawn The Witness
            gm.SpawnWitness();

            break;

            case "100%":
            break;
        }
    }

    void SwitchTrack(InputAction.CallbackContext c )
    {
        eleventh.AttackDisarmed();
        PullUpPhone();
    }


    // =============== [OTHER] ================
    void OnDestroy()
    {
        inputs.Disable();
        inputs.Default.PullUpPhone.started -= PullUpPhone_Input;
        inputs.Default.RejectCall.started -= RejectCall;
        inputs.Default.AcceptCall.started -= AcceptCall;
        inputs.Default.Flash.started -= Flash;
        inputs.Default.DisableFog.started -= DisableFog;
        inputs.Default.TurnAround.started -= TurnAround_Input;
        inputs.Default.SwitchTrack.started -= SwitchTrack;
    }

    void DisableFog(InputAction.CallbackContext c)
    {
        if (DebugModEnabled)
        {
            RenderSettings.fog = !RenderSettings.fog;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Vector3.up * 3, transform.position + Vector3.back * followerFlashRange + Vector3.up * 3);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + Vector3.up * 3, transform.position + Vector3.forward * forwardFlashRange + Vector3.up * 3);
    }
}
