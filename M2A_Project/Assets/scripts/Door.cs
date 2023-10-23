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
        player = GameObject.FindGameObjectWithTag("Player");
        p = FindObjectOfType<Player>();
        interactableObject = GameObject.FindGameObjectWithTag("Interactable");
        pivotPoint = transform.Find("PivotPoint");
        coll = transform.parent.GetComponent<CapsuleCollider2D>();
    }

    public override void Open()
    {
        if (interacted)
        {
            transform.RotateAround(pivotPoint.transform.position, Vector3.forward, 90 * reverseDoor);
            reverseDoor *= -1;
            interacted = false;
        }
    }
}
