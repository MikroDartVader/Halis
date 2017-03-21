﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operating : MonoBehaviour
{


    public int GrabButton, DropButton, OperationButton;
    public Texture aim;


    private bool grabbed = false, captured = false;
    private RaycastHit[] hits;
    private Transform OperObj, GrabbedObj;
    private Act GrabbedObjAct;
	
    // Update is called once per frame
    void Update()
    {
        hits = Physics.RaycastAll(transform.parent.position, transform.parent.forward, 5);
        if (hits.Length != 0)
        {
            OperObj = hits[hits.Length - 1].transform;
        }
        else
            OperObj = null;
        if (!grabbed)
        {
            if (OperObj != null && OperObj.tag == "Operateble" && OperObj.GetComponent<Act>() != null)
            {
                captured = true;
                GrabbedObjAct = OperObj.GetComponent<Act>();

                if (Input.GetMouseButtonDown(GrabButton) && GrabbedObjAct.Grabable)
                {
                    GrabbedObjAct.Grab();
                    grabbed = true;
                    GrabbedObj = OperObj;

                    GrabbedObj.gameObject.layer = 8;
                    for (int i = 0; i < GrabbedObj.childCount; i++)
                        GrabbedObj.GetChild(i).gameObject.layer = GrabbedObj.gameObject.layer;
                }
                else if (Input.GetMouseButtonDown(OperationButton))
                    GrabbedObjAct.Operate();
            }
            else
                captured = false;
        }
        else
        {
            if (OperObj != null && OperObj.tag == "Operateble" && OperObj.GetComponent<BaseToPut>() != null && OperObj.GetComponent<BaseToPut>().PutableObject == GrabbedObj)
            {
                captured = true;
                if (Input.GetMouseButtonDown(OperationButton))
                {
                    GrabbedObj.GetComponent<Act>().Put(OperObj);

                    GrabbedObj.gameObject.layer = 0;
                    for (int i = 0; i < GrabbedObj.childCount; i++)
                        GrabbedObj.GetChild(i).gameObject.layer = GrabbedObj.gameObject.layer;
                    
                    grabbed = false;
                    captured = false;
                }
            }
            else
            {
                captured = false;

                if (Input.GetMouseButtonDown(DropButton))
                {
                    GrabbedObjAct.Drop();

                    GrabbedObj.gameObject.layer = 0;
                    for (int i = 0; i < GrabbedObj.childCount; i++)
                        GrabbedObj.GetChild(i).gameObject.layer = GrabbedObj.gameObject.layer;
                    
                    grabbed = false;
                }
                else if (Input.GetMouseButtonDown(OperationButton))
                    GrabbedObjAct.Operate();
            }
        }
               
    }


    void OnGUI()
    {
        float size;
        if (!captured)
            size = 0.4f;
        else
            size = 0.3f;
        GUI.DrawTexture(new Rect((Screen.width - aim.width * size) / 2, (Screen.height - aim.height * size) / 2, aim.width * size, aim.height * size), aim);

    }
}
