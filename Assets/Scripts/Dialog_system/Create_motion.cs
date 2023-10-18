using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_motion : MonoBehaviour
{


    public GameObject Boss;
    public GameObject dialog;
    public GameObject canvas;
    public GameObject player;
    public GameObject HP_bar;

    private GameObject Prefub;
    private bool doing = false;
    private bool one_spawn = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doing)
        {
            if (Prefub.transform.GetChild(0).gameObject.activeSelf == false)
            {
                Boss.GetComponent<Boss_1_move>().enabled = true;
                try
                {
                    Boss.GetComponent<Shout_boss>().enabled = true;
                }
                catch {}
                
                doing = false;
                player.GetComponent<Move_player>().enabled = true;
                player.GetComponent<Attack_hero>().enabled = true;
                player.transform.GetChild(0).gameObject.GetComponent<Guns>().enabled = true;
                HP_bar.SetActive(true);
                Destroy(gameObject);
                
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (!one_spawn)
        {
            player.GetComponent<Move_player>().enabled = false;
            player.GetComponent<Attack_hero>().enabled = false;
            player.transform.GetChild(0).gameObject.GetComponent<Guns>().enabled = false;
            

            Prefub = Instantiate(dialog, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Prefub.transform.SetParent(canvas.transform, false);
        
            doing = true;
            one_spawn = true;
        }
        //Time.timeScale = 0f;

        
        
        
        
    }
}
