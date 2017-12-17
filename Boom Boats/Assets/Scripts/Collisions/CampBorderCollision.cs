using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampBorderCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag(other.tag))
        {
            Debug.Log("FLIP!");
            other.gameObject.GetComponent<BoatMover>().borderFlip();
        }
    }
}
