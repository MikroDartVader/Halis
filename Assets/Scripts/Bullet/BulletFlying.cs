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
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.position += Speed * Time.deltaTime * transform.right;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform != Gun)
        {
            Destroy(gameObject, 0.01f);
            if (other.gameObject.GetComponent<HealthCounter>() != null)
                other.gameObject.GetComponent<HealthCounter>().damage(damage);

            if (other.gameObject.transform.parent != null && other.gameObject.transform.parent.GetComponent<HealthCounter>() != null)
                other.gameObject.transform.parent.GetComponent<HealthCounter>().damage(damage);
        }
    }
}
