using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCannonBallCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cannon")
        {
            Debug.Log("Hit Cannon " + other.GetComponent<MoveLeftRight>().location);
            gameObject.SetActive(false);
        }
        else if (other.tag == "Cannonball")
        {
            Debug.Log("Boom");
            GetComponent<BoatMover>().ChangeDirection();
            Destroy(other.gameObject);
        }

    }
}
