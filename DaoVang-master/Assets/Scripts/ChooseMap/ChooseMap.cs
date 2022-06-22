using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MenuGame");
    }    

    public void Play()
    {
        SceneManager.LoadScene("ListLevel");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
