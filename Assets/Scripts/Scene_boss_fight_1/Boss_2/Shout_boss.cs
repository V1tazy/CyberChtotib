using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shout_boss : MonoBehaviour
{
    public GameObject target;
    SpriteRenderer sr;

    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots = 3f;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = target.transform.position - transform.position;
        float roat = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 
        var roatbull = Quaternion.Euler(0f, 0f, roat - 90);

        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, shotPoint.transform.position, roatbull);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        
    }
}
