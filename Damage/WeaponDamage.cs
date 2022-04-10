using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] GameObject hurtAnimation;
    [SerializeField] GameObject hitPoint;
    [SerializeField] GameObject damageNumber;

    CharacterStats stats;

    private void Start()
    {
        stats = GetComponentInParent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int totalDamage = damage;
            if (stats != null)
            {
                totalDamage += stats.strenghLevels[stats.currentLevel];
            }

            collision
                .GetComponent<HealthManager>()
                .DamageCharacter(totalDamage);

            Instantiate(hurtAnimation, 
                        hitPoint.transform.position, 
                        hitPoint.transform.rotation);
            var clone = (GameObject)Instantiate(damageNumber,
                                     hitPoint.transform.position,
                                     Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }
    }
}
