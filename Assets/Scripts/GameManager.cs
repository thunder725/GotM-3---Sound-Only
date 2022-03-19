using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Contains several general values
public class GameManager : MonoBehaviour
{
    [Header("X Coord that's the end of the game")]
    [SerializeField] float _endLineValue;
    [SerializeField] Text EnemySpawnedText;
    [SerializeField] GameObject PhoneVoltergeistPanel, PhoneEleventhPanel;
    public static float EndCoordinateValue;
    public static bool VoltergeistSpawned, FollowerSpawned, BrazenSpawned, EleventhSpawned, WitnessSpawned;

    void Awake()
    {
        // Set the EndCoordinateValue for everybody, but make sure it's a multiple of 10
        EndCoordinateValue = 10*(int)(_endLineValue/10);
    }

    void Start()
    {
        PhoneVoltergeistPanel.SetActive(false);
        PhoneEleventhPanel.SetActive(false);
    }

    public void SpawnVoltergeist()
    {
        EnemySpawnedText.text += "Voltergeist Spawned\n";
        VoltergeistSpawned = true;

        PhoneVoltergeistPanel.SetActive(true);

    }

    public void SpawnFollower()
    {
        EnemySpawnedText.text += "Follower Spawned\n";
        FollowerSpawned = true;

    }

    public void SpawnBrazen()
    {
        EnemySpawnedText.text += "Brazen Spawned\n";
        BrazenSpawned = true;

    }

    public void SpawnEleventh()
    {
        EnemySpawnedText.text += "Eleventh Spawned\n";
        EleventhSpawned = true;

        PhoneEleventhPanel.SetActive(true);

    }

    public void SpawnWitness()
    {
        EnemySpawnedText.text += "Witness Spawned\n";
        WitnessSpawned = true;

    }


}
