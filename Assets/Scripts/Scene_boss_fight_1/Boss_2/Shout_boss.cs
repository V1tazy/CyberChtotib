using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shout_boss : MonoBehaviour
{
    public GameObject target;
    SpriteRenderer sr;
    Boss_1_HP hp_boss;

    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots = 1f;

    void Start()
    {
        hp_boss = GetComponent<Boss_1_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Debug.Log((float)hp_boss.MaxHP/4);
            if (hp_boss.HP > hp_boss.MaxHP/2)
            {
                Shout_level(1);
            }
            else if ((float)hp_boss.HP <= (float)hp_boss.MaxHP/2 && (float)hp_boss.HP > (float)hp_boss.MaxHP/4)
            {
                Shout_level(2);
            }
            else if ((float)hp_boss.HP <= (float)hp_boss.MaxHP/4)
            {
                Shout_level(3);
            }
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        
    }

    void Shout_level(int level)
    {
        Vector3 difference = target.transform.position - transform.position;
        float roat = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 
        var roatbull = Quaternion.Euler(0f, 0f, roat - 90);
        switch (level)
        {
            case 1:
                Instantiate(bullet, shotPoint.transform.position, roatbull);
                break;
            case 2:
                bullet.GetComponent<Bullet>().damage *= 2;
                for (int ug = -90, i = 0; i < 4; i++, ug += 90)
                {
                    roatbull = Quaternion.Euler(0f, 0f, roat + ug);
                    Instantiate(bullet, shotPoint.transform.position, roatbull);
                }
                bullet.GetComponent<Bullet>().damage /= 2;
                break;
            case 3:
                bullet.GetComponent<Bullet>().damage *= 5;
                for (int ug = -90, i = 0; i < 15; i++, ug += 20)
                {
                    roatbull = Quaternion.Euler(0f, 0f, roat + ug);
                    Instantiate(bullet, shotPoint.transform.position, roatbull);
                }
                bullet.GetComponent<Bullet>().damage /= 5;
                break;
        }
    }
}
