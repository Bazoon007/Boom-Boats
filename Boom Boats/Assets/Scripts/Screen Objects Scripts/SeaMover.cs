using UnityEngine;

public class SeaMover : MonoBehaviour {

    public float speed;
    public float startingXPosition;
    public float endingXPosition;

	void Start ()
    {
        resetPosition();
        GetComponent<Rigidbody>().velocity = transform.right * speed * -1;
	}
	
	void Update ()
    {
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
