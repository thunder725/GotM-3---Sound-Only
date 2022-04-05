using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JumpscareManager : MonoBehaviour
{
    [SerializeField] float maxJumpscareTime;
    [SerializeField] float jumpscareIntensity;
    [SerializeField] AudioSource jumpscareSource, musicSource, dirtSource;
    [SerializeField] AudioClipsDictionary_ScriptableObject JumpscareSounds;
    [SerializeField] GameObject deathPanel;
    [SerializeField] Text killerNameText, tipsText;
    [SerializeField] string[] VoltergeistTips, WitnessTips, BrazenTips, EleventhTips, FollowerTips;
    [SerializeField] Color[] enemyNameColors;

    // ======================== [DEFAULT UNITY METHODS] ========================
    // void Awake()
    // {
        
    // }

    void Start()
    {
        deathPanel.SetActive(false);
    }

    // void Update()
    // {
        
    // }
    // ======================== [SCRIPT METHODS] ========================

    public IEnumerator JumpscareCoroutine(GameObject creature, string enemyName)
    {
        // Select one random jumpscare sound
        int selectedSound = Random.Range(0, JumpscareSounds.AudioClips.Length);

        // Set the sounds
        jumpscareSource.clip = JumpscareSounds.AudioClips[selectedSound].audioClip;
        jumpscareSource.volume = JumpscareSounds.AudioClips[selectedSound].volume;
        jumpscareSource.pitch = JumpscareSounds.AudioClips[selectedSound].pitch;
        jumpscareSource.Play();
        
        // Stop the music & dirt sound (Eleventh)
        musicSource.Stop();
        dirtSource.Stop();

        // Setting up
        float timer = 0;
        Vector3 startingPos = creature.transform.position;

        // Shaking them up
        while (timer < maxJumpscareTime)
        {
            creature.transform.position = startingPos + ((Vector3)UnityEngine.Random.insideUnitCircle * jumpscareIntensity);

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        // Putting them away
        creature.transform.position = Vector3.up * 500;

        // Show the Death Panel
        deathPanel.SetActive(true);

        // Update the killer's name
        killerNameText.text = "The " + enemyName;
        

        // Update color & give tips
        switch (enemyName)
        {
            case "Voltergeist":
                killerNameText.color = enemyNameColors[0];
                tipsText.text = "Tips: " + VoltergeistTips[Random.Range(0, VoltergeistTips.Length)];
            break;

            case "Witness":
                killerNameText.color = enemyNameColors[1];
                tipsText.text = "Tips: " + WitnessTips[Random.Range(0, WitnessTips.Length)];
            break;

            case "Brazen":
                killerNameText.color = enemyNameColors[2];
                tipsText.text = "Tips: " + BrazenTips[Random.Range(0, BrazenTips.Length)];
            break;

            case "Eleventh":
                killerNameText.color = enemyNameColors[3];
                tipsText.text = "Tips: " + EleventhTips[Random.Range(0, EleventhTips.Length)];
            break;

            case "Follower":
                killerNameText.color = enemyNameColors[4];
                tipsText.text = "Tips: " + FollowerTips[Random.Range(0, FollowerTips.Length)];
            break;
        }

        yield return null;
        StopAllCoroutines();
    }

}
