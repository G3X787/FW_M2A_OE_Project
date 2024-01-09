using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interact : MonoBehaviour
{
    public GameObject player;
    public bool canInteract;
    public bool interacted;
    public bool isTimerDone;
    public float cooldown = 1.5f;
    public Player p;

    public static Interact instance;

    GameObject interactUI;

    public void Init()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        p = FindObjectOfType<Player>();
        interactUI = GameObject.FindGameObjectWithTag("InteractionUI");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Interacted();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
