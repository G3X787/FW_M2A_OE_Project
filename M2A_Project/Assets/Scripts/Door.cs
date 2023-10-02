using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interacted()
    {
        transform.position = Vector3.zero;
    }
}
