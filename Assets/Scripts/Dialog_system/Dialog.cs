using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public string[] texts;
    public float speedText;
    public TMP_Text dialogText;

    public int index;

    private void Start()
    {
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
