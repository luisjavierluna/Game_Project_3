using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public int damagePoints;
    [SerializeField] float damageSpeed = 2;
    [SerializeField] Text damageText;

    private void Update()
    {
        damageText.text = damagePoints.ToString();
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y + damageSpeed * Time.deltaTime,
                                         transform.position.z);
    }
}
