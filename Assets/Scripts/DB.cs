using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DB_Scropt : MonoBehaviour
{
    public List<Item> items = new List<Item>();



}

[System.Serializable]

public class Item
{
    public int id;
    public string name;
    public Sprite img;
}
