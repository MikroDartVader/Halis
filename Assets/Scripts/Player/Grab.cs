using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{


    private RaycastHit[] hits;
    public bool grabbed = false;
    private Transform grOb;
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!grabbed)
            {
                hits = Physics.RaycastAll(transform.parent.position, transform.parent.forward, 5);
                if (hits.Length != 0)
                {
                   // Debug.Log(hits[hits.Length - 1].transform.name);
                    grOb = hits[hits.Length - 1].transform;
                    if (grOb.tag == "Grabable")
                    {
                        grOb.SetParent(transform);
                        grOb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        grOb.GetComponent<Collider>().enabled = false;
                        grOb.rotation = transform.rotation;
                        grOb.Rotate(-90, 0, 0);
                        grOb.position = transform.position;
                        grabbed = true;
                    }
                }
            }
            else if (grOb != null)
            {
                grOb.parent = null;
                grOb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                grOb.GetComponent<Collider>().enabled = true;
                grabbed = false;
            }
        }
    }
}
