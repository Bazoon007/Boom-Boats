using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cannonball")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "Diag" || other.tag == "RDiag")
        {
            other.gameObject.SetActive(false);
        }
    }
}
