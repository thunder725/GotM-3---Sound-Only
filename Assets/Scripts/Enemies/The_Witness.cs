using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Witness : MonoBehaviour
{
    [SerializeField] [Range(0,1)] float spawnPercentage;

    [SerializeField] GameObject possibleSpawningPointsObject, forcedSpawningPointsObject;
    Transform[] possibleSpawningPoints, forcedSpawningPoints;
    [SerializeField] List<Vector3> nextSpawningpoints = new List<Vector3>();
    bool isEnabled;
    int currentPositionIndex;
    GameObject PlayerRef;
    float distanceToPlayer;
    [SerializeField] float disparitionDistanceThreshold = 13.6f, timerBeforeDisparition, DisparitionSpeed;
    float realDisparitionDistanceThreshold, currentTimerBeforeDisparition;

    // ======================== [DEFAULT UNITY METHODS] ========================
    void Awake() // I generally use the awake for references and start for the values
    {
        // Get a reference to the player
        PlayerRef = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Start()
    {
        // Create the arrays from the parent GameObjects. It also contains the parent so I'll start everything from index 1;
        possibleSpawningPoints = possibleSpawningPointsObject.GetComponentsInChildren<Transform>();
        forcedSpawningPoints = forcedSpawningPointsObject.GetComponentsInChildren<Transform>();

        // Compute the square for optimisation
        realDisparitionDistanceThreshold = disparitionDistanceThreshold * disparitionDistanceThreshold;

        // Set the timer for the first one
        ResetTimerValue();
    }

    void Update()
    {
        if (!isEnabled)
        {
            if (GameManager.WitnessSpawned)
            {
                // The frame The Witness spawns in
                isEnabled = true;
                SpawningIn();
            }
        }

        if (!GameManager.PlayerDead)
        {
            // Compute the distance to the player
            // SqrMagniture returns the square of the distance but it's faster, so i'll compare it with the square of the value I actually want
            // Absolutely useless but it's possible so I'll do it
            distanceToPlayer = (PlayerRef.transform.position - transform.position).sqrMagnitude;
            
            if (distanceToPlayer < realDisparitionDistanceThreshold) 
            {
                currentTimerBeforeDisparition -= Time.deltaTime;
                if (currentTimerBeforeDisparition <= 0)
                {
                    Defeated();
                }
            }
        }
    }

    // ======================== [SPAWNING METHODS] ========================

    void SpawningIn()
    {
        // Choose within the POSSIBLE points where it will spawn
        ChooseRandomSpawnPoints();

        // Then add in the forced spawn points. For loop starting at 1 to prevent the parent from being there. See the Start() method
        for (int i = 1; i < forcedSpawningPoints.Length; i++)
        {
            nextSpawningpoints.Add(forcedSpawningPoints[i].position);
        }

        // Reorder the array by their Z coordinate
        // Apparently this line works. See https://forum.unity.com/threads/how-to-reorder-lists.991499/
        nextSpawningpoints.Sort((a, b) => a.z.CompareTo(b.z));

        // Move to the first one
        currentPositionIndex = 0;
        transform.position = nextSpawningpoints[currentPositionIndex];
    }

    void ChooseRandomSpawnPoints()
    {
        for (int i = 1; i < possibleSpawningPoints.Length; i++)
        {   
            if (UnityEngine.Random.value < spawnPercentage)
            {
                nextSpawningpoints.Add(possibleSpawningPoints[i].position);
            }
        }
    }

    void Defeated()
    {
        // Reset the timer to a big value so the call of Defeated() in the Update is stopped (the loop to detect if the player is close is still called)
        currentTimerBeforeDisparition = 999f;

        StartCoroutine(GoToNextPosition());      
    }

    IEnumerator GoToNextPosition()
    {
        // Create the vector reference to create it once and not every frame
        Vector3 nextPos = transform.position;

        // Move away slowly so the sound kind of fades out (and the collider too)
        while (Mathf.Abs(transform.position.x) < 20)
        {
            // Increase (or decrease depending on the sign) by the speed to move away
            nextPos[0] += Mathf.Sign(nextPos[0]) * Time.deltaTime * DisparitionSpeed;

            // Set the new position
            transform.position = nextPos;

            yield return new WaitForEndOfFrame();
        }

        // Then teleport to the next position
        currentPositionIndex ++;

        // Move to the first one if The Witness was on last position, it's a way to discard it for the time being
        transform.position = nextSpawningpoints[currentPositionIndex % nextSpawningpoints.Count];

        // Debug.Log("Teleporting to " + nextSpawningpoints[currentPositionIndex % nextSpawningpoints.Count]);  

        // Reset the timer to a new usable value afterwards
        ResetTimerValue();

        yield return null;
        StopAllCoroutines();
    }

    void ResetTimerValue()
    {
        // The timer is going to be set as TheValue +/- 30%
        // So I create a value between 0 and 1, offset it to be between -.5 and .5, and multiply by 0.6 to reduce the range to between -.3 .3
        currentTimerBeforeDisparition = (UnityEngine.Random.value - .5f) * .6f * timerBeforeDisparition + timerBeforeDisparition;
    }

    public void Flashed()
    {
        // Temporary JustMoveInFrontOfMe
        transform.position = PlayerRef.transform.position + Vector3.forward * 4 + Vector3.up * 4;

        Debug.LogError("THE WITNESS KILLED YOU");

        StopAllCoroutines();

        GameManager.KillPlayer();
    }

}
