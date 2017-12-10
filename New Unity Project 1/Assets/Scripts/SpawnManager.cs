using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public float spawnTime;
    public int maxBoats;
    public GameObject[] boats;
    public GameObject boat;
    public Vector3[] spawnPoints;
    public int[] spawnPointsCountArray;
    public ProbTuple[] probRange;
    public class ProbTuple
    {
        int min;
        int max;
        public ProbTuple(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public int Min
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
            }
        }
        public int Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
            }
        }

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
        spawnPoints[0] = new Vector3(1, 0.5f, -1);
        spawnPoints[1] = new Vector3(-1, 0.5f, -1);
        spawnPoints[2] = new Vector3(-1, 0.5f, 1);
        spawnPoints[3] = new Vector3(1, 0.5f, 1);
        spawnPointsCountArray = new int[spawnPoints.Length];
        for(int i = 0; i < spawnPointsCountArray.Length; i++)
        {
            spawnPointsCountArray[i] = maxBoats / spawnPointsCountArray.Length;
        }
        probRange = new ProbTuple[spawnPointsCountArray.Length];
        probRange[0] = new ProbTuple(0, 25);
        probRange[1] = new ProbTuple(25, 50);
        probRange[2] = new ProbTuple(50, 75);
        probRange[3] = new ProbTuple(75, 100);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
    
    void Spawn()
    {
        for(int i = 0; i < boats.Length; i++)
        {
            if(!boats[i].activeInHierarchy)
            {
                int j = getSpawnPoint(Random.Range(0,100));
                if(j == 4)
                {
                    j = 3;
                }
                spawnPointsCountArray[j]--;
                if (j % 2 == 0)
                {
                    boats[i].tag = "Diag";
                }
                else
                {
                    boats[i].tag = "RDiag";
                }
                boats[i].GetComponent<BoatMover>().target = GameObject.Find("Cannon" + (j + 1)).transform;
                boats[i].transform.position = spawnPoints[j];
                boats[i].transform.rotation = Quaternion.identity;
                boats[i].SetActive(true);
                break;
            }
        }
    }

    private void updateProb()
    {

    }

    private int getSpawnPoint(int n)
    {
        for(int i = 0; i < probRange.Length; i++)
        {
            if (n >= probRange[i].Min && n <= probRange[i].Max)
                return i;
        }
        return -1;
    }
}
