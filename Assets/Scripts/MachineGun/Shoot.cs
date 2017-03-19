using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform Bullet;
    public Transform target;
    public float ShootingSpeed;
    public float UnvisibleDistance;
    public bool TargetDetected;
    public float BulletSpeed, BulletDestroyTime;

    private float ShootTimer, StartTime;
    private Transform go;
    private RaycastHit[] hits;


	
    // Update is called once per frame
    void Update()
    {
        hits = Physics.RaycastAll(transform.position, target.position - transform.position, (target.position - transform.position).magnitude);
        //Debug.Log(hits[0].transform.name);
        if (hits.Length!=0)
        {
            if (Time.time - StartTime > ShootingSpeed && TargetDetected && hits[0].transform.Equals(target.transform))
            {
                StartTime = Time.time;
                go = Instantiate(Bullet, transform.position, transform.rotation);
                go.GetComponent<BulletFlying>().Gun = transform.parent;
                go.GetComponent<BulletFlying>().Speed = BulletSpeed;
            }
        }
    }
}