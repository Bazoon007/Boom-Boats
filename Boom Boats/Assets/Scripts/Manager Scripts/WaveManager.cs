using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public int waveLength;
    public Text waveText;
    public int currentWave;
    public MasterManager masterManager;

    private void Start()
    {
        currentWave = 0;
        updateWaveText();
    }

    private void updateWaveText()
    {
        waveText.text = "Current Wave: " + currentWave;
    }

    public void CheckIfNeedToIncreaseWave(int waveScore)
    {
        if (waveScore == waveLength)
        {
            IncreaseWave(false);
        }
    }

    public void IncreaseWave(bool didIslandDie)
    {
        currentWave++;
        updateWaveText();
        masterManager.scoreManager.EndOfWave(didIslandDie);
        masterManager.spawnManager.DisableAllActiveBoats();
    }

}
