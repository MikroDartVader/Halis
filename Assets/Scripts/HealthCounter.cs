using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCounter: MonoBehaviour
{
    public int Health;


    public void damage(int val)
    {
        Health -= val;
        if (Health <= 0)
        {
            Health = 0;
            if (gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
                Destroy(gameObject);
        }
    }
}

