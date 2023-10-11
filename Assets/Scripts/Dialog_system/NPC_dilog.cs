using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_dilog : MonoBehaviour
{
    public GameObject dialog;
    public GameObject canvas;
    public GameObject player;

    private GameObject Prefub;

    private bool doing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doing)
        {
            if (GameObject.Find("[Dialog_1](Clone)") == null)
            {
                doing = false;
                player.GetComponent<Move_player>().enabled = true;
                player.GetComponent<Attack_hero>().enabled = true;
                
            }
        }

        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown (KeyCode.E))
        {
            Debug.Log("Button Is Working");
            player.GetComponent<Move_player>().enabled = false;
            player.GetComponent<Attack_hero>().enabled = false;
            Prefub = Instantiate(dialog, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Prefub.transform.SetParent(canvas.transform, false);
            doing = true;
        }
    }

}
