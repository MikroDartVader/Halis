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
            
            if (transform.GetComponent<Collider>() != null)
                transform.GetComponent<Collider>().enabled = false;
            
            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild(i).GetComponent<Collider>() != null)
                    transform.GetChild(i).GetComponent<Collider>().enabled = false;
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



            if (transform.GetComponent<Collider>() != null)
                transform.GetComponent<Collider>().enabled = true;

            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild(i).GetComponent<Collider>() != null)
                    transform.GetChild(i).GetComponent<Collider>().enabled = true;
            grabbed = true;
        }
    }


    public void Put(Transform NewParent)
    {
        if (Grabable)
        {
            BaseToPut Base = NewParent.GetComponent<BaseToPut>();
            transform.parent = NewParent;
            transform.localPosition = new Vector3(Base.x, Base.y, Base.z);
            transform.localRotation = new Quaternion(0, 0, 0, 0);


            if (transform.GetComponent<Collider>() != null)
                transform.GetComponent<Collider>().enabled = Base.ChildCollider;

            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild(i).GetComponent<Collider>() != null)
                    transform.GetChild(i).GetComponent<Collider>().enabled = Base.ChildCollider;

            if (Base.ChildPhisics)
                transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            grabbed = false;
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
