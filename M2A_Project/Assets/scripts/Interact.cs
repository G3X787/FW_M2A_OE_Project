using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interact : MonoBehaviour
{
    public CapsuleCollider2D coll;
    public GameObject player;
    public GameObject interactableObject;
    public GameObject interactUI;
    public bool canInteract;
    public bool interacted;
    public bool isTimerDone;
    public float cooldown = 1.5f;
    public Player p;

    // Update is called once per frame
    public virtual void Update()
    {
        CanInteract();
        Interacted();
    }

    void CanInteract()
    {
        if (player.GetComponent<BoxCollider2D>().IsTouching(coll) && isTimerDone)
        {
            canInteract = true;
            interactUI.SetActive(true);
        }
        else
        {
            canInteract = false;
            interactUI.SetActive(false);
        }
    }

    public void Interacted()
    {
        if (canInteract && p.eKey != 0)
        {
            interacted = true;
            Open();
            StartCoroutine(Cooldown());
        }
    }

    public abstract void Open();

    IEnumerator Cooldown()
    {
        isTimerDone = false;
        yield return new WaitForSeconds(cooldown);
        isTimerDone = true;
    }
}
