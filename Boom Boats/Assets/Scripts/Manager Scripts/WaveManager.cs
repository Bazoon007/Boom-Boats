using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public int waveLeangth;
    public UnityEngine.UI.Text waveText;
    public int currentWave;
    public SpawnManager spawnManager;

    private void Start()
    {
        currentWave = 0;
        updateWaveText();
    }

    private void updateWaveText()
    {
        waveText.text = "Current Wave: " + currentWave;
    }

    public void CheckIfNeedToIncreaseWave(int numberOfDestroyedBoats)
    {
        if (numberOfDestroyedBoats % waveLeangth == 0)
        {
            Debug.Log("Number of destroyed boats: " + numberOfDestroyedBoats);
            currentWave++;
            Debug.Log("Starting wave: " + currentWave);
            updateWaveText();
            Debug.Log("Disabling existing wave");
            spawnManager.DisableAllActiveBoats();
        }
    }
}
