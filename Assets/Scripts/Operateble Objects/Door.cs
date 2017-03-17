using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Act
{

    public override void Config()
    {
        Grabable = false;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (flag)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 120, 0),3*Time.deltaTime);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0),3*Time.deltaTime);
    }
}
