using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_HP : MonoBehaviour
{

    public int HP = 5;
    public Animator an;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (HP == 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void get_damage(int damage)
    {
        HP -= damage;
        an.Play("Get_d");
    }
}
