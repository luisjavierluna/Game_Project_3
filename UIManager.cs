using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider barHP;
    [SerializeField] Text textHP;
    [SerializeField] HealthManager managerHP;

    private void Update()
    {
        barHP.maxValue = managerHP.maxHealth;
        barHP.value = managerHP.currentHealth;
        StringBuilder sb = new StringBuilder("HP: ");
        sb.Append(managerHP.currentHealth);
        sb.Append("/");
        sb.Append(managerHP.maxHealth);
        textHP.text = sb.ToString();
    }
}
