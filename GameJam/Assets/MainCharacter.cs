using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    //declareations
    //Character Main 
    private GameObject Character;
    private Rigidbody Rigidbody;
    //Movement 
    [Range(1, 6)][SerializeField] float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Variable defines
        Character = transform.gameObject;
        Rigidbody = transform.GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Movement();   
    }


    private void Turn()
    {
        float mouseX = Input.GetAxis("MouseX");
        float mouseY = Input.GetAxis("MouseY");
    }

    private void Movement()
    {
        float horizontal =Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Rigidbody.velocity = new Vector3(horizontal * movementSpeed,0, vertical * movementSpeed);

        print(Rigidbody.velocity);


    }
}
