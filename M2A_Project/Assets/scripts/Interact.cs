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
    public bool canInteract;
    public bool interacted;
    public bool isTimerDone;
    public float cooldown = 1.5f;
    public Player p;

    public static Interact instance;

    public void Init()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        p = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        CanInteract();
        Interacted();
    }

    public void CanInteract()
    {
        if (player.GetComponent<BoxCollider2D>().IsTouching(coll) && isTimerDone)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }

    public void Interacted()
    {
        if (canInteract && p.eKey != 0)
        {
            interacted = true;
            Function();
            StartCoroutine(Cooldown());
        }
    }

    public abstract void Function();

    IEnumerator Cooldown()
    {
        isTimerDone = false;
        yield return new WaitForSeconds(cooldown);
        isTimerDone = true;
    }
}
