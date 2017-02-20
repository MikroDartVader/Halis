using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadMove : MonoBehaviour
{

	public Transform target;
	public float moveSpeed;
	public float rotationSpeed;
	public float distance;

	private Transform myTrasform;

	void Awake ()
	{
		myTrasform = transform;
	}

	// Use this for initialization
	void Start ()
	{
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		moveSpeed = 1;
		rotationSpeed = 10;
		distance = 5;
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.DrawLine (myTrasform.position, target.position, Color.black);

		//look at target
		myTrasform.rotation = Quaternion.Slerp (myTrasform.rotation, Quaternion.LookRotation (target.position - myTrasform.position), rotationSpeed * Time.deltaTime);

		//Follow target
		var heading = target.position - myTrasform.position;
		myTrasform.position += myTrasform.forward * (heading.magnitude - distance) * Time.deltaTime * moveSpeed; 
	}
}
