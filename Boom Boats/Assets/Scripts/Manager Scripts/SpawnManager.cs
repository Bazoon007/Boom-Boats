using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public float spawnTime;
    private float lastSpawn;
    public int maxBoats;
    public GameObject boat;
    public float spawnBoatSpeed;
    public GameObject[] boats;    
    public Vector3[] spawnPoints;
    public int[] spawnPointsCountArray;
    private byte minCount;
    private int min;
    public MasterManager masterManager;
    public float startingZposition;

    public static SpawnManager getInstance()
    {
        return FindObjectOfType<SpawnManager>();
    }

    internal int FindWinner()
    {
        for (int i = 0; i < 4; i++)
        {
            if (spawnPointsCountArray[i] != int.MaxValue)
            {
                return i;
            }
        }
        return -1;
    }

    void Start ()
    {
        ResetSpawnManager();
    }

    public void ResetSpawnManager()
    {
        DisableAllActiveBoats();
        InitiateBoats(maxBoats, masterManager.waveManager.currentWave);
        InitiateSpawnPoints();
    }

    private void InitiateSpawnPoints()
    {
        spawnPoints = new Vector3[4];
        spawnPoints[0] = new Vector3(0f, 0f, startingZposition);
        spawnPoints[1] = new Vector3(0f, 0f, startingZposition);
        spawnPoints[2] = new Vector3(0f, 0f, startingZposition);
        spawnPoints[3] = new Vector3(0f, 0f, startingZposition);

        spawnPointsCountArray = new int[spawnPoints.Length];
        for (int i = 0; i < spawnPointsCountArray.Length; i++)
        {
            spawnPointsCountArray[i] = 0;
        }

        lastSpawn = 0;
    }

    private void InitiateBoats(int numberOfBoats, int wave)
    {
        boats = new GameObject[numberOfBoats];
        for (int i = 0; i < numberOfBoats; i++)
        {
            GameObject newBoat = (GameObject)Instantiate(boat);
            newBoat.GetComponent<BoatCannonBallCollider>().scoreManager = masterManager.scoreManager;
            newBoat.SetActive(false);
            newBoat.GetComponent<BoatMover>().masterManager = masterManager;
            boats[i] = newBoat;
        }
    }

    private void Update()
    {
        if ((Time.time > lastSpawn && masterManager.IsGameRunning()))
        {
            lastSpawn = Time.time + spawnTime;
            Spawn();
        }
    }

    void Spawn()
    {
        for(int i = 0; i < boats.Length; i++)
        {
            if(!boats[i].activeInHierarchy)
            {
                int location = getSpawnIndex();
                addBoatToList(location);
                if (location % 2 == 0)
                {
                    boats[i].tag = "RDiag";
                }
                else
                {
                    boats[i].tag = "Diag";
                }
                activateBoat(i,location);
                break;
            }
        }
    }

    private void initiateBoatHealth(GameObject boat)
    {
        if (masterManager.waveManager.currentWave < 1)
        {
            boat.GetComponent<BoatHealth>().setBoatHealth(1);
        }
        else
        {
            boat.GetComponent<BoatHealth>().setBoatHealth(2);
        }

    }

    private int getSpawnIndex()
    {
        min = spawnPointsCountArray[0];
        minCount = 1;
        for (int i = 1; i < spawnPointsCountArray.Length; i++)
        {
            if(spawnPointsCountArray[i] < min)
            {
                minCount = 1;
                min = spawnPointsCountArray[i];
            }
            else if(spawnPointsCountArray[i] == min)
            {
                minCount++;
            }
        }
        int k = UnityEngine.Random.Range(1, minCount + 1);
        int indexCount = 0;
        int lastMinIndex = 0;
        for (int i = 0; indexCount < k && i < spawnPointsCountArray.Length; i++)
        {
            if (spawnPointsCountArray[i] <= min)
            {
                indexCount++;
                lastMinIndex = i;
            }
        }
        return lastMinIndex;
    }

    public void removeBoatFromList(int target)
    {
        spawnPointsCountArray[target]--;
    }

    public void addBoatToList(int target)
    {
        spawnPointsCountArray[target]++;
    }

    public void DisableAllActiveBoats()
    {
        foreach (GameObject boat in boats)
        {
            if (boat.activeInHierarchy)
            {
                boat.SetActive(false);
            }
        }

    }

    public void OnIslandDeath(int islandIndex)
    {
        spawnPointsCountArray[islandIndex] = int.MaxValue;

        masterManager.IslandDown();
    }

    private void activateBoat(int i,int location)
    {
        boats[i].GetComponent<BoatMover>().orignialTarget = location;
        boats[i].transform.position = spawnPoints[location];
        boats[i].transform.rotation = Quaternion.identity;
        boats[i].GetComponent<BoatMover>().speed = spawnBoatSpeed;
        initiateBoatHealth(boats[i]);
        boats[i].SetActive(true);
    }
    
}
