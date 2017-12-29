using UnityEngine;

public class BoatCannonBallCollider : MonoBehaviour {

    public MasterManager MasterManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Island")
        {
            triggerIfIsland(other);
        }
        else if (other.tag == "Cannonball")
        {
            triggerIfCcanonball(other);
        }
        else if (other.tag == "BoatAfterHit" && gameObject.tag == "BoatAfterHit")
        {
            triggerIfBoatsAfterHit();
        }
    }

    private void triggerIfBoatsAfterHit()
    {
        GetComponent<BoatMover>().ChangeDirection(true);
    }

    private void triggerIfCcanonball(Collider other)
    {
        int target = gameObject.GetComponent<BoatMover>().orignialTarget;
        bool isBoatFlipping = gameObject.GetComponent<BoatMover>().isFlipping;

        if (sameTargetOrBoatIsNotFlipping(other, target, isBoatFlipping))
        {
            gameObject.GetComponent<BoatHealth>().reduceBoatHealth();

            if (boatIsDead())
            {
                MasterManager.scoreManager.UpdateScore(other.GetComponent<CannonBall>().cannonBallIndex);
                deactivate();
            }
            else
            {
                changeBoatDirection();
            }
        }

        Destroy(other.gameObject);
    }

    private void changeBoatDirection()
    {
        gameObject.tag = "BoatAfterHit";
        GetComponent<BoatMover>().ChangeDirection(false);
    }

    private bool boatIsDead()
    {
        return gameObject.GetComponent<BoatHealth>().healthPoints < 1;
    }

    private static bool sameTargetOrBoatIsNotFlipping(Collider other, int target, bool isBoatFlipping)
    {
        return target == other.gameObject.GetComponent<CannonBall>().cannonBallIndex || !isBoatFlipping;
    }

    private void triggerIfIsland(Collider other)
    {
        other.GetComponent<IslandHealth>().ReduceIslandHealth();
        deactivate();
    }

    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}
