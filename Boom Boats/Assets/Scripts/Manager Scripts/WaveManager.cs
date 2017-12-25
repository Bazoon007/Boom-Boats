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
        ResetWaveManager();
    }

    private void updateWaveText()
    {
        waveText.text = "Current Wave: " + currentWave + " " + masterManager.spawnManager.spawnBoatSpeed;
    }

    public void CheckIfNeedToIncreaseWave(int waveScore)
    {
        if (waveScore == waveLength + currentWave)
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
        masterManager.spawnManager.spawnTime *= 0.9f;
        if (masterManager.spawnManager.spawnBoatSpeed < 2.25f)
        {
            masterManager.spawnManager.spawnBoatSpeed *= 1.025f;
        }
    }

    public void ResetWaveManager()
    {
        currentWave = 0;
        updateWaveText();
    }
}
