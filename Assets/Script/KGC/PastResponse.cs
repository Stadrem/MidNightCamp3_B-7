using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PastResponse : MonoBehaviour
{
    public Text responses;
    public int page;
    List<string> rList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 20; i++)
        {
            rList.Add(i.ToString());
        }
        responses.text = rList[page];
    }
    
    public void Prev()
    {
        if (page != 0)
        {
            page--;
            responses.text = rList[page];

        }
    }

    public void Next()
    {
        if (page != rList.Count-1)
        {
            page++;
            responses.text = rList[page];

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rList.Add("Test");
        }
    }
}
