using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    private int[] cannonScores;
    private int totalScore;

    // Use this for initialization
    void Start () {
        cannonScores = new int[4];
        foreach (int i in cannonScores)
        {
            cannonScores[i] = 0;
        }

        totalScore = 0;
    }

    public void UpdateScore(int cannonIndex)
    {
        cannonScores[cannonIndex]++;
        totalScore++;
    }
}
