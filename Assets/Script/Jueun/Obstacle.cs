using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Obstacle : MonoBehaviour
{

    public GameObject viewPos;
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

                chatOpen = true;
                if (chatOpen)
                {
                    chatOpen = false;
                    StartCoroutine(MovePos());
                }

                //player.transform.position = Vector3.Lerp(player.transform.position, viewPos.transform.position, Time.deltaTime);
                //Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, viewPos.transform.rotation, Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                ChatText.SetActive(false);
                chatOpen= false;
            }
        }
      
        

    }

    IEnumerator MovePos()
    {
        for (int i = 0; i < 20; i++)
        {
            float interval = (float)i / 19;
            print(interval);
        player.transform.position = Vector3.Lerp(player.transform.position, viewPos.transform.position, interval);
        Camera.main.transform.rotation =  Quaternion.Lerp(Camera.main.transform.rotation, viewPos.transform.rotation, interval);
            yield return null;
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
