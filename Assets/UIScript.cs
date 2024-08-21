using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    PlayerMove playerScript;
    GameObject player;
    CamRotate camRotate;
    private void Start()
    {
        player = GameObject.Find("Player");

        playerScript = player.GetComponent<PlayerMove>();

        camRotate = Camera.main.GetComponent<CamRotate>();
    }
    // Start is called before the first frame update
    public void Close()
    {

        playerScript.enabled = true;

        camRotate.enabled = true;
        gameObject.SetActive(false); 
    }

}
