using UnityEngine.UI;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    /* 
    Random phone script mixed with my personal project's SoundManager script used to roll between Audio Sources
    and assign them sounds and play them at runtime just by checking which one is available. Saves a lot of headaches.
    */
    [SerializeField] float flashCooldown;
    [SerializeField] Vector2 phoneBeepCooldownRange; // x is maximum/starting value, y is minimum/jumpscare value
    [SerializeField] float phoneBeepReductionSpeed;
    float currentPhoneBeepCooldown;
    float currentBeepTimer;

    public bool isFlashReady {get{return !FlashBeaconAudio.isPlaying;}}

    [SerializeField] GameObject VoltergeistObject;
    PlayerMovement playerScript;

    
    [Header("Sounds")]
    [SerializeField] AudioClip FlashBeaconClip;
    // The FlashBeaconAudioSource is unique because it will cut itself mid-playing voluntarily so it will be handled separately
    AudioSource FlashBeaconAudio;

    // Use an enum so that I am CERTAIN that the names are well written and there's no uPpErCasE problem
    public enum ValidSounds{PhoneBeep, FlashReloadFinished}
    [SerializeField] AudioClipsDictionary_ScriptableObject AudioClipsDictionary;
    AudioSource audioSource1, audioSource2, audioSource3, audioSource4;
    AudioSource _currentSource;

    // =============== [DEFAULT UNITY METHODS] =================

    void Awake()
    {
        // Referencing the audio sources
        var sources = GetComponents<AudioSource>();

        audioSource1 = sources[0];
        audioSource2 = sources[1];
        audioSource3 = sources[2];
        audioSource4 = sources[3];

        // Create the special FlashBeaconAudio component
        FlashBeaconAudio = gameObject.AddComponent<AudioSource>();
        FlashBeaconAudio.clip = FlashBeaconClip;
        FlashBeaconAudio.playOnAwake = false;
        FlashBeaconAudio.loop = false;
        FlashBeaconAudio.volume = .7f;

        // Referencing the player
        playerScript = transform.root.GetComponent<PlayerMovement>();
    }

    void Start()
    {
        // Set at maximum at the start
        currentPhoneBeepCooldown = phoneBeepCooldownRange.x;

        GameManager.PlayerKilled += PlayerKilled;
    }

    void Update()
    {
        // If the voltergeist is active, play the BEEPS
        if (GameManager.VoltergeistSpawned)
        {
            // decrease the current timer
            currentBeepTimer -= Time.deltaTime;

            // Play the sound
            if (currentBeepTimer <= 0)
            {
                // Decrease the Cooldown between each beep
                DecreaseBeepCooldown();

                // Play the sound and reset the timer to the new cooldown
                PlayPhoneBeep();
            }
        }


        // If I'm playing the flash beacon reload
        if (FlashBeaconAudio.isPlaying)
        {
            // If the cooldown is finished
            if (FlashBeaconAudio.time > flashCooldown)
            {
                // Stop playing this sound
                FlashBeaconAudio.Stop();

                // Play the "Reloaded" sound
                PlaySoundWithName(ValidSounds.FlashReloadFinished);
            }
        }
    }

    // ================ [GENERAL AUDIO METHODS] ====================

    void PlaySoundWithName(ValidSounds soundName)
    {
        // Reference the name of the sound
        string _name = soundName.ToString();

        // Assign the right Audio Source
        // Use a pre-created _currentSource Variable to avoid creating one each time we play a sound
        if (!audioSource1.isPlaying)
        {
            _currentSource = audioSource1;
        }
        else if (!audioSource2.isPlaying)
        {
            _currentSource = audioSource2;
        }
        else if (!audioSource3.isPlaying)
        {
            _currentSource = audioSource3;
        }
        else if (!audioSource4.isPlaying)
        {
            _currentSource = audioSource4;
        }
        else
        {
            // Debug to know I need to increase the number of sources
            Debug.LogWarning("Trying to play sound " + _name + " but every Audio Source is already taken!\n Source1 taken by " + audioSource1.clip.name + ".\n Source2 taken by " + audioSource2.clip.name + ".\n Source3 taken by " + audioSource3.clip.name + ".\n Source4 taken by " + audioSource4.clip.name);
        }

        _currentSource.clip = AudioClipsDictionary.GetAudioClipFromName(_name);
        _currentSource.volume = AudioClipsDictionary.GetVolumeFromName(_name);
        _currentSource.pitch = AudioClipsDictionary.GetPitchFromName(_name);

        _currentSource.Play();
    }

    // ============= [SPECIFIC SOUNDS PLAY] ================

    public void PlayFlashSound()
    {
        FlashBeaconAudio.Play();
    }

    void PlayPhoneBeep()
    {
        // Play the sound
        PlaySoundWithName(ValidSounds.PhoneBeep);

        // Reset the timer
        currentBeepTimer = currentPhoneBeepCooldown;
    }

    // =============== [GENERAL PHONE METHODS] ==================

    public void RejectCall()
    {
        // Put the value at its maximum
        currentPhoneBeepCooldown = phoneBeepCooldownRange.x;
        currentBeepTimer = currentPhoneBeepCooldown;
    }

    void DecreaseBeepCooldown()
    {
        if (!GameManager.PlayerDead)
        {
            // Reduce by the Speed (in seconds removed per second) + or - 50% each frame
            // Increase the difficulty as the player reaches the end (0 to 30% of a fraction of the percentage of the distance travelled)
            // And slightly reduce the reduction speed when getting close to the end of the spectum
            currentPhoneBeepCooldown -= phoneBeepReductionSpeed + ((Random.value - .5f) * phoneBeepReductionSpeed) + ((Random.value * .5f) * (transform.position.x / GameManager.EndCoordinateValue * .2f)) - (Random.value * .05f / currentPhoneBeepCooldown);
            currentPhoneBeepCooldown = Mathf.Clamp(currentPhoneBeepCooldown, phoneBeepCooldownRange.y, phoneBeepCooldownRange.x);

            if (currentPhoneBeepCooldown == phoneBeepCooldownRange.y)
            {
                VoltergeistKill();
            }
        }
    }

    public void VoltergeistKill()
    {
        Debug.LogError("VOLTERGEIST KILLED YOU");

        VoltergeistObject.transform.position = transform.position + Vector3.forward * 2;

        GameManager.KillPlayer();
    }

    void PlayerKilled()
    {
        currentBeepTimer = Mathf.Infinity;
    }


    // =========== [OTHER] ============
    void OnDestroy()
    {
        GameManager.PlayerKilled -= PlayerKilled;
    }
}
