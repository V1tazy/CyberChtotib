using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HP : MonoBehaviour
{

    public TMP_Text moneyText; //field money 
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GameObject.FindGameObjectWithTag("HP").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
