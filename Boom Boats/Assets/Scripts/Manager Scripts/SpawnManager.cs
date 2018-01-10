using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public float spawnTime;
    public int maxBoats;
    public MasterManager masterManager;
    public float startingZposition;
    public GameObject boat;
    public float spawnBoatSpeed;
    public GameObject[] boats;    
    public Vector3[] spawnPoints;
    public int[] spawnPointsCountArray;

    private byte minCount;
    private float lastSpawn;
    private int min;
    private float initialTime;
    private float initialBoatSpeed;
    public int numberOfSentBoats;

    void Start ()
    {
        initialTime = spawnTime;
        initialBoatSpeed = spawnBoatSpeed;
        ResetSpawnManager();
    }

    private void Update()
    {
        if ((Time.time > lastSpawn && masterManager.IsGameRunning()))
        {
            if (numberOfSentBoats < masterManager.waveManager.GetWaveTotalLength())
            {
                lastSpawn = Time.time + spawnTime;
                spawn();
            }
        }
    }

    internal void ResetBoatCounter()
    {
        numberOfSentBoats = 0;
    }

    public static SpawnManager getInstance()
    {
        return FindObjectOfType<SpawnManager>();
    }

    public int FindWinner()
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

    public void RemoveBoatFromList(int target)
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

    public void ResetSpawnManager()
    {
        DisableAllActiveBoats();
        InitiateBoats(maxBoats, masterManager.waveManager.currentWave);
        initiateSpawnPoints();
        spawnTime = initialTime;
        spawnBoatSpeed = initialBoatSpeed;
        numberOfSentBoats = 0;
    }

    private void initiateSpawnPoints()
    {
        resetSpawnPointsArray();
        resetSpawnPointCountArray();
        lastSpawn = 0;
    }

    private void resetSpawnPointCountArray()
    {
        spawnPointsCountArray = new int[spawnPoints.Length];

        for (int i = 0; i < spawnPointsCountArray.Length; i++)
        {
            spawnPointsCountArray[i] = 0;
        }
    }

    private void resetSpawnPointsArray()
    {
        spawnPoints = new Vector3[4];
        for (int i = 0; i < 4; i++)
        {
            spawnPoints[i] = new Vector3(0f, 0f, startingZposition);
        }
    }

    private void InitiateBoats(int numberOfBoats, int wave)
    {
        boats = new GameObject[numberOfBoats];
        for (int i = 0; i < numberOfBoats; i++)
        {
            GameObject newBoat = (GameObject)Instantiate(boat);
            newBoat.GetComponent<BoatCannonBallCollider>().MasterManager = masterManager;
            newBoat.SetActive(false);
            newBoat.GetComponent<BoatMover>().masterManager = masterManager;

            boats[i] = newBoat;
        }
    }

    private void spawn()
    {
        numberOfSentBoats++;
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

    private void activateBoat(int i,int location)
    {
        boats[i].GetComponent<BoatMover>().orignialTarget = location;
        boats[i].transform.position = spawnPoints[location];
        boats[i].transform.rotation = Quaternion.identity;
        boats[i].GetComponent<BoatMover>().movementSpeed = spawnBoatSpeed;
        initiateBoatHealth(boats[i]);
        boats[i].SetActive(true);
        boats[i].transform.GetChild(1).gameObject.SetActive(true);
    }
    
}
