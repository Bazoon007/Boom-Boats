using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMover : MonoBehaviour {

    public float speed;
    public int target;
    private int m;
    private Rigidbody rb;
	// Use this for initialization
    void OnEnable()
    {
        transform.LookAt(GameObject.Find("Cannon" + target).transform);
        m = 0;
    }

    // Update is called once per frame
    void Update () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        float dir = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 60f + 120f * m, 180.0f * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, dir, transform.eulerAngles.z);
        Debug.Log(transform.eulerAngles.y);

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
        SpawnManager.getInstance().spawnPointsCountArray[target - 1]--;
        CancelInvoke();
    }
}
