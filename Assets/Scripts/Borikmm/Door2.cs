using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour
{
    public bool what = true;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown (KeyCode.E))
        {
            if (what)
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }
}
