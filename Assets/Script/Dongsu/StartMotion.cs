using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMotion : MonoBehaviour
{

    GameObject player;

    public GameObject ui;

    Player playerScript;

    CamRotate camRotate;

    bool isRotating = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        playerScript = player.GetComponent<Player>();

        camRotate = Camera.main.GetComponent<CamRotate>();

        playerScript.enabled = false;

        camRotate.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Y축 회전
        if (isRotating == true)
        {
            player.transform.rotation *= Quaternion.Euler(0, 10 * Time.deltaTime, 0);
        }

        // 아무 키나 누르면 회전 중단 및 위치 이동
        if (Input.anyKeyDown)
        {
            isRotating = false;

            player.transform.position = new Vector3(0.00f, 0.57f, -8.23f);

            player.transform.rotation = Quaternion.Euler(0, 0, 0);

            ui.SetActive(false);

            camRotate.enabled = true;

            playerScript.enabled = true;

            this.enabled = false;
        }
    }
}
