﻿using UnityEngine;

public class BoatHealth : MonoBehaviour {

    public int healthPoints;

    public void setBoatHealth(int health)
    {
        healthPoints = health;
    }

    public void reduceBoatHealth()
    {
        healthPoints--;
    }
}
