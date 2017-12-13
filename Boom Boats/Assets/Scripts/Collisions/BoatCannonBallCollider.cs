using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCannonBallCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cannon")
        {
           // Debug.Log("Hit Cannon " + other.GetComponent<MoveLeftRight>().location);
            deactivate(); ;
        }
        else if (other.tag == "Cannonball")
        {
            //Debug.Log("Boom");
            gameObject.GetComponent<BoatHealth>().reductBoatHealth();
            if (gameObject.GetComponent<BoatHealth>().healthPoints < 1)
            {
                gameObject.GetComponent<BoatMover>().spawnManager.IncreaseNumberOfDestroyedBoats();
                deactivate();
            }
            else
            {
                GetComponent<BoatMover>().ChangeDirection();
            }

            Destroy(other.gameObject);
        }

    }

    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}
