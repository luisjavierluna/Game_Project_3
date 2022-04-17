using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] int questID;
    [SerializeField] string initialText, finalText;

    [SerializeField] bool needsItem;
    [SerializeField] string itemName;

    [SerializeField] bool needsEnemy;
    [SerializeField] string enemyName;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] int enemiesKilled;

    QuestManager manager;

    private void Start()
    {
        manager = GetComponentInParent<QuestManager>();
    }

    private void Update()
    {
        if (needsItem && manager.itemCollected.Equals(itemName))
        {
            manager.itemCollected = null;
            CompleteQuest();
        }

        if (manager.enemyKilled != null)
        {
            if (needsEnemy && manager.enemyKilled.Equals(enemyName))
            {
                manager.enemyKilled = null;
                enemiesKilled++;
                if (enemiesKilled >= numberOfEnemies)
                {
                    CompleteQuest();
                }
            }
        }
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