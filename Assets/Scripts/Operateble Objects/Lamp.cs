using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{

    public float Intesity = 1;
    public GameObject Glow;
    public Material Shine, Standart;
    public bool shine;

    // Use this for initialization
    void Start()
    {
        shine = false;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (shine)
        {
            gameObject.GetComponent<Light>().intensity = Intesity;
            Glow.GetComponent<Renderer>().material = Shine;
        }
        else
        {
            gameObject.GetComponent<Light>().intensity = 0;
            Glow.GetComponent<Renderer>().material = Standart;
        }
    }
}
