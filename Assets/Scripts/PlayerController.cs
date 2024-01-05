using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // GetKey - если мы зажали кнопку,
    // GetKeyDown - если мы нажали на кнопку
    // GetKeyUp - если мы убрали палец с кнопки

    [Header("Скорость перемещения персонажа")] // Header будет показываться в Unity
    public float speed = 7f; // скорость с которой будет передвигаться наш персонаж

    [Header("Сила прыжка")]
    public float jumpPower = 200f;

    [Header("Ускорение персонажа")]
    public float runSpeed = 15f;

    [Header("Мы на земле?")]
    public bool ground;

    public Rigidbody rb;

    private void Update()
    {
        GetInput();
    }
    private void GetInput() 
    {
        // перемещение персонажа 
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime; // forward - указывает на то,
                                                                                          // что персонаж будет идти прямо по своей координате
            else 
                transform.localPosition += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.localPosition += -transform.forward * runSpeed * Time.deltaTime; // указываем минусовое значение т.к команды "назад"
                                                                                           // нету
            else
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.localPosition += -transform.right * runSpeed * Time.deltaTime; // указываем минусовое значение т.к команды "влево" нету

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

    // данный метод отвечает, с какой проблемой мы столкнулись
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            // мы на земле
            ground = true;
        }
    }

    public void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            // мы не на земле
            ground = false;
        }
    }
}
