using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Follower : MonoBehaviour
{
    AudioSource RunningSoundSource;
    float volumeValue;

    [SerializeField] float startSpeed, maxSpeed, speedMultiplicator;
    float currentSpeed;
    public bool isEnabled;
    [SerializeField] GameObject legOne, legTwo;
    [SerializeField] float steppingFrequency;

    // X for Highest  -  Y for Lowest
    [SerializeField] Vector2 legOnePositions, legTwoPositions;
    Vector3 legOnePos, legTwoPos;
    float currentLegOneHeight, currentLegTwoHeight;
    float legDirections;

    void Awake()
    {
        RunningSoundSource = GetComponent<AudioSource>();
        volumeValue = RunningSoundSource.volume;
    }

    void Start()
    {
        RunningSoundSource.volume = 0;

        currentSpeed = 0;
        legDirections = 1;

        // Spawn the legs at their starting position. Lowest (y) for one and highest (x) for two
        legOne.transform.localPosition = new Vector3(legOne.transform.localPosition.x, legOnePositions.y, legOne.transform.localPosition.z);
        legTwo.transform.localPosition = new Vector3(legTwo.transform.localPosition.x, legTwoPositions.x, legTwo.transform.localPosition.z);
    }

    void Update()
    {
        if (GameManager.FollowerSpawned)
        {
            if (!isEnabled)
            {
                // The frame that it is spawned
                currentSpeed = startSpeed;
                isEnabled = true;

                // Spawn in starting position
                transform.position = new Vector3(0, 5.7f, 50);

                // Re-enable the sound
                RunningSoundSource.volume = volumeValue;
            }

            // Move forward
            transform.position += Vector3.forward * Time.deltaTime * currentSpeed;

            // Go Faster
            currentSpeed = Mathf.Min(currentSpeed + (Random.value + .5f) * .4f * (speedMultiplicator) * Time.deltaTime, maxSpeed);
            
            MoveLegs();
        }
    }

    void MoveLegs()
    {
        // Get the current positions
        legOnePos = legOne.transform.localPosition;
        legTwoPos = legTwo.transform.localPosition;

        // Calculate the height for this frame

        // Min pos + Percentage*DifferenceMinMax * Speed
        // When max or min then inverse direction
        // Direction inverted for the legTwo
        legOnePos[1] += legDirections * steppingFrequency * (legOnePositions.y - legOnePositions.x) * Time.deltaTime;
        legTwoPos[1] -= legDirections * steppingFrequency * (legTwoPositions.y - legTwoPositions.x) * Time.deltaTime;

        legOnePos[1] = Mathf.Clamp(legOnePos[1], legOnePositions.y, legOnePositions.x);
        legTwoPos[1] = Mathf.Clamp(legTwoPos[1], legTwoPositions.y, legTwoPositions.x);

        if (legOnePos[1] == legOnePositions.y || legOnePos[1] == legOnePositions.x)
        {
            // Invert the direction
            legDirections = -legDirections;
        }

        // Move the legs
        legOne.transform.localPosition = legOnePos;
        legTwo.transform.localPosition = legTwoPos;



        // // Get the current positions
        // legOnePos = legOne.transform.localPosition;
        // legTwoPos = legTwo.transform.localPosition;

        // // Calculate the height for this frame
        // currentLegOneHeight = legOnePositions.y + Mathf.PingPong(Time.time * steppingSpeed, legOnePositions.x - legOnePositions.y);
        // //                                                                     Add half the multiplicator to offset them
        // currentLegTwoHeight = legTwoPositions.y + Mathf.PingPong((Time.time + steppingSpeed * .5f) * steppingSpeed, legTwoPositions.x - legTwoPositions.y);

        // // Set the positions
        // legOnePos[1] = currentLegOneHeight;
        // legTwoPos[1] = currentLegTwoHeight;

        // // Move the legs
        // legOne.transform.localPosition = legOnePos;
        // legTwo.transform.localPosition = legTwoPos;
    }
}
