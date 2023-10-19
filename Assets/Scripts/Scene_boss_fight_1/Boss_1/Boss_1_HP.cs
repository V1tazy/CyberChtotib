using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_HP : MonoBehaviour
{

    public int HP = 5;
    public int MaxHP = 5;
    Animator an;
    public GameObject HP_bar;
    private Door2 Door;


    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
        HP_bar.GetComponent<HP_bar_boss>().SetMaxHealth(HP);
        Door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Door.what = true;
            Destroy(HP_bar);
            Destroy(gameObject);
            
        }
    }

    public void get_damage(int damage)
    {
        HP -= damage;
        HP_bar.GetComponent<HP_bar_boss>().SetHealth(HP);
        an.Play("Get_d");
    }
}
