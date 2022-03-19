using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Follower : MonoBehaviour
{
    AudioSource RunningSoundSource;
    float volumeValue;

    [SerializeField] float startSpeed, maxSpeed, speedMultiplicator;
    float currentSpeed;
    bool isEnabled;

    void Awake()
    {
        RunningSoundSource = GetComponent<AudioSource>();
        volumeValue = RunningSoundSource.volume;
        RunningSoundSource.volume = 0;

        currentSpeed = 0;


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

                // Spawn in (0, 0, 50)
                transform.position = Vector3.forward * 50;

                // Re-enable the sound
                RunningSoundSource.volume = volumeValue;
            }

            // Move forward
            transform.position += Vector3.forward * Time.deltaTime * currentSpeed;

            // Go Faster
            currentSpeed = Mathf.Min(currentSpeed + (Random.value + .5f) * .4f * (speedMultiplicator) * Time.deltaTime, maxSpeed);
        }
    }
}
