using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float speed = 4;

    Camera theCamera;
    Vector3 minLimits, maxLimits;
    float halfWidth, halfHeight;

    private void Update()
    {
        targetPosition = new Vector3(target.transform.position.x,
                                     target.transform.position.y,
                                     transform.position.z);
        transform.position = Vector3.Lerp(transform.position,
                                          targetPosition,
                                          speed * Time.deltaTime);

        float clampX = Mathf.Clamp(transform.position.x,
                                   minLimits.x + halfWidth,
                                   maxLimits.x - halfWidth);
        float clampY = Mathf.Clamp(transform.position.y,
                                   minLimits.y + halfHeight,
                                   maxLimits.y - halfHeight);
        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }

    public void ChangeLimits(BoxCollider2D limits)
    {
        minLimits = limits.bounds.min;
        maxLimits = limits.bounds.max;

        theCamera = GetComponent<Camera>();
        halfWidth = theCamera.orthographicSize;
        halfHeight = halfWidth / Screen.width * Screen.height;
    }
}
