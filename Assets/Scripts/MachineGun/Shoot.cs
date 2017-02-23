using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform Bullet;
    public Transform target;
    public float ShootingSpeed;
    public int BulletSpeed;
    public float VisibleDistance,UnvisibleDistance;

    private float ShootTimer, StartTime;    
    private bool TargetDetected;

    // Use this for initialization
    void Start()
    {
		
        ShootingSpeed = 1 / ShootingSpeed; //from shoot/sec -> to sec/shoot
    
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        TargetDetected = false;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (TargetDetected == false && (target.position - transform.position).magnitude <= VisibleDistance)
            TargetDetected = true;
        else if(TargetDetected==true && (target.position - transform.position).magnitude > UnvisibleDistance)
            TargetDetected = false;
        
        if (Time.realtimeSinceStartup - StartTime > ShootingSpeed && TargetDetected)
        {
            StartTime = Time.realtimeSinceStartup;
            Instantiate(Bullet, transform.position, transform.rotation);  
        }
    }
}