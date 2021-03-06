﻿using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	
	void Update () {

        if(Input.GetMouseButton(0)) {
            animator.SetBool("fire", true);
        } else {
            animator.SetBool("fire", false);
        }

        if(Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftControl)) {
            if(!Input.GetKeyDown(KeyCode.LeftControl)) {
                animator.SetBool("aim", true);
                gameObject.GetComponent<HeadLookController>().enabled = true;
                gameObject.GetComponent<IKController>().enabled = true;
                //if(Vector3.Angle(
                //    new Vector3(transform.forward.x, 0, transform.forward.z),
                //    new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z)
                //    ) > 90
                //){
                
                transform.forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
                //}
            }
        }else{
            animator.SetBool("aim", false);
            gameObject.GetComponent<HeadLookController>().enabled = false;
            gameObject.GetComponent<IKController>().enabled = false;
        }
    }

}
