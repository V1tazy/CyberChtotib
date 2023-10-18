using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate_door : MonoBehaviour
{

    private Animator DoorAnimator;

    private bool isOpen;
    private bool isClose;

    private void Start()
    {
        DoorAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Move_player>())
        {
            if(!isOpen)
            {
                DoorAnimator.SetBool("DrOpen", true);
                isOpen = true;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Move_player>())
        {
            DoorAnimator.SetBool("DrClose", false);
            DoorAnimator.SetBool("DrOpen",false);
            DoorAnimator.SetBool("DrStay", true);
            isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Move_player>())
        {
            if (isOpen)
            {
                DoorAnimator.SetBool("DrStay", false);
                DoorAnimator.SetBool("DrOpen", false);
                DoorAnimator.SetBool("DrClose", true);
                isOpen = false;
                StartCoroutine(OpenAfterDelay(0.5f));
            }
        }
    }
    IEnumerator OpenAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DoorAnimator.SetBool("DrDefault", true);
    }
}
