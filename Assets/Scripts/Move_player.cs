using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Move_player : MonoBehaviour
{
    
    BoxCollider2D box;
    SpriteRenderer sr;
    public GameObject playerMode;

    public float speed = 5f;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sr =  GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
        
        if(playerMode.tag == "top-side") {
            float movement_x = Input.GetAxis("Horizontal");
            float movement_y = Input.GetAxis("Vertical");

            if (movement_x != 0)
            {
                sr.flipX = movement_x < 0 ? true : false;
                //this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = movement_x < 0 ? true : false;
            }

            transform.position += new Vector3(movement_x, movement_y, 0) * speed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(playerMode.tag == "left-side")
        {
            float movement_x = Input.GetAxis("Horizontal");

            if(movement_x != 0)
            {
                sr.flipX = movement_x < 0 ? true : false;
            }

            transform.position += new Vector3(movement_x, 0, 0) * speed * Time.deltaTime;
        }

    }

}
