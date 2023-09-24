using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_motion : MonoBehaviour
{


    public GameObject Boss;
    public GameObject dialog;
    public GameObject canvas;

    private GameObject Prefub;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D obj)
    {
        //Time.timeScale = 0f;
        

        Prefub = Instantiate(dialog, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Prefub.transform.SetParent(canvas.transform, false);
        Destroy(gameObject);



        if (transform.GetChild(0).GetComponent<Background>().activeSelf == false)
        {
            Boss.GetComponent<Boss_1_move>().enabled = true;
        }
        
        
        
        
    }
}
