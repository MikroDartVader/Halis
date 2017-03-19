using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter: MonoBehaviour
    {
    public int Health;

    bool Alive=true;

    public void damage(int val)
    {
        Health -= val;
        if (Health <= 0)
        {
            Health = 0;
            Alive = false;
            Destroy(gameObject);
        }
    }
    }

