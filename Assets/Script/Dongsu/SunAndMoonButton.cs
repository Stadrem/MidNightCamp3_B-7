using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndMoonButton : MonoBehaviour
{
    public GameObject sunLight;
    bool isRotated = false;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 레이캐스트를 쏘기 위한 코드
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 2))
        {
            Debug.DrawRay(transform.position, -transform.up * 2, Color.red); // 디버그 레이 그리기
            if (hit.collider.CompareTag("Player"))
            {
                print("닿음");

                // E 키를 누르면 B 오브젝트의 X 회전 축 변경
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isRotated)
                    {
                        anim.SetTrigger("Click");
                        sunLight.transform.rotation = Quaternion.Euler(80, sunLight.transform.rotation.eulerAngles.y, sunLight.transform.rotation.eulerAngles.z);
                        RenderSettings.ambientIntensity = 1;
                    }
                    else
                    {
                        anim.SetTrigger("Click");
                        sunLight.transform.rotation = Quaternion.Euler(0, sunLight.transform.rotation.eulerAngles.y, sunLight.transform.rotation.eulerAngles.z);
                        RenderSettings.ambientIntensity = 0.5f;
                    }
                    isRotated = !isRotated; // 회전 상태 토글
                }
            }
        }
    }
}
