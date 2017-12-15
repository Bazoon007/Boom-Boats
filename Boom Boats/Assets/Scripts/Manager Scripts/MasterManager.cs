using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterManager : MonoBehaviour {

    public WaveManager waveManager;
    public ScoreManager scoreManager;
    public SpawnManager spawnManager;

    public Text winningText;
    public Text finalWaveText;

    public int numberOfActiveIslands;
    private bool gameEnded;

    private void Start()
    {
        numberOfActiveIslands = 4;
        gameEnded = false;
        Time.timeScale = 1;
    }

    public bool isGameEnded()
    {
        return gameEnded;
    }

    public void IslandDown()
    {
        numberOfActiveIslands--;
        checkIfGameEnded();
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
        finalWaveText.text = "The game has ended after " + waveNumber + " waves";
        winningText.text = "Winner is Player " + winner;
        waveManager.waveText.text = string.Empty;
        Time.timeScale = 0;
        gameEnded = true;
    }

    
}
