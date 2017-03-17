using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{


    public int GrabButton, DropButton, OperationButton;
    public Texture aim;


    private bool grabbed = false, captured = false;
    private RaycastHit[] hits;
    private Act OperObjAct;
	
    // Update is called once per frame
    void Update()
    {
        if (!grabbed)
        {
            hits = Physics.RaycastAll(transform.parent.position, transform.parent.forward, 5);
            if (hits.Length != 0)
                Debug.Log(hits[hits.Length - 1].transform.name);
            if (hits.Length != 0 && hits[hits.Length - 1].transform.tag == "Operateble")
            {
                captured = true;
                OperObjAct = hits[hits.Length - 1].transform.GetComponent<Act>();

                if (Input.GetMouseButtonDown(GrabButton) && OperObjAct.Grabable)
                {
                    OperObjAct.Grab();
                    grabbed = true;
                }
                else if (Input.GetMouseButtonDown(OperationButton))
                    OperObjAct.Operate();
            }
            else
                captured = false;
        }
        else
        {
            captured = false;

            if (Input.GetMouseButtonDown(DropButton))
            {
                OperObjAct.Drop();
                grabbed = false;
            }
            else if (Input.GetMouseButtonDown(OperationButton))
                OperObjAct.Operate();
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
