using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move_player_2D : MonoBehaviour
{
    
    BoxCollider2D box;
    SpriteRenderer sr;
    public GameObject HP_bar;
    public int HP = 5;

    public float speed = 5f;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sr =  GetComponent<SpriteRenderer>();
        HP_bar.GetComponent<HP_bar_boss>().SetMaxHealth(HP);
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(HP_bar);
            SceneManager.LoadScene(0);
        }
        
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

    public void get_damage(int damage)
    {
        HP -= damage;
        HP_bar.GetComponent<HP_bar_boss>().SetHealth(HP);
    }

}

