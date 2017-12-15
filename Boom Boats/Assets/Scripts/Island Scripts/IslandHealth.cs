using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandHealth : MonoBehaviour {

    private int health;
    public int initialHealth;
    public WaveManager waveManager;
    public SpawnManager spawnManager;

    private void Start()
    {
        health = initialHealth;
    }

    public void ReduceIslandHealth()
    {
        //Debug.Log("Island was hit");
        health--;
        if (health == 0)
        {
            islandDied();

        }
    }

    private void islandDied()
    {
        waveManager.IncreaseWave(true);
        spawnManager.OnIslandDeath(gameObject.GetComponent<IslandCannonRelation>().cannon.location);
        gameObject.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
