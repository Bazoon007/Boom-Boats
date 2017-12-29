using UnityEngine;

public class CannonShoot : MonoBehaviour {

    public GameObject cannonBall;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    void OnTouchExit()
    {
        shoot();
    }

    private void OnMouseDown()
    {
        OnTouchExit();
    }

    private void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            instantiateCannonball();
        }
    }

    private void instantiateCannonball()
    {
        GameObject newCannonball = Instantiate(cannonBall, shotSpawn.position, shotSpawn.rotation);
        newCannonball.GetComponent<CannonBall>().cannonBallIndex = GetComponent<Cannon>().CannonIndex;
    }
}


