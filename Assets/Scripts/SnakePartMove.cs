using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePartMove: MonoBehaviour
{

	public Transform target;
	public float moveSpeed;
	public float rotationSpeed;
	public float distance;

	private Transform myTrasform;

	void Awake()
	{
		myTrasform = transform;
	}

	// Use this for initialization
	void Start()
	{
		GameObject go = GameObject.Find(name.Replace(FindNumeric(name), (GetInt(name) - 1).ToString()));
		Debug.Log(name.Replace(FindNumeric(name), (GetInt(name) - 1).ToString()));
		target = go.transform;
		moveSpeed = 10;
		rotationSpeed = 10;
		distance = 0.4f;
	}
	
	// Update is called once per frame
	void Update()
	{
		Debug.DrawLine(myTrasform.position, target.position, Color.black);

		//look at target
		myTrasform.rotation = Quaternion.Slerp(myTrasform.rotation, Quaternion.LookRotation(target.position - myTrasform.position), rotationSpeed * Time.deltaTime);

		//Follow target
		var heading = target.position - myTrasform.position;
		myTrasform.position += myTrasform.forward * (heading.magnitude - distance) * Time.deltaTime * moveSpeed; 
	}



	int GetInt(string s)
	{
		int tmp, result=0;
		s = FindNumeric(s);

		for (int i = 0; i < s.Length; i++)
		{
			int.TryParse(s.ToCharArray()[i].ToString(), out tmp);
			result += tmp * (int)Mathf.Pow(10, s.Length - (i + 1));
		}
		Debug.Log(result);
		return result;
	}


	string FindNumeric(string s)
	{
		int start=0, end=0, tmp;
		bool hadStarted = false;
		foreach (char c in s)
		{
			int.TryParse(c.ToString(), out tmp);
			if (tmp > 0 && tmp < 10 || c == '0')
			{
				if (hadStarted == false)
				{
					start = s.IndexOf(c);
					hadStarted = true;
				}
			}
			else if (hadStarted == true)
				end = s.IndexOf(c) - 2;
		}
		Debug.Log(s.Substring(start, end));
		return s.Substring(start, end);
	}
}
