using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public UnityEngine.UI.Text waveText;
    public int currentWave;

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
        if (numberOfDestroyedBoats % 3 == 0)
        {
            Debug.Log("Number of destroyed boats: " + numberOfDestroyedBoats);
            currentWave++;
            Debug.Log("Starting wave: " + currentWave);
            updateWaveText();
        }
    }
}
