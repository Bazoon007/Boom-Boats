using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandHealth : MonoBehaviour {

    private int health;
    public int initialHealth;
    public MasterManager masterManager;
    public GameObject OneHealthRemainingFlag;
    public GameObject TwoHealthRemainingFlag;
    public GameObject ThreeHealthRemainingFlag;

    
    private void Start()
    {
        health = initialHealth;
        OneHealthRemainingFlag.SetActive(true);
        TwoHealthRemainingFlag.SetActive(true);
        ThreeHealthRemainingFlag.SetActive(true);
    }

    public void ReduceIslandHealth()
    {
        //Debug.Log("Island was hit");
        health--;

        if (health == 2)
        {
            ThreeHealthRemainingFlag.SetActive(false);
        }
        else if (health == 1)
        {
            TwoHealthRemainingFlag.SetActive(false);
        }
        else if (health == 0)
        {
            islandDied();
        }
        
    }

    public void IncreaseIslandHealth()
    {
        if (health < 3)
        {
            health++;
        }

        if (health == 2)
        {
            TwoHealthRemainingFlag.SetActive(true);
        }
        else if (health == 3)
        {
            ThreeHealthRemainingFlag.SetActive(true);
        }
    }

    private void islandDied()
    {
        OneHealthRemainingFlag.SetActive(false);
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
        OneHealthRemainingFlag.SetActive(true);
        TwoHealthRemainingFlag.SetActive(true);
        ThreeHealthRemainingFlag.SetActive(true);
    }
}
