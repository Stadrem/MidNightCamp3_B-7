using UnityEngine;

public class CamRotate : MonoBehaviour
{
    
    // 회전 속도 변수
    public float rotSpeed = 200f;
    
    // 회전 값 변수
    private float mx = 0;
    private float my = 0;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        /*// 게임 상태가 '게임 중' 상태일 때만 조작할 수 있게 한다.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }*/
        
        
        
        // 사용자의 마우스 입력을 받아 물체를 회전 시키기.
        // 1. 마우스 입력 받기
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");
        
        // 1-1. 회전 값 변수에 마우스 입력 값만큼 미리 누적
        mx += mouse_X * rotSpeed * Time.deltaTime * 2  ; 
        my += mouse_Y * rotSpeed * Time.deltaTime * 2  ;
        
        // 1-2. 마우스 상하 이동 회전변수 (my) 값을 -90에서 90으로 제한
        my = Mathf.Clamp(my, -90f, 90f);
        
        
        
        
        
        // 2. 마우스 입력값을 이용해 회전 방향을 결정한다  ( 카메라 회전 방향 설정)
        //Vector3 dir = new Vector3(-mouse_Y, mouse_X, 0);
        transform.eulerAngles = new Vector3(-my, mx, 0);
        
        /*// 3. 회전 방향으로 물체 회전
         // r = r0 + vt
         transform.eulerAngles += dir * rotSpeed * Time.deltaTime;

         // 4. x, y 축 회전(사람시선 상하 회전)값을 -90 에서 90도로 제한하기 (이미 돼있긴 한거 같긴함. 뭐지?)
         Vector3 rot = transform.eulerAngles;
         rot.x = Mathf.Clamp(rot.x, -90f, 90f);
         transform.eulerAngles = rot;*/
         
         
         
         
    }
}