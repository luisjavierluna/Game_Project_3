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

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
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
}
