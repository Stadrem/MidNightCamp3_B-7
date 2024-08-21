using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PastResponse : MonoBehaviour
{
    public Text responses;
    public int page;
    public List<string> rList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

        rList.Add(responses.text);
        
        rList.Add(responses.text);
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
            rList.Add(responses.text);
        }
    }

    public void TextUpload(string outPut)
    {
        rList.Add(outPut);
    }
}
