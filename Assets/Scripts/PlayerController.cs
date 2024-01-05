using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // GetKey - ���� �� ������ ������,
    // GetKeyDown - ���� �� ������ �� ������
    // GetKeyUp - ���� �� ������ ����� � ������

    [Header("�������� ����������� ���������")] // Header ����� ������������ � Unity
    public float speed = 7f; // �������� � ������� ����� ������������� ��� ��������

    [Header("���� ������")]
    public float jumpPower = 200f;

    [Header("��������� ���������")]
    public float runSpeed = 15f;

    [Header("�� �� �����?")]
    public bool ground;

    public Rigidbody rb;

    private void Update()
    {
        GetInput();
    }
    private void GetInput() 
    {
        // ����������� ��������� 
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime; // forward - ��������� �� ��,
                                                                                          // ��� �������� ����� ���� ����� �� ����� ����������
            else 
                transform.localPosition += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.localPosition += -transform.forward * runSpeed * Time.deltaTime; // ��������� ��������� �������� �.� ������� "�����"
                                                                                           // ����
            else
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.localPosition += -transform.right * runSpeed * Time.deltaTime; // ��������� ��������� �������� �.� ������� "�����" ����

            else
                transform.localPosition += -transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.localPosition += transform.right * runSpeed * Time.deltaTime;

            else
                transform.localPosition += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground == true)
            {
                rb.AddForce(transform.up * jumpPower);
            }
        }

    }

    // ������ ����� ��������, � ����� ��������� �� �����������
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            // �� �� �����
            ground = true;
        }
    }

    public void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            // �� �� �� �����
            ground = false;
        }
    }
}
