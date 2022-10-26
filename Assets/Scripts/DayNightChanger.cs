using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayNightChanger : MonoBehaviour
{
    public void OnMouseDown(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
