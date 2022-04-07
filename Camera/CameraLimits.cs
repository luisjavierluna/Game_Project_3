using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimits : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<CameraFollow>()
            .ChangeLimits(GetComponent<BoxCollider2D>());
    }
}
