using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMover : MonoBehaviour {

    public float speed;
    public float startingXPosition;
    public float endingXPosition;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(startingXPosition, 0f, 20f);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed * -1;
	}
	
	// Update is called once per frame
	void Update () {


		if (this.transform.position.x <= endingXPosition)
        {
            resetPosition();
        }
	}

    private void resetPosition()
    {
        transform.position = new Vector3(startingXPosition, 0f, 20f);
    }
}
