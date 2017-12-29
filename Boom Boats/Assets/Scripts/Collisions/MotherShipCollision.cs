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
