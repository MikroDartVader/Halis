using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGanConfig : MonoBehaviour
{

    public Transform Bullet;
    public Transform Target;
    public GameObject Body, Gun, BulletSpawn;
    public float RotateSpeed;
    public float VisibleDistance, UnvisibleDistance;
    public float ShootsPerSecond;
    public float BulletSpeed, BulletDestroyTime;

    public bool TargetDetected;
    private Shoot Shoot;
    private RotateX X;
    private RotateY Y;

    // Use this for initialization
    void Start()
    {
        if (Target == null)
            Target = GameObject.FindGameObjectWithTag("Player").transform;

        Y = Body.GetComponent<RotateY>();
        X = Gun.GetComponent<RotateX>();
        Shoot = BulletSpawn.GetComponent<Shoot>();

        X.rotationSpeed = RotateSpeed;
        Y.rotationSpeed = RotateSpeed;

        X.VisibleDistance = VisibleDistance;
        Y.VisibleDistance = VisibleDistance;

        X.UnvisibleDistance = UnvisibleDistance;
        Y.UnvisibleDistance = UnvisibleDistance;
        Shoot.UnvisibleDistance = UnvisibleDistance;

        Shoot.Bullet = Bullet;

        Shoot.ShootingSpeed = 1f / ShootsPerSecond;

        X.target = Target;
        Y.target = Target;
        Shoot.target = Target;

        Shoot.BulletDestroyTime = BulletDestroyTime;
        Shoot.BulletSpeed = BulletSpeed;
    }
	
    // Update is called once per frame
    void Update()
    {

        if (TargetDetected == false && (Target.position - transform.position).magnitude <= VisibleDistance)
        {
            TargetDetected = true;
            X.TargetDetected = TargetDetected;
            Y.TargetDetected = TargetDetected;
            Shoot.TargetDetected = TargetDetected;
        }
        else if (TargetDetected == true && (Target.position - transform.position).magnitude > UnvisibleDistance)
        {
            TargetDetected = false;
            X.TargetDetected = TargetDetected;
            Y.TargetDetected = TargetDetected;
            Shoot.TargetDetected = TargetDetected;
        }

    }
}
