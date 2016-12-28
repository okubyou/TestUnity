using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKController: MonoBehaviour {

    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform rightHandHintObj = null;
    public Transform leftHandObj = null;
    public Transform leftHandHintObj = null;
    public Transform bodyObj = null;
    public Transform lookObj = null;


    void Start() {
        animator = GetComponent<Animator>();      
    }

    //a callback for calculating IK
    void OnAnimatorIK() {
        if(animator) {

            //if the IK is active, set the position and rotation directly to the goal. 
            if(ikActive) {

                animator.SetLookAtWeight(0.2f, 1.4f, 2f, 0.2f, 0.3f);

                if(bodyObj != null) {
                   // Vector3 bodyTargetPosition = lookObj.transform.position;
                   // bodyObj.LookAt(bodyTargetPosition);
                }

                if(rightHandHintObj != null) {
                    animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1);
                    animator.SetIKHintPosition(AvatarIKHint.RightElbow, rightHandHintObj.position);
                }

                if(leftHandHintObj != null) {
                    animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1);
                    animator.SetIKHintPosition(AvatarIKHint.LeftElbow, leftHandHintObj.position);
                }

                // Set the right hand target position and rotation, if one has been assigned
                if(rightHandObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }

                if(leftHandObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }

                // Set the look target position, if one has been assigned
                if(lookObj != null) {
                  
                    animator.SetLookAtPosition(lookObj.position);
                }
            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }

}