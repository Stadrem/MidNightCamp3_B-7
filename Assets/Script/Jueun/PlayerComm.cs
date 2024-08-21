using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComm : MonoBehaviour
{

    // public GameObject chat;
    public GameObject KGC_Scenes;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
        // 범위내에서 
        
        
        // E 버튼 클릭시 상호작용 
        if (Input.GetKeyDown(KeyCode.E))
        {
            KGC_Scenes.SetActive(true);
            
        }

        
        
        
        
    }
}
