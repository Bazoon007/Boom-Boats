using UnityEngine;

public class CampBorderCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (isBoatBeforeHit(other))
        {
            flipBoat(other);

        }
        else if (other.tag == "Cannonball")
        {
            destroyOtherByTag(other);
        }
    }

    private void flipBoat(Collider other)
    {
        if (CompareTag(other.tag))
        {
            if (!other.gameObject.GetComponent<BoatMover>().isFlipping)
            {
                other.gameObject.GetComponent<BoatMover>().BorderFlip();
            }
        }
    }

    private void destroyOtherByTag(Collider other)
    {
        if (cannonballTargetIndexIsEven(other))
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

    private static bool cannonballTargetIndexIsEven(Collider other)
    {
        return other.gameObject.GetComponent<CannonBall>().cannonBallIndex == 0
                        || other.gameObject.GetComponent<CannonBall>().cannonBallIndex == 2;
    }

    private static bool isBoatBeforeHit(Collider other)
    {
        return other.name.Contains("Boat") && other.tag != "BoatAfterHit";
    }
}
