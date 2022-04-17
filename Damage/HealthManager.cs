using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    [SerializeField] bool flashActive;
    [SerializeField] float flashLength = 2;
    float flashCounter;

    [SerializeField] int exp = 10;

    public string enemyName;
    QuestManager manager;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        manager = FindObjectOfType<QuestManager>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            if (gameObject.CompareTag("Enemy"))
            {
                manager.enemyKilled = enemyName;

                GameObject.Find("Player")
                    .GetComponent<CharacterStats>()
                    .AddExperience(exp);
            }
        }

        if (gameObject.CompareTag("Player"))
        {
            if (flashActive)
            {
                flashCounter -= Time.deltaTime;
                if (flashCounter >= flashLength * 0.66f)
                {
                    ToggleColor(false);
                }
                else if (flashCounter >= flashLength * 0.33f)
                {
                    ToggleColor(true);
                }
                else if (flashCounter >= 0)
                {
                    ToggleColor(false);
                }
                else
                {
                    ToggleColor(true);
                    flashActive = false;
                }
            }
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if (flashLength > 0)
        {
            flashActive = true;
            flashCounter = flashLength;
        }
    }

    void ToggleColor(bool visible)
    {
        sprite.color = new Color(sprite.color.r,
                                 sprite.color.g,
                                 sprite.color.b,
                                 visible ? 1.0f : 0.0f);
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
