using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move_boss : MonoBehaviour
{

    public List<float> Frame_ogr = new List<float>()
    {
        -6.01f,
        6.01f,
        -14.5f,
        14.5f
    };

    public GameObject player;
    private Vector3 offset;
    public float per = 0.02f;

    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, per);

        float pos_x = smoothedPosition.x;
        float pos_y = smoothedPosition.y;

        //transform.position = smoothedPosition;
        transform.position = new Vector3(Mathf.Clamp(pos_x, Frame_ogr[0], Frame_ogr[1]), Mathf.Clamp(pos_y, Frame_ogr[2], Frame_ogr[3]), transform.position.z);


    }
}
