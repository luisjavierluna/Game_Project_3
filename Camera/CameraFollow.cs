using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float speed = 4;

    private void Update()
    {
        targetPosition = new Vector3(target.transform.position.x,
                                     target.transform.position.y,
                                     transform.position.z);
        transform.position = Vector3.Lerp(transform.position,
                                          targetPosition,
                                          speed * Time.deltaTime);
    }
}
