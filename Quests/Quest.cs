using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] int questID;
    [SerializeField] string initialText, finalText;

    QuestManager manager;

    private void Start()
    {
        manager = GetComponentInParent<QuestManager>();
    }

    public void StartQuest()
    {
        manager = GetComponentInParent<QuestManager>();
        manager.ShowQuestText(initialText);
    }

    public void CompleteQuest()
    {
        manager.ShowQuestText(finalText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false);
    }

}