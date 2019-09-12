﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 200f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update() { 
    //Debug.Log(Input.GetAxisRaw("Horizontal"));
    horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch")){
            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }
    }

    public void onLanding(){
        animator.SetBool("IsJumping", false);
    }

    public void onCrouching(bool isCrouching){
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate(){
        // Move our character
        //Three params, movement speed, ifCrouching, ifJumping
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
