using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functional_button : MonoBehaviour
{
    public GameObject inventMenu;   
    private bool DTrig = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(DTrig)
            {
                DTrig = false;
                inventMenu.SetActive(DTrig);
            }
            else
            {
                DTrig = true;
                inventMenu.SetActive(DTrig);
            }
             
        }
    }
}
