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

    // Use this for initialization
    void OnEnable()
    {
        initTransform();
    }

    // Update is called once per frame
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

        // m = (m + 1) % 2;
        //gameObject.transform.forward = Vector3.RotateTowards(transform.forward,Vector3.Normalize(GameObject.Find("Cannon" + nextTarget).transform.position - transform.position), 30f * Time.deltaTime, 0f);

        targetTransform = GameObject.Find("Cannon" + nextTarget).transform;
        
            //(GameObject.Find("Cannon" + nextTarget).transform);
    }

    void OnDisable()
    {
        spawnManager.removeBoatFromList(target);
        //SpawnManager.getInstance().removeBoatFromList(target);
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
        /*
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        float dirY = Vector3.RotateTowards(transform.eulerAngles.y, (transform.eulerAngles.y + transform.eulerAngles.y * 2f) + 90f * m, 90.0f * Time.deltaTime);
        float dirX = Mathf.MoveTowardsAngle(transform.eulerAngles.x, (transform.eulerAngles.x + transform.eulerAngles.x*  2f) + 90f * m, 90.0f * Time.deltaTime);
        transform.eulerAngles = new Vector3(dirX, dirY, 0);
        */
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        


    }

    public void borderFlip()
    {
        transform.Rotate((Vector3.right * (flipAngle * 2) * flipFlag));
        flipFlag *= -1;
    }

    private void initTransform()
    {
        targetTransform = GameObject.Find("Cannon" + target).transform;
        transform.LookAt(targetTransform);
        transform.Rotate(Vector3.right * flipAngle);
        flipFlag = -1;
    }

    
}
