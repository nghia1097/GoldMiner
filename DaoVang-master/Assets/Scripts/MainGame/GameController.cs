using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Char_Common, Char_Rare, Char_Epic, Char_Lengend;
    public GameObject Ma_Common, Ma_Rare, Ma_Epic, Ma_Lengend;
    public Transform PosChar, PosMachine;
    int numberChar;
    int numberMachine;
    void Start()
    {
        numberChar = 1;
        numberMachine = 1;
        Char_Common.SetActive(true);
        Ma_Common.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void L_Char()
    {
        if (numberChar == 1)
        {
            numberChar = 4;
            Char_Common.SetActive(false);
            Char_Lengend.SetActive(true);
            return;
        }
        if (numberChar == 2)
        {
            numberChar = 1;
            Char_Rare.SetActive(false);
            Char_Common.SetActive(true);
            return;
        }
        if (numberChar == 3)
        {
            numberChar = 2;
            Char_Epic.SetActive(false);
            Char_Rare.SetActive(true);
            return;
        }
        if (numberChar == 4)
        {
            numberChar = 3;
            Char_Lengend.SetActive(false);
            Char_Epic.SetActive(true);
            return;
        }
    }

    public void R_Char()
    {
        if (numberChar == 1)
        {
            numberChar = 2;
            Char_Common.SetActive(false);
            Char_Rare.SetActive(true);
            return;
        }
        if (numberChar == 2)
        {
            numberChar = 3;
            Char_Rare.SetActive(false);
            Char_Epic.SetActive(true);
            return;
        }
        if (numberChar == 3)
        {
            numberChar = 4;
            Char_Epic.SetActive(false);
            Char_Lengend.SetActive(true);
            return;
        }
        if (numberChar == 4)
        {
            numberChar = 1;
            Char_Lengend.SetActive(false);
            Char_Common.SetActive(true);
            return;
        }
    }

    public void L_Machine()
    {
        if (numberMachine == 1)
        {
            numberMachine = 4;
            Ma_Common.SetActive(false);
            Ma_Lengend.SetActive(true);
            return;
        }
        if (numberMachine == 2)
        {
            numberMachine = 1;
            Ma_Rare.SetActive(false);
            Ma_Common.SetActive(true);
            return;
        }
        if (numberMachine == 3)
        {
            numberMachine = 2;
            Ma_Epic.SetActive(false);
            Ma_Rare.SetActive(true);
            return;
        }
        if (numberMachine == 4)
        {
            numberMachine = 3;
            Ma_Lengend.SetActive(false);
            Ma_Epic.SetActive(true);
            return;
        }
    }

    public void R_Machine()
    {
        if (numberMachine == 1)
        {
            numberMachine = 2;
            Ma_Common.SetActive(false);
            Ma_Rare.SetActive(true);
            return;
        }
        if (numberMachine == 2)
        {
            numberMachine = 3;
            Ma_Rare.SetActive(false);
            Ma_Epic.SetActive(true);
            return;
        }
        if (numberMachine == 3)
        {
            numberMachine = 4;
            Ma_Epic.SetActive(false);
            Ma_Lengend.SetActive(true);
            return;
        }
        if (numberMachine == 4)
        {
            numberMachine = 1;
            Ma_Lengend.SetActive(false);
            Ma_Common.SetActive(true);
            return;
        }
    }

    public void Campaign()
    {
        SceneManager.LoadScene("ChooseMap");
        // Luu character, machine
        PlayerPrefs.SetInt("Character", numberChar);
        PlayerPrefs.SetInt("Machine", numberMachine);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
