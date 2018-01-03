using System;
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
        if (Time.time > nextFire && GetComponent<Cannon>().MasterManager.IsGameRunning())
        {
            nextFire = Time.time + fireRate;
            instantiateCannonball();
            playSound();
        }
    }

    private void playSound()
    {
        MasterManager masterManager = GetComponent<Cannon>().MasterManager;
        int cannonIndex = GetComponent<Cannon>().CannonIndex;
        masterManager.soundManager.PlayCannonShootSound(cannonIndex);
    }

    private void instantiateCannonball()
    {
        GameObject newCannonball = Instantiate(cannonBall, shotSpawn.position, shotSpawn.rotation);
        newCannonball.GetComponent<CannonBall>().cannonBallIndex = GetComponent<Cannon>().CannonIndex;
    }
}


