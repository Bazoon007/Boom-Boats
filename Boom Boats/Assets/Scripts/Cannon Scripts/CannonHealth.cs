using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonHealth : MonoBehaviour {

    private int health;
    public int initialHealth;

    private void Start()
    {
        health = initialHealth;
    }

    public void ReduceCannonHealth()
    {
        health--;
        if (health == 0)
        {
            //gameObject.SetActive(false);
        }
    }
}
