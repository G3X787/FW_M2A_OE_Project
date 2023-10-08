using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    // Variables
    public bool isInteracted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isInteracted)
        {
            Interacted();
        }
    }

    public abstract void Interacted();
    
}
