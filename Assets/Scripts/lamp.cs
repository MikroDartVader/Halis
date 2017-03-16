using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : MonoBehaviour
{

    bool shine = false;
    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        if(transform.parent.transform.parent)
        if (Input.GetMouseButtonDown(0))
            shine = !shine;

        if (shine)
            gameObject.GetComponent<Light>().intensity = 1.32f;
        else
            gameObject.GetComponent<Light>().intensity = 0f;
    }
}
