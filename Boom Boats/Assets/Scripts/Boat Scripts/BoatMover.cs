using System.Collections;
using UnityEngine;

public class BoatMover : MonoBehaviour
{

    public MasterManager masterManager;
    public int orignialTarget;
    public bool isFlipping;
    public float movementSpeed;
    public float rotationSpeed;
    public float flipAngle;
    public float flipSpeed;

    public int nextTarget;
    private Transform targetTransform;
    private int flipFlag;

    private void OnEnable()
    {
        initTransform();
        nextTarget = orignialTarget;
    }

    private void Update()
    {
        selectMovementType();

        transform.GetChild(0).localRotation = flipIfNeeded(transform.GetChild(0).localRotation);
    }

    public void ChangeDirection(bool colidedBoat)
    {
        int targetIndex;

        targetIndex = selectTargetIndex(colidedBoat);
        selectNextTarget(targetIndex);

        targetTransform = GameObject.Find("Cannon" + nextTarget).transform;
        updateSpawnPointsOnChange(targetIndex);
    }

    public void BorderFlip()
    {
        StartCoroutine(rotateCoroutine());
        flipFlag *= -1;
    }

    private void updateSpawnPointsOnChange(int target)
    {
        masterManager.spawnManager.RemoveBoatFromList(target);
        masterManager.spawnManager.addBoatToList(nextTarget);
    }

    private void OnDisable()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        masterManager.spawnManager.RemoveBoatFromList(nextTarget);
    }

    private void damagedMovement()
    {
        Vector3 normallizedTarget = Vector3.Normalize(targetTransform.position - transform.position);
        transform.forward = Vector3.RotateTowards(transform.forward, normallizedTarget, rotationSpeed * Time.deltaTime, movementSpeed);
        GetComponent<Rigidbody>().velocity = transform.forward * movementSpeed;
    }

    private void sailingMovement()
    {
        if (isFlipping)
        {
            transform.Rotate(Vector3.right * (flipAngle * 2) * flipFlag * Time.deltaTime * flipSpeed * movementSpeed);
        }

        GetComponent<Rigidbody>().velocity = transform.forward * movementSpeed;
    }

    private void initTransform()
    {
        targetTransform = GameObject.Find("Cannon" + orignialTarget).transform;
        transform.LookAt(targetTransform);
        transform.Rotate(flipAngle * Vector3.right);
        flipFlag = 1;
        isFlipping = false;
    }

    private void selectMovementType()
    {
        if (masterManager.IsGameRunning())
        {
            if (gameObject.tag == "BoatAfterHit")
            {
                damagedMovement();
            }
            else
            {
                sailingMovement();
            }
        }
    }

    private Quaternion flipIfNeeded(Quaternion childLocalTransform)
    {
        if (tag == "BoatAfterHit")
        {
            childLocalTransform = flipAfterHit(childLocalTransform);
        }
        else
        {
            childLocalTransform = flipBeforeHit(childLocalTransform);
        }
        return childLocalTransform;
    }

    public Quaternion flipAfterHit(Quaternion childLocalTransform)
    {

        if (orignialTarget == 0 || orignialTarget == 3)
        {
            if (nextTarget == 1 || nextTarget == 2)
            {
                childLocalTransform = Quaternion.Euler(0f, 90f, 90f);
            }
        }
        else
        {
            if (nextTarget == 0 || nextTarget == 3)
            {
                childLocalTransform = Quaternion.Euler(0f, -90f, -90f);
            }
        }

        return childLocalTransform;
    }

    private Quaternion flipBeforeHit(Quaternion childLocalTransform)
    {
        if (needToFlipBeforeHit())
        {
            if (orignialTarget == 0 || orignialTarget == 3)
            {
                childLocalTransform = Quaternion.Euler(0f, -90f, -90f);
            }
        }
        else
        {
            if (orignialTarget == 1 || orignialTarget == 2)
            {
                childLocalTransform = Quaternion.Euler(0f, 90f, 90f);
            }
        }

        return childLocalTransform;
    }

    private bool needToFlipAfterHit()
    {
        return (transform.GetChild(0).localRotation.x > 0 || transform.GetChild(0).localRotation.y > 0) && gameObject.tag == "BoatAfterHit";
    }

    private bool needToFlipBeforeHit()
    {
        return (transform.rotation.x < 0 || transform.rotation.y < 0) && gameObject.tag != "BoatAfterHit";
    }

    private void selectNextTarget(int targetIndex)
    {
        if (Random.Range(-1, 1) < 0)
        {
            selectNextTargetSmallerThanZero(targetIndex);
        }
        else
        {
            selectNextTargetLargerThanZero(targetIndex);
        }
    }

    private void selectNextTargetLargerThanZero(int targetIndex)
    {
        nextTarget = (targetIndex + 1) % 4;
        while (masterManager.spawnManager.spawnPointsCountArray[nextTarget] == int.MaxValue)
        {
            nextTarget = (nextTarget + 1) % 4;
        }
    }

    private void selectNextTargetSmallerThanZero(int targetIndex)
    {
        nextTarget = targetIndex - 1;
        if (nextTarget < 0)
        {
            nextTarget = 3;
        }

        while (masterManager.spawnManager.spawnPointsCountArray[nextTarget] == int.MaxValue)
        {
            nextTarget = nextTarget - 1;
            if (nextTarget < 0)
            {
                nextTarget = 3;
            }
        }
    }

    private int selectTargetIndex(bool colidedBoat)
    {
        int targetIndex;
        if (colidedBoat)
        {
            targetIndex = nextTarget;
        }
        else
        {
            targetIndex = orignialTarget;
        }

        return targetIndex;
    }

    IEnumerator rotateCoroutine()
    {
        isFlipping = true;
        yield return new WaitForSeconds(1 / (flipSpeed * movementSpeed));
        isFlipping = false;
    }
}
