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
    //private Vector3 rotateVector;
    //private bool firstFlip;
    public bool isFlipping;
    //private float startRotationX;
    //private float endRotationX;
    public float flipSpeed;
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
        if (rotateVector != Vector3.zero)
        {
           Vector3 dir = Vector3.RotateTowards(transform.forward, rotateVector, rotationSpeed * Time.deltaTime, speed);
           transform.rotation = Quaternion.LookRotation(dir);
        }
        */
        if (isFlipping)
        {
            transform.Rotate(Vector3.right * (flipAngle * 2) * flipFlag * Time.deltaTime * flipSpeed);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x + (360 + flipFlag * flipAngle * 2) % 360, transform.eulerAngles.y, transform.eulerAngles.z), Time.deltaTime * 50);
            /*
            //Debug.Log(Mathf.Abs(startRotationX - transform.rotation.x));
            if(Mathf.Abs(endRotationX - transform.eulerAngles.x) > 1f)
            {
                transform.Rotate(flipFlag * flipAngle * 2 * Vector3.right * Time.deltaTime);
                Debug.Log(transform.eulerAngles.x);
            }
            else
            {
                Debug.Log("STOP!");
                isFlipping = false;
            }
            */
        }
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        


    }

    public void borderFlip()
    {
        Debug.Log("Flip");
        //endRotationX = (transform.eulerAngles.x + (360 + flipFlag * flipAngle * 2)) % 360;
        StartCoroutine(rotateCoroutine());
        //transform.Rotate((Vector3.right * (flipAngle * 2) * flipFlag));
        //rotateVector = Matrix4x4.Rotate(Quaternion.Euler(flipFlag * (flipAngle * 2), 0, 0)).MultiplyVector(Vector3.Normalize(transform.forward));
        flipFlag *= -1;
    }

    private void initTransform()
    {
        targetTransform = GameObject.Find("Cannon" + target).transform;
        transform.LookAt(targetTransform);
        transform.Rotate(flipAngle * Vector3.right);
        flipFlag = 1;
        //firstFlip = true;
        isFlipping = false;
        //rotateVector = Vector3.zero;
    }

    IEnumerator rotateCoroutine()
    {
        Debug.Log("Start");
        isFlipping = true;
        yield return new WaitForSeconds(1);
        isFlipping = false;
        Debug.Log("BOOM");
    }

    
}
