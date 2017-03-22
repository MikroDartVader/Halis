using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlying : MonoBehaviour
{
    public float Speed, DestroyTime;
    public int damage;
    public Transform Gun;


    void Start()
    {
        Destroy(gameObject, DestroyTime);
        gameObject.GetComponent<Rigidbody>().velocity = transform.right * Speed;
    }
	
    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.transform.tag);
        if (other.transform != Gun)
        {
            if (other.transform.tag == "Player" || other.transform.tag == "bot" || other.transform.parent != null && (other.transform.parent.tag == "Player" || other.transform.parent.tag == "bot"))
            {
                Destroy(gameObject);

                if (other.gameObject.GetComponent<HealthCounter>() != null)
                    other.gameObject.GetComponent<HealthCounter>().damage(damage);

                if (other.gameObject.transform.parent != null && other.gameObject.transform.parent.GetComponent<HealthCounter>() != null)
                    other.gameObject.transform.parent.GetComponent<HealthCounter>().damage(damage);
            }
            else
                Destroy(gameObject, 0.2f);
        }
    }
}
