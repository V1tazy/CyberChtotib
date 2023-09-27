using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public string[] texts;
    public string[] numbers_line_unswers;
    public float speedText;
    public TMP_Text dialogText;

    private int index;


    private Dictionary<int, List<string>> parse_unswers()
    {
        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
        List<string> unswer_list = new List<string>();
        var number_line = 0;
        bool trig = false;
        foreach(string i in numbers_line_unswers)
        {
            foreach(char j in i)
            {
                string word = "";
                try
                {
                    number_line = int.Parse(i);
                }
                catch
                {
                    if (i == " ")
                    {
                        unswer_list.Add(word);
                        word = "";
                    }
                    else
                    {
                        word += i;
                    }
                }
            }
            dict.Add(number_line, unswer_list);
        }
        return dict;
    }



    private void Start()
    {
        var dict = parse_unswers();
       // Debug.Log(dict);
        dialogText.text = string.Empty;
        StartDialoge();
    }

    void StartDialoge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }




    IEnumerator TypeLine()
    {
        foreach(char c in texts[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void scipTextClick()
    {
        if(dialogText.text == texts[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogText.text = texts[index];
        }
    }


    private void NextLines()
    {
        if(index < texts.Length - 1)
        {
            index++;
            dialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
