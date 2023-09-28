using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{


    public float offset = 1f;
    public GameObject bullet;
    public Transform shotPoint;
    private SpriteRenderer sr;

    private float timeBtwShots;
    public float startTimeBtwShots = 1f;


    // Start is called before the first frame update
    void Start()
    {
        sr =  GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float roat = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 

        if (roat > 90 || roat < -90)
        {
            sr.flipY = true;
            transform.rotation = Quaternion.Euler(0f, 0f, roat);
        }
        
        if (roat < 90 && roat > -90)
        {
            sr.flipY = false;
            transform.rotation = Quaternion.Euler(0f, 0f, roat + offset);
        }


        var roatbull = Quaternion.Euler(0f, 0f, roat + offset - 90);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.transform.position, roatbull);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        
    }
}
