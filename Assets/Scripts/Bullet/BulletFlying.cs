using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlying : MonoBehaviour
{
    public float Speed, DestroyTime;
    // Use this for initialization
    void Awake()
    {
    }

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.position += Speed * Time.deltaTime * transform.forward;
    }

    void OnCollisionEnter(Collision other)
    {
         if (other.gameObject.name != "Gun")
        Destroy(gameObject,0);
    }
}
