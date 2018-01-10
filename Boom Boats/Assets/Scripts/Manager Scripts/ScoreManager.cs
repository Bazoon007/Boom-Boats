using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int[] waveCannonScores;
    public int totalScore;
    public int waveScore;
    public int lastWaveWinner;
    public MasterManager masterManager;
    public GameObject Island0;
    public GameObject Island1;
    public GameObject Island2;
    public GameObject Island3;

    void Start ()
    {
        ResetScoreManager();
    }

    public int GetWaveScore()
    {
        return waveScore;
    }

    public void ResetScoreManager()
    {
        waveCannonScores = new int[4];
        totalScore = 0;
        waveScore = 0;
        lastWaveWinner = -1;

        resetScoreArray(waveCannonScores);
    }

    public void UpdateScore(int cannonIndex)
    {
        waveCannonScores[cannonIndex]++;
        totalScore++;
        waveScore++;
        masterManager.waveManager.CheckIfNeedToIncreaseWave(waveScore);
    }
    
    public void UpdateScoreOnIslandHit()
    {
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

    private void resetScoreArray(int[] scoreArray)
    {
        for (int i = 0; i < scoreArray.Length; i++)
        {
            scoreArray[i] = 0;
        }
    }

    private void setWaveWinner()
    {
        int maxCount = 0;
        int maxScore = -1;
        int maxIslandIndex = -1;

        for (int i = 0; i < 4; i++)
        {
            if (waveCannonScores[i] > maxScore)
            {
                maxCount = 1;
                maxScore = waveCannonScores[i];
                maxIslandIndex = i;
            }
            else if (waveCannonScores[i] == maxScore)
            {
                maxCount++;
            }
        }

        if (maxCount == 1)
        {
            lastWaveWinner = maxIslandIndex;
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
        resetScoreArray(waveCannonScores);
    }

}
