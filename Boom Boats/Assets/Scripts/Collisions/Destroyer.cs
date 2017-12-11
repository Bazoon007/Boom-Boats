using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour {

    public GameObject ScoreManager;

    private void OnTriggerExit(Collider other)
    {
        int cannonIndex = other.GetComponent<CannonBall>().cannonBallIndex;
        ScoreManager.GetComponent<ScoreManager>().UpdateScore(cannonIndex);

        //Destroy(other.gameObject);
    }
}
