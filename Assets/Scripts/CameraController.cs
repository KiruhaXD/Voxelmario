using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [Header("���������������� ����")]
    public float sensiviteMouse = 200f;

    public Transform Player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ������������� ��� ������
    }


    void Update()
    {
        // Input.GetAxis() - ���� �� ���� 
        mouseX = Input.GetAxis("Mouse X") * sensiviteMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensiviteMouse * Time.deltaTime;

        Player.Rotate(mouseX * new Vector3(0, 1, 0));

        // ��������� ��� ������ ������� ����� ������ ���� ������, �� ���� �� ������
        transform.Rotate(-mouseY * new Vector3(1, 0, 0)); // ��������� -mouseY ��� ���� ����� � ��� ������ �������������� ���� ���� ��� ����
    }
}
