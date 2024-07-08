using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MainCharacter : MonoBehaviour
{
    //declarations
    //Character Main 
    private GameObject character;
    private Rigidbody rigidBody;
    private Transform characterBody;
    //Movement 
    [Range(100, 600)][SerializeField] float movementSpeed = 300;
    float turnSmoothVelocity;
    float turnSmoothTime = 0.1f;



    void Start()
    {
        //Variable defines
        character = transform.gameObject;
        characterBody = character.transform;
        rigidBody = transform.GetComponent<Rigidbody>();



    }


    void Update()
    {
        cameraTurn();
        Movement();   
    }


    private void cameraTurn()// if we want to turn camera for now , it is empty
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
  

    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical   = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = (new Vector3(horizontal, 0, vertical));

        if (direction.magnitude != 0)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 45f; //Target angle where the turn ends.
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);// Smooth the go Target Angle. turnSmooth Time changes smoothnes  turnSmoothVelocity is nothing to do with us
            transform.rotation = Quaternion.Euler(0f, angle, 0f);// Turn to the current angle


            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;// To go which we look it is basicaly go with 45 degrees diff.


            rigidBody.velocity = moveDirection * movementSpeed * Time.deltaTime; // Main Movement Line

            
        }



        //rigidBody.velocity = movementDirection * movementSpeed * Time.deltaTime;

        //print(rigidBody.velocity);


    }
}
