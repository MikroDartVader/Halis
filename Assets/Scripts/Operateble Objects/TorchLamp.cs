using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLamp : Act
{
    Lamp lamp;

    public override void Config()
    {
        Grabable = true;
        lamp = transform.GetComponentInChildren<Lamp>();
    }


    public override void Operate()
    {
        if (grabbed)
        {
            flag = !flag;
            lamp.shine = flag;
        }
    }

}

