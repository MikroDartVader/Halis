using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed;
    public float VisibleDistance,UnvisibleDistance;

    private Transform myTrasform;
    private bool TargetDetected;

    void Awake()
    {
        myTrasform = transform;
    }

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        TargetDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetDetected == false && (target.position - myTrasform.position).magnitude <= VisibleDistance)
            TargetDetected = true;
        else if(TargetDetected==true && (target.position - myTrasform.position).magnitude > UnvisibleDistance)
            TargetDetected = false;
        //look at target
        if (TargetDetected)
        {
            Vector3 RotatateTo = new Vector3((target.position - myTrasform.position).x, 0, (target.position - myTrasform.position).z);
            myTrasform.rotation = Quaternion.Slerp(myTrasform.rotation, Quaternion.LookRotation(RotatateTo), rotationSpeed * Time.deltaTime);
        }
    }
}
