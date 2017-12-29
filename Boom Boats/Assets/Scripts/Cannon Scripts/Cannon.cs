using UnityEngine;

public class Cannon : MonoBehaviour {
    public float RotationSpeed;
    public float RotationLimit;
    public int CannonIndex;
    public MasterManager MasterManager;

    private float startingXRotation;
    private float startingYRotation;

    void Start () {
        startingXRotation = transform.rotation.x;
        startingYRotation = transform.rotation.y;
	}
	
	void Update () {
        if (MasterManager.IsGameRunning())
        {
            transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
            setRotationSpeed();
        }
    }

    private void setRotationSpeed()
    {
        if (CannonIndex == 1)
        {
            flipRotationSpeedBasedOnY();
        }
        else
        {
            flipRotationSpeedBasedOnX();
        }

    }

    private void flipRotationSpeedBasedOnX()
    {
        if (RotationSpeed > 0)
        {
            if (transform.rotation.x > startingXRotation + RotationLimit)
            {
                RotationSpeed *= -1;
            }
        }
        else
        {
            if (transform.rotation.x < startingXRotation - RotationLimit)
            {
                RotationSpeed *= -1;
            }
        }
    }

    private void flipRotationSpeedBasedOnY()
    {
        if (RotationSpeed > 0)
        {
            if (transform.rotation.y < startingYRotation - RotationLimit)
            {
                RotationSpeed *= -1;
            }
        }
        else
        {
            if (transform.rotation.y > startingYRotation + RotationLimit)
            {
                RotationSpeed *= -1;
            }
        }
    }
}
