using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E_Interact_Door : MonoBehaviour
{

    public GameObject frame;


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            frame.SetActive(true);
            if (Input.GetKeyDown (KeyCode.E))
            {
                Debug.Log("Button Is Working");
                Debug.Log(SceneManager.GetActiveScene().buildIndex);
                switch (SceneManager.GetActiveScene().buildIndex)
                {
                    case 1:
                        SceneManager.LoadScene(2);
                        break;
                    case 2:
                        SceneManager.LoadScene(1);
                        break;
                }
            }
            Debug.Log("This Door");
        }
    }
}
