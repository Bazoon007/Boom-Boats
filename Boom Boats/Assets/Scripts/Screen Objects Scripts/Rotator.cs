using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed;
    public MasterManager masterManager;

	void Update ()
    {
        if (masterManager.IsGameRunning())
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
}
