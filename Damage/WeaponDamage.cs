using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] GameObject hurtAnimation;
    [SerializeField] GameObject hitPoint;

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
        }
    }
}
