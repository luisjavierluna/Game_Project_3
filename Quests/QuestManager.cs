using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public bool[] questCompleted;

    public string itemCollected;

    DialogManager manager;

    private void Start()
    {
        manager = FindObjectOfType<DialogManager>();

        questCompleted = new bool[quests.Length];
    }

    public void ShowQuestText(string questText)
    {
        string[] dialogLines = new string[] { questText };
        manager.ShowTextDialog(dialogLines);
    }

}