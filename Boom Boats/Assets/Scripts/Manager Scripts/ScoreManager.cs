using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    private int[] totalCannonScores;
    public int[] waveCannonScores;
    public int totalScore;
    public int waveScore;
    public int lastWaveWinner;
    public MasterManager masterManager;
    public GameObject Island0;
    public GameObject Island1;
    public GameObject Island2;
    public GameObject Island3;

    // Use this for initialization
    void Start ()
    {
        ResetScoreManager();
    }

    private void resetScoreArray(int[] scoreArray)
    {
        foreach (int i in scoreArray)
        {
            scoreArray[i] = 0;
        }
    }

    public int GetWaveScore()
    {
        return waveScore;
    }

    public void UpdateScore(int cannonIndex)
    {
        totalCannonScores[cannonIndex]++;
        waveCannonScores[cannonIndex]++;
        totalScore++;
        waveScore++;
        masterManager.waveManager.CheckIfNeedToIncreaseWave(waveScore);
    }
    
    public void EndOfWave(bool didIslandDie)
    {
        if (!didIslandDie)
        {
            setWaveWinner();
        }
        else
        {
            lastWaveWinner = -1;
        }

        resetWaveScore();
    }

    private void setWaveWinner()
    {
        int maxCount = 0;
        int maxScore = -1;
        int maxCannonIndex = -1;

        for (int i = 0; i < 4; i++)
        {
            if (waveCannonScores[i] > maxScore)
            {
                maxCount = 1;
                maxScore = waveCannonScores[i];
                maxCannonIndex = i;
            }
            else if (waveCannonScores[i] == maxScore)
            {
                maxCount++;
            }
        }

        if (maxCount == 1)
        {
            lastWaveWinner = maxCannonIndex;
            activateIncreaseHealth(lastWaveWinner);
        }
        else
        {
            lastWaveWinner = -1;
        }

        
    }

    private void activateIncreaseHealth(int lastWaveWinner)
    {
        switch (lastWaveWinner)
        {
            case 0:
                Island0.GetComponent<IslandHealth>().IncreaseIslandHealth();
                break;

            case 1:
                Island1.GetComponent<IslandHealth>().IncreaseIslandHealth();
                break;

            case 2:
                Island2.GetComponent<IslandHealth>().IncreaseIslandHealth();
                break;

            case 3:
                Island3.GetComponent<IslandHealth>().IncreaseIslandHealth();
                break;

            default:
                break;
        }
    }

    private void resetWaveScore()
    {
        waveScore = 0;
        //resetScoreArray(waveCannonScores);
        waveCannonScores[0] = 0;
        waveCannonScores[1] = 0;
        waveCannonScores[2] = 0;
        waveCannonScores[3] = 0;
    }

    public void ResetScoreManager()
    {
        totalCannonScores = new int[4];
        waveCannonScores = new int[4];
        totalScore = 0;
        waveScore = 0;
        lastWaveWinner = -1;

        resetScoreArray(totalCannonScores);
        resetScoreArray(waveCannonScores);
    }
}
