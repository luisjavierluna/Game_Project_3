using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] GameObject hurtAnimation;
    [SerializeField] GameObject hitPoint;
    [SerializeField] GameObject damageNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision
                .GetComponent<HealthManager>()
                .DamageCharacter(damage);

            Instantiate(hurtAnimation, 
                        hitPoint.transform.position, 
                        hitPoint.transform.rotation);
            var clone = (GameObject)Instantiate(damageNumber,
                                     hitPoint.transform.position,
                                     Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
