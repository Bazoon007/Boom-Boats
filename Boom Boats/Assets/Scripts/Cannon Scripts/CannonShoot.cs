using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour {

    public float speed;
    public float tilt;

    public GameObject cannonBall;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    void OnTouchExit()
    {
        Shoot();
    }


    private void OnMouseDown()
    {
        Shoot();
    }


    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject go = Instantiate(cannonBall, shotSpawn.position, shotSpawn.rotation);

            go.GetComponent<CannonBall>().cannonBallIndex = this.GetComponent<Cannon>().location;
        }
    }
}


