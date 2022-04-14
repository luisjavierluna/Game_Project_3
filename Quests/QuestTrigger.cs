using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] int questID;
    [SerializeField] bool initialPoint, finalPoint;

    QuestManager manager;

    private void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!manager.questCompleted[questID])
            {
                if (initialPoint && !manager.quests[questID].gameObject.activeInHierarchy)
                {
                    manager.quests[questID].gameObject.SetActive(true);
                    manager.quests[questID].StartQuest();
                }
                if (finalPoint && manager.quests[questID].gameObject.activeInHierarchy)
                {
                    manager.quests[questID].CompleteQuest();
                }
            }
        }
    }
}
