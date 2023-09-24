using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Boss_1_move : MonoBehaviour
{

    public GameObject target;
    [SerializeField] float speed = 2.5f;
    private TMP_Text moneyText; //field money 
    SpriteRenderer sr;


    void Start()
    {
        moneyText = GameObject.FindGameObjectWithTag("HP").GetComponent<TMP_Text>();
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (int.Parse(moneyText.text) > 1 )
        {
            moneyText.text =  (int.Parse(moneyText.text) - 1).ToString();
        }
        else{
            SceneManager.LoadScene(0);
        }
        
    }


}
