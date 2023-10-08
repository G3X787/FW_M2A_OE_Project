using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    [SerializeField] InteractType interactType;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            player.interactType = interactType;
            player.interactableObject = this.GetComponentInParent<InteractableObject>();
            // Show interact option
            
        }
    }
}
