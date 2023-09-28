using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate_door : MonoBehaviour
{

    private Animator animator;

    private bool isOpen = false;
    private bool isClose = false;
    public void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("DrOpen");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("DrClose");
        }
    }
}
