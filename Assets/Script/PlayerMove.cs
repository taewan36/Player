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
        rigid = GetComponent<Rigidbody>();  //Rigidbody ������Ʈ�� �޾ƿ�
        IsJumping = false;                  //���� ������ �Ǵ��� �� �ֵ��� bool�� ����,�ʱ�ȭ
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
        //�����̽� Ű�� ������ ����
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if (!IsJumping)
            {
                //print("��������");
                IsJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
            //���߿� ���ִ� �����̸� �������� ���ϵ��� ����
            else
            {
                //print(���� �Ұ���)
                return;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�ٴڿ� ������
        if(collision.gameObject.CompareTag("Ground"))
        {
            //������ ������ ���·� ����
            IsJumping = false;
        }
    }



}


