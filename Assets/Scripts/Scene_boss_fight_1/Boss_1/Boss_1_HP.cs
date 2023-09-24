using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_HP : MonoBehaviour
{

    public int HP = 5;
    public bool hit = false;
    public Animator an;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            Debug.Log("hit");
            an.Play("Get_d");
            hit = false;
        }




        if (HP == 0)
        {
            Destroy(gameObject);
        }
        
    }
}
