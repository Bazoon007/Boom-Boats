using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCannonBallCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cannon")
        {
            // Debug.Log("Hit Cannon " + other.GetComponent<MoveLeftRight>().location);
            other.GetComponent<CannonHealth>().ReduceCannonHealth();
            deactivate(); ;
        }
        else if (other.tag == "Cannonball")
        {
            //Debug.Log("Boom");
            gameObject.GetComponent<BoatHealth>().reduceBoatHealth();
            if (gameObject.GetComponent<BoatHealth>().healthPoints < 1)
            {
                gameObject.GetComponent<BoatMover>().spawnManager.IncreaseNumberOfDestroyedBoats();
                gameObject.tag = "BoatAfterHit";
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
