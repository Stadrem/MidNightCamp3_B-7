using System;
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
                
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChatText.SetActive(false);
            
        }
    }

    

    void OnTriggerStay(Collider other)
    {

        // E 사운드
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();

        }
        
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
