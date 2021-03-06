﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class RigidBodyController: MonoBehaviour {

    //private CharacterController charController;
    private Rigidbody rigidBody;
    private Animator animator;

    [SerializeField]
    float speed = 2.0f;

    // Use this for initialization
    void Start() {
        //charController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        //カメラからみた入力の前後左右を取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 direction = cameraForward * Input.GetAxis("Vertical") +
            Camera.main.transform.right * Input.GetAxis("Horizontal");

        //単位(?)化
        direction = direction.normalized;

        //ジャンプ
        if(Input.GetButtonDown("Jump")) {
            //charController.SimpleMove(new Vector3(10, 30, 0));
        }

        //歩き
        if(Input.GetKey(KeyCode.LeftShift)) {
            direction *= 0.3f;              //XXX magic number
        }

        //しゃがみ
        //
        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            animator.SetBool("onAllFours", true);//しゃがみフラグ
        }
        if(Input.GetKey(KeyCode.LeftControl)) {
            direction *= 0.22f; // !!! Magic Number !!! 

        }
        if(Input.GetKeyUp(KeyCode.LeftControl)) {
            animator.SetBool("onAllFours", false);
        }


        //入力の残滓で急激に方向が変わるのを抑制
        if(Math.Abs(Input.GetAxis("Vertical")) > 0.2f || Math.Abs(Input.GetAxis("Horizontal")) > 0.2f) {
            //transform.forward = direction;
          //  rigidBody.MoveRotation(direction);
        }

        animator.SetFloat("forward", (direction * speed).magnitude);

        //移動処理
        //rigidBody.velocity = new Vector3((direction.x * speed), rigidBody.velocity.y, (direction.z * speed));
        rigidBody.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    void FixedUpdate() {
        //アニメーターに前進速度を設定
        
    }
}