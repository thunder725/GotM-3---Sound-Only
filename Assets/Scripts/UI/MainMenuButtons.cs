using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Copypasted from the 2nd game, which was copypasted from the first one... Recycling FTW
public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject MainMenuPanel;
    static bool hasBeenSetup;
    [SerializeField] GameObject[] TutorialUsefulPieces;
    [SerializeField] Button PlayButton, ReturnButton;

    [Header("FOR TUTORIAL BUTTONS ONLY")]
    [SerializeField] GameObject[] TutorialPanels;

    static int currentTutorialPanel;


    void Start()
    {
        // Check the current scene so it doesn't do it in the Main Game scene which has no tutorial panel
        if (!hasBeenSetup && SceneManager.GetActiveScene().buildIndex == 0)
        {ExitTutorial(); hasBeenSetup = true;}
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        Debug.Log("e");
        MainMenuPanel.SetActive(false);
        foreach (GameObject g in TutorialUsefulPieces)
        {
            g.SetActive(true);
        }
        ReturnButton.Select();

        // Reset the tutorial panels
        foreach (GameObject g in TutorialPanels)
        {
            g.SetActive(false);
        }
        TutorialPanels[0].SetActive(true);
        currentTutorialPanel = 0;
    }

    public void showNextTutorialPanel()
    {
        if (currentTutorialPanel != TutorialPanels.Length-1)
        {
            TutorialPanels[currentTutorialPanel].SetActive(false);
            currentTutorialPanel ++;
            TutorialPanels[currentTutorialPanel].SetActive(true);
        }
    }

    public void showPreviousTutorialPanel()
    {
        if (currentTutorialPanel != 0)
        {
            TutorialPanels[currentTutorialPanel].SetActive(false);
            currentTutorialPanel --;
            TutorialPanels[currentTutorialPanel].SetActive(true);
        }
    }

    public void ExitTutorial()
    {
        MainMenuPanel.SetActive(true);
        foreach (GameObject g in TutorialUsefulPieces)
        {
            g.SetActive(false);
        }
        PlayButton.Select();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }



}