using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateX : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed;
    public float VisibleDistance,UnvisibleDistance;
    public bool TargetDetected;

    private Transform myTrasform;

    void Awake()
    {
        myTrasform = transform;
    }

    // Use this for initialization
    void Start()
    {
        TargetDetected = false;
    }

    // Update is called once per frame
    void Update()
    {

        //look at target

            //look at target
        if (TargetDetected)
        {
            Vector3 RotatateTo = new Vector3((target.position - myTrasform.position).x, (target.position - myTrasform.position).y, (target.position - myTrasform.position).z);
            myTrasform.rotation = Quaternion.Slerp(myTrasform.rotation, Quaternion.LookRotation(RotatateTo), rotationSpeed * Time.deltaTime);
        }
    }
}
