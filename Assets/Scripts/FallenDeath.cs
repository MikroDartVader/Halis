using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenDeath : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<HealthCounter>() != null)
            other.gameObject.GetComponent<HealthCounter>().damage(other.gameObject.GetComponent<HealthCounter>().Health);       
    }
}
