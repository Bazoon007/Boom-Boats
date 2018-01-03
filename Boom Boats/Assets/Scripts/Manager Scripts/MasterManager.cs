using UnityEngine;
using UnityEngine.UI;

public class MasterManager : MonoBehaviour {

    public WaveManager waveManager;
    public ScoreManager scoreManager;
    public SpawnManager spawnManager;
    public IslandHealth Island0;
    public IslandHealth Island1;
    public IslandHealth Island2;
    public IslandHealth Island3;
    public GameObject endGamePanel;
    public GameObject pauseGamePanel;
    public Text winningText;
    public Text finalWaveText;

    private int numberOfActiveIslands;
    private bool gameIsRunning;

    private void Start()
    {
        resetMasterManager(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public bool IsGameRunning()
    {
        return gameIsRunning;
    }

    public void StartGame()
    {
        gameIsRunning = true;
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
    }

    public void ResumeGame()
    {
        gameIsRunning = true;
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
        int waveNumber = waveManager.currentWave;

        string winnerColor = string.Empty;

        switch (winner)
        {
            case 0:
                winnerColor = "Blue";
                break;

            case 1:
                winnerColor = "Black";
                break;

            case 2:
                winnerColor = "Green";
                break;

            case 3:
                winnerColor = "Red";
                break;

            default:
                break;
        }

        finalWaveText.text = "The game has ended after " + waveNumber + " waves";
        winningText.text = winnerColor + " Player Won!";

        waveManager.waveText.text = string.Empty;
        gameIsRunning = false;
        disableAllIslands();
        endGamePanel.gameObject.SetActive(true);

    }

    private void disableAllIslands()
    {
        Island0.gameObject.SetActive(false);
        Island1.gameObject.SetActive(false);
        Island2.gameObject.SetActive(false);
        Island3.gameObject.SetActive(false);

        Island0.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(false);
        Island1.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(false);
        Island2.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(false);
        Island3.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(false);
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
            pauseGamePanel.gameObject.SetActive(true);
        }
    }
}
