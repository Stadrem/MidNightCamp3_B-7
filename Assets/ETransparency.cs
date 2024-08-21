using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ETransparency : MonoBehaviour
{
    public GameObject ui1;
    public GameObject ui2;
    public Image me;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Color32 myColor =  me.color;
        if (ui1.activeInHierarchy || ui2.activeInHierarchy)
        {
            myColor.a = 0;
            me.color = myColor;
        }
        else
        {
            myColor.a = 255;
            me.color = myColor;
        }
    }
}
