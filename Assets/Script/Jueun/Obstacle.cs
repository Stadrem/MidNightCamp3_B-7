using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Obstacle : MonoBehaviour
{


    public GameObject interaction;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
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
        if (other.gameObject.CompareTag("Player"))
        {
            interaction.SetActive(false);
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}
