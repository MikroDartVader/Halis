using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Act
{
    Quaternion FirstRot;

    public override void Config()
    {
        Grabable = false;
        FirstRot = transform.rotation;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (flag)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(FirstRot.eulerAngles.x, FirstRot.eulerAngles.y + 120, FirstRot.eulerAngles.z), 3 * Time.deltaTime);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, FirstRot, 3 * Time.deltaTime);
    }
}
