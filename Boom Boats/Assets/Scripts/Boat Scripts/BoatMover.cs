using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMover : MonoBehaviour {

    public float speed;
    public int orignialTarget;
    private int flipFlag;
    private Rigidbody rb;
    public float rotationSpeed;
    private Transform targetTransform;
    public float flipAngle;
    public bool isFlipping;
    public float flipSpeed;
    public MasterManager masterManager;

    private int nextTarget;

    void OnEnable()
    {
        initTransform();
        nextTarget = orignialTarget;
    }

    void Update () {
        if (masterManager.IsGameRunning())
        {
            Time.timeScale = 1;
            if (gameObject.tag == "BoatAfterHit")
            {
                damagedMovement();
            }
            else
            {
                sailingMovement();
            }
        }
        else
        {
            Time.timeScale = 0;
        }

        if ((transform.rotation.x < 0 || transform.rotation.y < 0) && gameObject.tag != "BoatAfterHit")
        {
            if (orignialTarget == 0 || orignialTarget == 3)
            {
                transform.GetChild(0).localRotation = Quaternion.Euler(0f, -90f, -90f);
            }
        }
        else
        {
            if (orignialTarget == 1 || orignialTarget == 2)
            {
                transform.GetChild(0).localRotation = Quaternion.Euler(0f, 90f, 90f);
            }
        }
    
        if ((transform.GetChild(0).localRotation.x > 0 || transform.GetChild(0).localRotation.y > 0) && gameObject.tag == "BoatAfterHit")
        {
            if (orignialTarget == 0 || orignialTarget == 3)
            {
                transform.GetChild(0).localRotation = Quaternion.Euler(0f, -90f, -90f);
            }
        }
        else
        {
            if (orignialTarget == 1 || orignialTarget == 2)
            {
                transform.GetChild(0).localRotation = Quaternion.Euler(0f, 90f, 90f);
            }

           
        }





    }

    public void ChangeDirection(bool colidedBoat)
    {
        int t;
        if (colidedBoat)
        {
            t = nextTarget;
        }
        else
        {
            t = orignialTarget;
        }
        if (Random.Range(-1, 1) < 0)
        {
            nextTarget = t - 1;
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
        else
        {
            nextTarget = (t + 1) % 4;
            while (masterManager.spawnManager.spawnPointsCountArray[nextTarget] == int.MaxValue)
            {
                nextTarget = (nextTarget + 1) % 4;
            }
        }
        targetTransform = GameObject.Find("Cannon" + nextTarget).transform;
        updateSpawnPointsOnChange(t);

    }

    private void updateSpawnPointsOnChange(int t)
    {
        masterManager.spawnManager.removeBoatFromList(t);
        masterManager.spawnManager.addBoatToList(nextTarget);
    }

    void OnDisable()
    {
        masterManager.spawnManager.removeBoatFromList(nextTarget);
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
        targetTransform = GameObject.Find("Cannon" + orignialTarget).transform;
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
