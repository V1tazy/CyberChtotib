using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_move : MonoBehaviour
{

    public GameObject target;
    [SerializeField] float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        
    }
}
