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

        pivotPoint = transform.Find("PivotPoint");
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
