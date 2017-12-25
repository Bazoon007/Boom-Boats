using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampBorderCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Boat") && other.tag != "BoatAfterHit")
        {
            if (CompareTag(other.tag))
            {
                if (!other.gameObject.GetComponent<BoatMover>().isFlipping)
                {
                    other.gameObject.GetComponent<BoatMover>().borderFlip();
                }
            }
            
        }
        else if (other.tag == "Cannonball")
        {
            if (other.gameObject.GetComponent<CannonBall>().cannonBallIndex == 0 
                ||  other.gameObject.GetComponent<CannonBall>().cannonBallIndex == 2)
            {
                if (this.tag == "Diag")
                {
                    Destroy(other.gameObject);
                }
            }
            else
            {
                if (this.tag == "RDiag")
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
