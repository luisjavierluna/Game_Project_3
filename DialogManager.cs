using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public bool dialogActive;
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] string[] dialogLines;
    [SerializeField] int currentDialogLine;

    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogLine++;
        }

        if (currentDialogLine >= dialogLines.Length)
        {
            dialogActive = false;
            dialogBox.SetActive(false);
            player.isTalking = false;
        }
        else
        {
            dialogText.text = dialogLines[currentDialogLine];
        }
    }

    public void ShowTextDialog(string[] lines)
    {
        dialogActive = true;
        dialogBox.SetActive(true);
        currentDialogLine = 0;
        dialogLines = lines;
        player.isTalking = true;
    }
}
