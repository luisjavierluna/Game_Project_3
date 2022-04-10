using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel;
    [SerializeField] int currentExp;
    [SerializeField] int[] expToLevelUp;

    [SerializeField] int[] hpLevels;
    public int[] strenghLevels;
    public int[] defenseLevels;

    HealthManager manager;

    private void Start()
    {
        manager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        if (currentExp > expToLevelUp[currentLevel])
        {
            currentLevel++;
            manager.UpdateMaxHealth(hpLevels[currentLevel]);
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
    }
}
