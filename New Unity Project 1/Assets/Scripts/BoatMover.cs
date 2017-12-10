using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMover : MonoBehaviour {

    public float speed;
    public Transform target;
    private int m;
    private Rigidbody rb;
	// Use this for initialization
    void OnEnable()
    {
        transform.LookAt(target);
        m = 0;

    }

    
    

    // Update is called once per frame
    void Update () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        //float dir = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 90f + 90f * m, 180.0f * Time.deltaTime);
        //transform.eulerAngles = new Vector3(0, dir, 0);
        //Debug.Log(transform.eulerAngles.y);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Cannon"))
        {
            //Debug.Log("BOOM!");
            gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log("Change Direction");
            m = (m + 1) % 2;
        }

    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
