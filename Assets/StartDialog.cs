using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    [SerializeField] int IdDialog;
    [SerializeField] GameObject dialogContainer;
    [SerializeField] GameObject dialogTips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Move_player>() != null)
        {
            dialogTips.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Move_player>() != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Yes, you can use this button");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent <Move_player>() != null)
        {
            dialogTips.SetActive(false);
        }
    }
}
