using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    private TMP_Text moneyText; //field money 

    void Start()
    {
        moneyText = GameObject.FindGameObjectWithTag("HP").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<Boss_1_HP>().get_damage(1);
            }

            if (hitInfo.collider.CompareTag("top-side"))
            {
                if (int.Parse(moneyText.text) > 1 )
                {
                    moneyText.text =  (int.Parse(moneyText.text) - 1).ToString();
                }
                else{
                    SceneManager.LoadScene(0);
                }
            }


            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime -= Time.deltaTime;
        }
    }
}
