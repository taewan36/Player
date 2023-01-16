using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigid;
    public int JumpPower;
    public int MoveSpeed;

    private bool IsJumping;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();  //Rigidbody 컴포넌트를 받아옴
        IsJumping = false;                  //점프 중인지 판단할 수 있도록 bool값 생성,초기화
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    

  
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate((new Vector3 (h ,0 ,v) * MoveSpeed) * Time.deltaTime);
    }

    void Jump()
    {
        //스페이스 키를 누르면 점프
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if (!IsJumping)
            {
                //print("점프가능");
                IsJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
            //공중에 떠있는 상태이면 점프하지 못하도록 리턴
            else
            {
                //print(점프 불가능)
                return;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //바닥에 닿으면
        if(collision.gameObject.CompareTag("Ground"))
        {
            //점프가 가능한 상태로 만듦
            IsJumping = false;
        }
    }



}


