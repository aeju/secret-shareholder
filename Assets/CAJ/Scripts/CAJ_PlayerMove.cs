using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;


//단, CharacterController를 사용

public class CAJ_PlayerMove : MonoBehaviourPun
{
    //속력
    public float moveSpeed = 5;
    //characterController 담을 변수
    CharacterController cc;

    //중력
    float gravity = -9.81f;
    //점프파워
    public float jumpPower = 5;
    //y방향 속력
    float yVelocity;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //만약에 내 것이 아니라면 함수를 나가겠다.
        if (photonView.IsMine == false) return;
        
        float h = Input.GetAxisRaw("Horizontal"); //A : -1, D : 1, 누르지 않으면 : 0
        float v = Input.GetAxisRaw("Vertical");

        //2. 받은 신호로 방향을 만든다.
        Vector3 dir = transform.forward * v + transform.right * h; // new Vector3(h, 0, v);
        //방향의 크기를 1로한다.
        dir.Normalize();

        //만약에 바닥에 닿아있다면 yVelocity를 0으로 하자
        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        //만약에 스페이바(Jump)를 누르면
        if (Input.GetButtonDown("Jump"))
        {
            //yVelocity에 jumpPower를 셋팅
            yVelocity = jumpPower;
        }

        //yVelocity값을 중력으로 감소시킨다.
        yVelocity += gravity * Time.deltaTime;

        //dir.y에 yVelocity값을 셋팅
        dir.y = yVelocity;

        //3. 그 방향으로 움직이자.
        //P = P0 + vt
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}