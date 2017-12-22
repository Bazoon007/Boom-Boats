using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandHealth : MonoBehaviour {

    private int health;
    public int initialHealth;
    public MasterManager masterManager;
    
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
        masterManager.waveManager.IncreaseWave(true);
        masterManager.spawnManager.OnIslandDeath(gameObject.GetComponent<IslandCannonRelation>().cannon.location);
        gameObject.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ResetIsland()
    {
        health = initialHealth;
        gameObject.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
}
