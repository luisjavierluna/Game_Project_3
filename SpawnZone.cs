using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    PlayerController thePlayer;
    CameraFollow theCamera;

    [SerializeField] string placeName;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraFollow>();
        if (!thePlayer.nextPlaceName.Equals(placeName))
        {
            return;
        }

        thePlayer.transform.position = transform.position;
        theCamera.transform.position = new Vector3(transform.position.x,
                                                   transform.position.y,
                                                   theCamera.transform.position.z);
    }
}
