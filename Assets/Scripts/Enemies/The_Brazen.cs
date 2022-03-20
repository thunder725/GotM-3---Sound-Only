using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copy-pasted from The Witness because their spawning behaviors are close
// The difference is how to kill them
public class The_Brazen : MonoBehaviour
{
    [SerializeField] [Range(0,1)] float spawnPercentage;

    [SerializeField] GameObject possibleSpawningPointsObject, forcedSpawningPointsObject;
    Transform[] possibleSpawningPoints, forcedSpawningPoints;
    [SerializeField] List<Vector3> nextSpawningpoints = new List<Vector3>();
    bool isEnabled;
    int currentPositionIndex;
    GameObject PlayerRef;

    [SerializeField] float RushingSpeed;

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
    }

    void Update()
    {
        if (!isEnabled)
        {
            if (GameManager.BrazenSpawned)
            {
                // The frame The Brazen spawns in
                isEnabled = true;
                SpawningIn();
            }
        }
    }

    // ======================== [SPAWNING METHODS] ========================

    // Fully copy-pasted from The_Witness (script)
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
        currentPositionIndex = -1;
        
        MoveToNextPosition();
    }

    void MoveToNextPosition()
    {
        currentPositionIndex++;
        transform.position = nextSpawningpoints[currentPositionIndex % nextSpawningpoints.Count];

        if (transform.position.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Fully copy-pasted from The_Witness (script)
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

    public void KillPlayer()
    {
        transform.position = PlayerRef.transform.position + Vector3.forward * 4 + Vector3.up * 4;
        GameManager.KillPlayer();
    }

    IEnumerator GoToNextPosition()
    {
        // Create the vector reference to create it once and not every frame
        Vector3 nextPos = transform.position;

        // If x positive (on the right), go to the x negative (to the left)
        float sign = - Mathf.Sign(transform.position.x);

        // Rush the other side
        while (Mathf.Abs(transform.position.x) < 25)
        {
            // Rush the opposite direction
            nextPos[0] += sign * Time.deltaTime * RushingSpeed;

            // Set the new position
            transform.position = nextPos;

            yield return new WaitForEndOfFrame();
        }

        // Move to next position
        MoveToNextPosition();

        // Debug.Log("Teleporting to " + nextSpawningpoints[currentPositionIndex % nextSpawningpoints.Count]);  

        yield return null;
        StopAllCoroutines();
    }

    public void Flashed()
    {
        StartCoroutine(GoToNextPosition());   
    }
}
