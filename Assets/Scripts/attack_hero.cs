using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_hero : MonoBehaviour
{


    public Animator an;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector3 attackDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            Debug.Log(attackDir);
            an.Play("attack");
        }
    }
}
