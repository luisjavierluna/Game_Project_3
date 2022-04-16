using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QestItem : MonoBehaviour
{
    public int questID;
    public string itemName;

    QuestManager manager;

    private void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!manager.questCompleted[questID] && manager.quests[questID].gameObject.activeInHierarchy)
            {
                manager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
