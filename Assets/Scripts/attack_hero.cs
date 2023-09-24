using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_hero : MonoBehaviour
{

    public GameObject Boss;
    public Animator an;
    SpriteRenderer sr;
    private int HP_boss;
    // Start is called before the first frame update

    void Start()
    {
        sr =  GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            an.Play("Player_attack");

            if (Vector3.Distance(Boss.transform.position, transform.position) <= 4f && sr.flipX != Boss.GetComponent<SpriteRenderer>().flipX)
            {
                Boss.GetComponent<Boss_1_HP>().get_damage(1);
            }
            
        }
    }
}
