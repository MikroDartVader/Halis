﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timescale : MonoBehaviour
{
    public float MinimumTimeScale;
    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Mathf.Clamp((gameObject.GetComponent<Rigidbody>().velocity.magnitude / gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.ForwardSpeed) + MinimumTimeScale, 0, 1);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
