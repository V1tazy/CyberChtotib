using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сamera_move : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private float per = 0.02f;

    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, per);
        transform.position = smoothedPosition;
    }
}
