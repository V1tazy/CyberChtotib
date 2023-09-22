using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_scene : MonoBehaviour
{
    public void NextLevel(int _scene_number)
    {
        SceneManager.LoadScene(_scene_number);
    }
}
