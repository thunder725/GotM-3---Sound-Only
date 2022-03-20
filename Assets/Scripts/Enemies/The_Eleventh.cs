using UnityEngine;

public class The_Eleventh : MonoBehaviour
{
    // The Eleventh controls the Game's Music so it will control the game's music entirely on itself
    [SerializeField] AudioSource OST_One_Source, DirtSource;

    bool isEnabled, isAttacking;
    [SerializeField] float averageTimerBetweenAttacks, timerBeforeKill;
    float currentTimerBeforeAttack, currentTimerBeforeKill;
    int musicResetTime;
    GameObject PlayerRef;

    // ======================== [DEFAULT UNITY METHODS] ========================
    void Awake() // I generally use the awake for references and start for the values
    {
        // Get a reference to the player
        PlayerRef = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Start()
    {
        // Debug.Log(OST_One_Source.clip.samples);
        isEnabled = isAttacking = false;
    }

    void Update()
    {
        if (!isEnabled)
        {
            if (GameManager.EleventhSpawned)
            {
                // The frame The Eleventh spawns in
                isEnabled = true;
                ResetTimer();
            }
        }
        else if (currentTimerBeforeAttack > 0)
        {
            currentTimerBeforeAttack -= Time.deltaTime;
            if (currentTimerBeforeAttack < 0)
            {
                // The frame that the timer reaches 0. Called once
                LaunchAttack();
            }
        }
        else if (isAttacking)
        {
            if (OST_One_Source.timeSamples > musicResetTime)
            {
                OffsetBackMusic();
            }

            // Reduce the timer between the start of the attack and the death of the player
            currentTimerBeforeKill -= Time.deltaTime;
            
            if (currentTimerBeforeKill < 0)
            {
                KillPlayer();
            }
        }
    }

    // ======================== [ELEVENTH METHODS] ========================

    void ResetTimer()
    {
        // Timer +/- 30%
        currentTimerBeforeAttack = (UnityEngine.Random.value - .5f) * .6f * averageTimerBetweenAttacks + averageTimerBetweenAttacks;
    }

    void LaunchAttack()
    {
        // Say that we're attacking
        isAttacking = true;
        
        // Save the time where we must attack
        musicResetTime = OST_One_Source.timeSamples;

        // Set the timer before killing
        currentTimerBeforeKill = timerBeforeKill;

        // Start the attack auditively
        OffsetBackMusic();

        DirtSource.Play();
    }

    void OffsetBackMusic()
    {
        // Offset/Rewind by a random value between 1.5 and 2.5 seconds
        int _tempTime = OST_One_Source.timeSamples - (int)((Random.value + 1.5f) * 44100);

        // If I end up with a negative value, rewind from the end
        if (_tempTime < 0)
        {
            // OST_One_Source.clip.samples is the length in Samples of the music
            _tempTime += OST_One_Source.clip.samples;
        }
        OST_One_Source.timeSamples = _tempTime; 
    }

    public void AttackDisarmed()
    {
        // If is attacking, cancel attack
        if (isAttacking)
        {
            isAttacking = false;
            DirtSource.Stop();

            // Launch the attack back after a few seconds
            ResetTimer();
        }
        // Otherwise kill the player for trying to cancel something that is not there
        else
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        GameManager.KillPlayer();

        // Temporary JustMoveInFrontOfMe
        transform.position = PlayerRef.transform.position + Vector3.forward * 4 + Vector3.up * 4;

        Debug.LogError("THE ELEVENTH KILLED YOU");
    }

}
