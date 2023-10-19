using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Boss_1_move : MonoBehaviour
{

    public GameObject target;
    [SerializeField] float speed = 2.5f;
    SpriteRenderer sr;
    
    private float timeBtwShots;
    public float startTimeBtwShots = 3f;


    void Start()
    {
        sr =  GetComponent<SpriteRenderer>();
    }




    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        sr.flipX = target.transform.position.x < transform.position.x ? true : false;

        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        
    }



    void OnCollisionStay2D(Collision2D collision)
    {
        if (timeBtwShots <= 0)
        {
            if (collision.gameObject.tag == "top-side")
            {
                target.GetComponent<Move_player>().get_damage(1);
            }
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void change_loc()
    {
        float RandX, RandY;
        Vector3 whereToSpawn;
        RandX = Random.Range(-10.27f, 31.54f);
        RandY = Random.Range(-12.33f, 15.31f);
        whereToSpawn = new Vector3(RandX, RandY, 0f);
        speed += 1f;
        transform.position = whereToSpawn;
    }
}
