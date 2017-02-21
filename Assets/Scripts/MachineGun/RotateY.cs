using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed;

    private Transform myTrasform;

    void Awake()
    {
        myTrasform = transform;
    }

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.DrawLine(myTrasform.position, target.position, Color.blue);
        //look at target
        Vector3 RotatateTo = new Vector3((target.position - myTrasform.position).x, 0, (target.position - myTrasform.position).z);
        myTrasform.rotation = Quaternion.Slerp(myTrasform.rotation, Quaternion.LookRotation(RotatateTo), rotationSpeed * Time.deltaTime);
    }
}
