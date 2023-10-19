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

 

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<Boss_1_HP>().get_damage(damage);
                hitInfo.collider.GetComponent<Boss_1_move>().change_loc();
            }

            else if (hitInfo.collider.CompareTag("Boss2"))
            {
                hitInfo.collider.GetComponent<Boss_1_HP>().get_damage(damage);
            }

            else if (hitInfo.collider.CompareTag("top-side"))
            {
                hitInfo.collider.GetComponent<Move_player_2D>().get_damage(damage);
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
