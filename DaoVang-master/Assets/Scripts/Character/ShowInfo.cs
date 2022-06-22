using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    public Text txtStamina, txtSpeed_C;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtStamina.text = "Stamina: " + gameObject.GetComponent<InfoCharecter>().Stamina.ToString();
        txtSpeed_C.text = "Speed: " + gameObject.GetComponent<InfoCharecter>().Speed.ToString();
    }
}
