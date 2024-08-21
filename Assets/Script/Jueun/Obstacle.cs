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
    bool enterOk = false;
    bool chatOpen = false;

    PlayerMove playerScript;
    GameObject player;
    CamRotate camRotate;

    private void Start()
    {
        player = GameObject.Find("Player");

        playerScript = player.GetComponent<PlayerMove>();

        camRotate = Camera.main.GetComponent<CamRotate>();

      
    }
    // Update is called once per frame
    void Update()
    {
        if (enterOk == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            //if (Input.GetButtonDown("E")) 
            {
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.Play();
                ChatText.SetActive(true);
                chatOpen = true;

                playerScript.enabled = false;

                camRotate.enabled = false;

            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                ChatText.SetActive(false);
                chatOpen= false;
            }
        }
      
        

    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interaction.SetActive(true);
            enterOk = true;
              
            
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        ChatText.SetActive(false);
        
        if (other.gameObject.CompareTag("Player"))
        {
            interaction.SetActive(false);
            enterOk = false;
           
        }
        
    }
    
    
}
