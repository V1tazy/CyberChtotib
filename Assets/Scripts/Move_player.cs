using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_player : MonoBehaviour
{
    
    BoxCollider2D box;
    SpriteRenderer sr;

    public float speed = 5f;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sr =  GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float movement_x = Input.GetAxis("Horizontal");
        float movement_y = Input.GetAxis("Vertical");

        if (movement_x != 0)
        {
            sr.flipX = movement_x < 0 ? true : false;
        }

        transform.position += new Vector3(movement_x, movement_y, 0) * speed * Time.deltaTime;

    }
}
