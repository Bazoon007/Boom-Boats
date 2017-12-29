using UnityEngine;

public class BorderCollision : MonoBehaviour {

    protected void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cannonball")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "BoatAfterHit" || other.tag == "Diag" || other.tag == "RDiag") {
            other.gameObject.SetActive(false);
        }
    }

}
