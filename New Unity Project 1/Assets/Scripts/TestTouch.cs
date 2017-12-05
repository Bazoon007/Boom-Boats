using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{
    public float speed;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    void OnTouchDown()
    {
        Shoot();
    }
    /*
    private void OnMouseDown()
    {
        Shoot();
    }
    */
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
