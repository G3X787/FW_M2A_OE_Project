using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : Interact
{
    Transform pivotPoint;
    int reverseDoor = -1;
    void Start()
    {
        Init();
        interactableObject = GameObject.FindGameObjectWithTag("Door");

        pivotPoint = transform.Find("PivotPoint");
        coll = transform.parent.GetComponent<CapsuleCollider2D>();
    }

    public override void Function()
    {
        if (interacted)
        {
            transform.RotateAround(pivotPoint.transform.position, Vector3.forward, 90 * reverseDoor);
            reverseDoor *= -1;
            interacted = false;
        }
    }
}
