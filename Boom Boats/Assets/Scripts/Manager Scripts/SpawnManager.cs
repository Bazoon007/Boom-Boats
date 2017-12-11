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

    public float startingZposition;

    public static SpawnManager getInstance()
    {
        return FindObjectOfType<SpawnManager>();
    }
    void Start () {
        boats = new GameObject[maxBoats];
        for(int i = 0; i < maxBoats; i++)
        {
            GameObject obj = (GameObject)Instantiate(boat);
            obj.SetActive(false);
            boats[i] = obj;
        }
        spawnPoints = new Vector3[4];
        spawnPoints[0] = new Vector3(0f, 0f, startingZposition);
        spawnPoints[1] = new Vector3(0f, 0f, startingZposition);
        spawnPoints[2] = new Vector3(0f, 0f, startingZposition);
        spawnPoints[3] = new Vector3(0f, 0f, startingZposition);
        spawnPointsCountArray = new int[spawnPoints.Length];
        for(int i = 0; i < spawnPointsCountArray.Length; i++)
        {
            spawnPointsCountArray[i] = 0;
        }
        lastSpawn = 0;
	}

    private void Update()
    {
        if (Time.time > lastSpawn)
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
                int j = getSpawnIndex();
                spawnPointsCountArray[j]++;
                if (j % 2 == 0)
                {
                    boats[i].tag = "Diag";
                }
                else
                {
                    boats[i].tag = "RDiag";
                }
                boats[i].GetComponent<BoatMover>().target = j;
                boats[i].transform.position = spawnPoints[j];
                boats[i].transform.rotation = Quaternion.identity;
                boats[i].GetComponent<BoatMover>().speed = spawnBoatSpeed;
                boats[i].GetComponent<BoatMover>().spawnManager = this;
                boats[i].SetActive(true);
                break;
            }
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
        int k = Random.Range(1, minCount + 1);
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

}
