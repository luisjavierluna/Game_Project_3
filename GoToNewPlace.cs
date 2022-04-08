using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    [SerializeField] string newPlaceName = "New Scene Name Here";
    [SerializeField] string goToNewPlace;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().nextPlaceName = goToNewPlace;
            SceneManager.LoadScene(newPlaceName);
        }
    }
}
