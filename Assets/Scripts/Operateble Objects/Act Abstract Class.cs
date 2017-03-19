using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Act : MonoBehaviour
{
    public bool Grabable;
    public bool grabbed = false;
    public bool flag;

    public void Grab()
    {
        if (Grabable)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform.FindChild("MainCamera").Find("hand");
            transform.SetParent(player);
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            transform.GetComponent<Collider>().enabled = false;
            transform.rotation = player.rotation;
            transform.position = player.position;
            grabbed = true;
        }
    }


    public void Drop()
    {
        if (Grabable)
        {
            transform.parent = null;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0));
            transform.GetComponent<Collider>().enabled = true;
            grabbed = true;
        }
    }

    public virtual void Operate()
    {
        Debug.Log("Operate");
        if (Grabable)
        {
            if (grabbed)
                flag = !flag;
        }
        else
            flag = !flag;
    }


    public abstract void Config();

    void Start()
    {
        Config();
    }

}
