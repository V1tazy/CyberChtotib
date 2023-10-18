using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] GameObject enableDoor;
    [SerializeField] bool isOpenDoor;
    [SerializeField] Transform pointPosition;
    [SerializeField] GameObject sceneObject;
    [SerializeField] List<float> frameOrg;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isOpenDoor && collision.GetComponent<Move_player>() != null) 
        {
            enableDoor.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isOpenDoor && collision.GetComponent<Move_player>() != null) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _camera.GetComponent<Camera_move_boss>().Frame_ogr = frameOrg;
                collision.gameObject.transform.position = pointPosition.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isOpenDoor && collision.GetComponent<Move_player>() != null)
        {
            enableDoor.SetActive(false);
        }
    }
}
