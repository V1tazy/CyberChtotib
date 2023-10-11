using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Dialog_with_NPC : MonoBehaviour
{
    public string[] texts;
    public float speedText;
    public GameObject dell;
    public TMP_Text dialogText;

    private int index;
    

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
            for (int a = 0; a < 3; a++)
            {
                this.transform.GetChild(a).gameObject.SetActive(true);
            }
        }
    }


    public void chenge1()
    {
        List<string> lstContent = texts.ToList<string>();
        lstContent.Clear();
        lstContent.Add("А ты кто черт");
        lstContent.Add("Я робот");
        texts = lstContent.ToArray();
        dialogText.text = string.Empty;
        StartDialoge();
    }

    public void dialog_exit()
    {
        Destroy(dell);
    }
}
