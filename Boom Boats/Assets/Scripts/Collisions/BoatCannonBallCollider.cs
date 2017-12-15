using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCannonBallCollider : MonoBehaviour {

    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Island")
        {
            // Debug.Log("Hit Cannon " + other.GetComponent<MoveLeftRight>().location);
            other.GetComponent<IslandHealth>().ReduceIslandHealth();
            deactivate(); 
        }
        else if (other.tag == "Cannonball")
        {
            //Debug.Log("Boom");
            gameObject.GetComponent<BoatHealth>().reduceBoatHealth();
            if (gameObject.GetComponent<BoatHealth>().healthPoints < 1)
            {
                gameObject.tag = "BoatAfterHit";
                scoreManager.UpdateScore(other.GetComponent<CannonBall>().cannonBallIndex);
                deactivate();
            }
            else
            {
                GetComponent<BoatMover>().ChangeDirection();
            }

            Destroy(other.gameObject);
        }
        else if (other.tag == "BoatAfterHit")
        {
            GetComponent<BoatMover>().ChangeDirection();
        }

    }

    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}
