using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Obstacle : MonoBehaviour
{


    public GameObject interaction;
    public GameObject ChatText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
            //if (Input.GetButtonDown("E"))
        {

            ChatText.SetActive(true);
            
            // 오디오 소스 생성해서 추가
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.playOnAwake = true;
                
        }
        if (Input.GetKeyDown(KeyCode.X))
            //if (Input.GetButtonDown("E"))
        {

            ChatText.SetActive(false);
            
                
        }
    }
    

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
  
            interaction.SetActive(true);
  
        }
    }
    
        
    void OnTriggerExit(Collider other)

    {
        ChatText.SetActive(false);
        
        if (other.gameObject.CompareTag("Player"))
        {
            interaction.SetActive(false);
        }
        
        
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}
