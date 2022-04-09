using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] int currentLevel;
    [SerializeField] int currentExp;
    [SerializeField] int[] expToLevelUp;

    private void Update()
    {
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        if (currentExp > expToLevelUp[currentLevel])
        {
            currentLevel++;
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
    }
}
