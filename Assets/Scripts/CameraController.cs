using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [Header("Чувствительность мыши")]
    public float sensiviteMouse = 200f;

    public Transform Player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // заблокировали наш курсор
    }


    void Update()
    {
        // Input.GetAxis() - ввод по осям 
        mouseX = Input.GetAxis("Mouse X") * sensiviteMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensiviteMouse * Time.deltaTime;

        Player.Rotate(mouseX * new Vector3(0, 1, 0));

        // указываем тот объект который будет весеть этот скрипт, то есть на камере
        transform.Rotate(-mouseY * new Vector3(1, 0, 0)); // указываем -mouseY для того чтобы у нас камера поварачивалась туда куда нам надо
    }
}
