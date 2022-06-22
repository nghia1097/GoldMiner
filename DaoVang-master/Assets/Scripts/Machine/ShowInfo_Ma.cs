using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo_Ma : MonoBehaviour
{
    public Text txtPower, txtSpeed_M;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtPower.text = "Power: " + GetComponent<InfoMachine>().power.ToString();
        txtSpeed_M.text = "Speed: " + GetComponent<InfoMachine>().Speed.ToString();
    }
}
