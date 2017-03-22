using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Act
{

    public Transform BulletSpawn;
    public Transform BulletPrefab;
    public float BulletSpeed;
    private Transform go;

    public override void Config()
    {
        Grabable = true;
    }


    public override void Operate()
    {
        //Debug.Log("shoot");
        if (grabbed)
        {
            go = Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            go.GetComponent<BulletFlying>().Gun = transform.parent;
            go.GetComponent<BulletFlying>().Speed = BulletSpeed;
        }
    }
}
