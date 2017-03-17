using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webCamTexture : MonoBehaviour
{


    public Material mt;
    WebCamDevice[] device;
    WebCamTexture wct;
    Texture2D tmp;

    // Use this for initialization
    void Start()
    {
        device = WebCamTexture.devices;
        wct = new WebCamTexture();

        if (device.Length > 0)
        {
                
            wct.deviceName = device[0].name;
            wct.Play();
            /*Debug.Log(wct.width);
            Debug.Log(wct.height);
            transform.localScale = new Vector3((float)(wct.width)/wct.height,1,1);*/
        }

        mt.mainTexture = wct;
    }


}