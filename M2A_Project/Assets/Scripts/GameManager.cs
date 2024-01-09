using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject interactUI;
    GameObject[] doors;

    // Start is called before the first frame update
    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractionUI");
        doors = GameObject.FindGameObjectsWithTag("Door");
        interactUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            bool test = doors[i].GetComponentInParent<Door>().canInteract;
            /*if (test)
            {
                interactUI.SetActive(true);
            }
            else
            {
                interactUI.SetActive(false);
            }*/
        }
        
    }
}
