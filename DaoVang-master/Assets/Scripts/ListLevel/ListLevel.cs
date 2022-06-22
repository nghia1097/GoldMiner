using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListLevel : MonoBehaviour
{

    public void Level1()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Back()
    {
        SceneManager.LoadScene("ChooseMap");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
