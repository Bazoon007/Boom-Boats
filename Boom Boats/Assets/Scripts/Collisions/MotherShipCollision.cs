using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cannonball")
        {
            Destroy(other.gameObject);
        }
    }
}
