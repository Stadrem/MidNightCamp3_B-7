using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    
    //  캐릭터 콘트롤러 변수
    private CharacterController cc;
    
    // 플레이어 애니메이터 변수
    private Animator anim; 

    
    // 수직 속력 변수
    private float yVelocity = 0;
    
    // 중력 변수
    private float gravity = -10f;
    
    
    // 점프 상태 변수 (점프 중이 아닐때만 점프 하게 만들기 위해서 )
    public bool isJumping = false;

    
    // 점프력 변수
    public float jumpPower = 2f;
    
    // 이동 속도 변수
    public float moveSpeed = 7f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        cc = GetComponent<CharacterController>();
        
        
        // 플레이어 애니메이터 받아오기
        anim = GetComponentInChildren<Animator>();

    }
    
    void Update()
    {
        
        // 1. 사용자 입력 받기 
        float h = Input.GetAxis("Horizontal"); // 좌우 
        float v = Input.GetAxis("Vertical");  // 상하 
        
        
        // 2. 이동 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;


        // 2-1. 메인 카메라를 기준으로 방향을 변환
        dir = Camera.main.transform.TransformDirection(dir);
        
        
        // 2-2. 캐릭터 수직 속도에 중력 값을 적용 
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        
        // 2-2. 만일 스페이스키를 눌렀다면
        if (Input.GetButtonDown("Jump"))
        {
            /*// 캐릭터 수직 속도에 점프력을 적용한다
            yVelocity = jumpPower;*/
            
            // 2-2. 만일 점프중이었고, 다시 바닥에 착지했다면...
           
            if (cc.collisionFlags == CollisionFlags.Below)  
            {
                // 만일 점프 중이었다면...
                if (isJumping)  
                {
                    // 점프 전 상태로 초기화 하기
                    isJumping = false;
                
                    // 캐릭터 수직 속도를 0으로 만들기 
                    yVelocity = 0;  
                    
                }
            }

        }
        
        // 2-3. 캐릭터 수직 속도에 중력 값을 적용한다
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        
        // 2-3. 만일, 키보드 스페이스키를 입력했고, 점프를 하지 않은 상태라면...
        if (Input.GetButtonDown("Jump") && !isJumping)  
        {
            // 캐릭터 수직 속도에 점프력을 적용하고 점프 상태로 변경한다. 
            yVelocity = jumpPower/4;
            isJumping = true;
            
        }
        
        /*// 3. 이동 속도에 맞춰 이동한다
        cc.Move(dir * moveSpeed * Time.deltaTime);*/
        
        // 3. 이동 속도에 맞춰 이동 
        // p = p0 + vt
        transform.position += dir * moveSpeed * Time.deltaTime;
        cc.Move(dir * moveSpeed * Time.deltaTime);
        
        
    }
    
    
}
