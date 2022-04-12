using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] bool playerInTheZone;
    [SerializeField] string[] dialog;

    DialogManager manager;

    private void Start()
    {
        manager = FindObjectOfType<DialogManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerInTheZone)
        {
            manager.ShowTextDialog(dialog);
            if (gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTheZone = false;
        }
    }
}
