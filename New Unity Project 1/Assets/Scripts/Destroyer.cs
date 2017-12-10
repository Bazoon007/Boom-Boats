using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Boat"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Boat Out of Bounds");
        }
        else
            Destroy(other.gameObject);
    }
}
