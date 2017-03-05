using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeConfig : MonoBehaviour
{

    public Transform Target;
    public int TailLength;
    public float HeadMoveSpeed, HeadRotationSpeed, HeadDistance;
    public float PartMoveSpeed, PartRotationSpeed, PartDistance;



    private SnakePartMove TailPart;
    private SnakeHeadMove Head;
    private GameObject[] Tail;

    // Use this for initialization
    void Start()
    {
        Head = GameObject.Find(" (" + 0 + ")").GetComponent<SnakeHeadMove>();
        Head.distance = HeadDistance;
        Head.moveSpeed = HeadMoveSpeed;
        Head.rotationSpeed = HeadRotationSpeed;
        Head.target = Target;

        Tail = new GameObject[TailLength];
        for (int i = 0; i < TailLength; i++)
        {
            Tail[i] = GameObject.Find(" (" + (i + 1) + ")");
            TailPart = Tail[i].GetComponent<SnakePartMove>();
            TailPart.distance = PartDistance;
            TailPart.moveSpeed = PartMoveSpeed;
            TailPart.rotationSpeed = PartRotationSpeed;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }
}
