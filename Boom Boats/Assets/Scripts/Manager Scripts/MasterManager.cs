using UnityEngine;
using UnityEngine.UI;

public class MasterManager : MonoBehaviour {

    public WaveManager waveManager;
    public ScoreManager scoreManager;
    public SpawnManager spawnManager;
    public SoundManager soundManager;
    public GameObject backgroundMusic;
    public IslandHealth Island0;
    public IslandHealth Island1;
    public IslandHealth Island2;
    public IslandHealth Island3;
    public GameObject endGamePanel;
    public MuteButton muteButtonStart;
    public MuteButton muteButtonPause;
    public MuteButton muteButtonEnd;
    public GameObject winPopUps;
    public GameObject pauseGamePanel;
    public GameObject motherShip;
    public Text winningText;
    public Text finalWaveText;
    

    private int numberOfActiveIslands;
    private bool gameIsRunning;
    private bool timeScaleFlag;

    private void Start()
    {
        motherShip.SetActive(false);
        resetMasterManager(false);
        timeScaleFlag = false;
    }

    private void Update()
    {
        if (timeScaleFlag)
        {
            setTimeScale();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
        shootCannonFromKeyboard();
    }

    private void shootCannonFromKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Island0.GetComponentInChildren<IslandCannonRelation>().cannon.GetComponent<CannonShoot>().shoot();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Island1.GetComponentInChildren<IslandCannonRelation>().cannon.GetComponent<CannonShoot>().shoot();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Island2.GetComponentInChildren<IslandCannonRelation>().cannon.GetComponent<CannonShoot>().shoot();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Island3.GetComponentInChildren<IslandCannonRelation>().cannon.GetComponent<CannonShoot>().shoot();
        }
    }

    public bool IsGameRunning()
    {
        return gameIsRunning;
    }

    public void StartGame()
    {
        gameIsRunning = true;
        timeScaleFlag = true;
        waveManager.updateWaveText();
        soundManager.PlayThreeTwoOneSound();
        motherShip.SetActive(true);
        backgroundMusic.GetComponent<AudioSource>().PlayDelayed(3f);
    }

    public void IslandDown()
    {
        numberOfActiveIslands--;
        checkIfGameEnded();
    }

    public void ResetGame()
    {
        waveManager.ResetWaveManager();
        scoreManager.ResetScoreManager();
        spawnManager.ResetSpawnManager();
        resetIslandsAndCannons();
        resetMasterManager(true);
        endGamePanel.gameObject.SetActive(false);
        SetActiveAllChildren(winPopUps.transform, false);
        timeScaleFlag = true;
        motherShip.SetActive(true);
    }

    public void ResumeGame()
    {
        waveManager.waveText.gameObject.SetActive(true);
        motherShip.SetActive(true);
        gameIsRunning = true;
    }

    public void changeAllMuteButtons(bool isPaused)
    {
        muteButtonEnd.ChangeMuteButtonImage(isPaused);
        muteButtonStart.ChangeMuteButtonImage(isPaused);
        muteButtonPause.ChangeMuteButtonImage(isPaused);
    }

    private void checkIfGameEnded()
    {
        if (numberOfActiveIslands == 1)
        {
            int winner = spawnManager.FindWinner();
            endGame(winner);
        }
    }

    private void endGame(int winner)
    {
        timeScaleFlag = false;
        endGamePanel.gameObject.SetActive(true);
        activateWinPopUp(winner);
        soundManager.PlayGameEndSound(winner);
        waveManager.waveText.text = string.Empty;
        gameIsRunning = false;
        disableAllIslands();
        motherShip.SetActive(false);
    }


    private void disableAllIslands()
    {
        Island0.gameObject.SetActive(false);
        Island1.gameObject.SetActive(false);
        Island2.gameObject.SetActive(false);
        Island3.gameObject.SetActive(false);
    }

    private void resetIslandsAndCannons()
    {
        Island0.ResetIsland();
        Island1.ResetIsland();
        Island2.ResetIsland();
        Island3.ResetIsland();
    }

    private void resetMasterManager(bool isGameRunning)
    {
        numberOfActiveIslands = 4;
        gameIsRunning = isGameRunning;
    }

    private void pauseGame()
    {
        if (gameIsRunning)
        {
            gameIsRunning = false;
            waveManager.waveText.gameObject.SetActive(false);
            motherShip.SetActive(false);
            pauseGamePanel.gameObject.SetActive(true);
        }
    }

    private void activateWinPopUp(int winner)
    {
        winPopUps.gameObject.SetActive(true);
        winPopUps.transform.GetChild(winner).gameObject.SetActive(true);
    }

    private void SetActiveAllChildren(Transform transform, bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
            SetActiveAllChildren(child, value);
        }
    }

    private void setTimeScale()
    {
        if (IsGameRunning()) {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
