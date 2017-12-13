using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMover : MonoBehaviour {

    public float speed;
    public int target;
    public SpawnManager spawnManager;
    private int m;
    private Rigidbody rb;
    public float rotationSpeed;

    private Transform targetTransform;

	// Use this for initialization
    void OnEnable()
    {

        targetTransform = GameObject.Find("Cannon" + target).transform;
        
        m = 0;
    }

    // Update is called once per frame
    void Update () {

        Vector3 normallizedTarget = Vector3.Normalize(targetTransform.position - transform.position);

        transform.forward = Vector3.RotateTowards(transform.forward, normallizedTarget, rotationSpeed * Time.deltaTime, speed);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //float dir = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 90f + 90f * m, 180.0f * Time.deltaTime);
        //transform.eulerAngles = new Vector3(0, dir, 0);
        //Debug.Log(transform.eulerAngles.y);

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
        }
        else
        {
            nextTarget = (target + 1) % 4;
        }

        //m = (m + 1) % 2;
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
}
