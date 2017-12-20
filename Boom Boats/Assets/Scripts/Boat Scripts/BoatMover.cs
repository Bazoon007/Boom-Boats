using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMover : MonoBehaviour {

    public float speed;
    public int target;
    public SpawnManager spawnManager;
    private int flipFlag;
    private Rigidbody rb;
    public float rotationSpeed;
    private Transform targetTransform;
    public float flipAngle;
    public bool isFlipping;
    public float flipSpeed;

    void OnEnable()
    {
        initTransform();
    }

    void Update () {
        if (gameObject.tag == "BoatAfterHit")
        {
            damagedMovement();
        }
        else
        {
            sailingMovement();
        }

    }

    public void ChangeDirection()
    {
        int nextTarget;

        if (Random.Range(-1, 1) < 0)
        {
            nextTarget = target - 1;
            if (nextTarget < 0)
            {
                nextTarget = 3;
            }

            while (spawnManager.spawnPointsCountArray[nextTarget] == int.MaxValue)
            {
                nextTarget = nextTarget - 1;
                if (nextTarget < 0)
                {
                    nextTarget = 3;
                }
            } 
        }
        else
        {
            nextTarget = (target + 1) % 4;
            while (spawnManager.spawnPointsCountArray[nextTarget] == int.MaxValue) 
            {
                nextTarget = (nextTarget + 1) % 4;
            }
        }
        targetTransform = GameObject.Find("Cannon" + nextTarget).transform;
    }

    void OnDisable()
    {
        spawnManager.removeBoatFromList(target);
        CancelInvoke();
    }

    private void damagedMovement() 
    {
        Vector3 normallizedTarget = Vector3.Normalize(targetTransform.position - transform.position);
        transform.forward = Vector3.RotateTowards(transform.forward, normallizedTarget, rotationSpeed * Time.deltaTime, speed);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void sailingMovement()
    {
        if (isFlipping)
        {
            transform.Rotate(Vector3.right * (flipAngle * 2) * flipFlag * Time.deltaTime * flipSpeed * speed);
        }
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        


    }

    public void borderFlip()
    {
        StartCoroutine(rotateCoroutine());
        flipFlag *= -1;
    }

    private void initTransform()
    {
        targetTransform = GameObject.Find("Cannon" + target).transform;
        transform.LookAt(targetTransform);
        transform.Rotate(flipAngle * Vector3.right);
        flipFlag = 1;
        isFlipping = false;
    }

    IEnumerator rotateCoroutine()
    {
        isFlipping = true;
        yield return new WaitForSeconds(1/(flipSpeed * speed));
        isFlipping = false;
    }

    
}
