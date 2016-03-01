using UnityEngine;
using System.Collections;   

[RequireComponent(typeof(Animator))]

public class MotionController : MonoBehaviour{

    [SerializeField]float speed = 2;

    void OnAnimatorMove(){
        Animator animator = GetComponent<Animator>();
        CharacterController cContoroller = GetComponent<CharacterController>();

        if (animator){

            //newPosition.z += animator.GetFloat("Forward") * Time.deltaTime;
            //transform.position += transform.forward * animator.GetFloat("Forward") * Time.deltaTime * speed;
            //rBody.AddForce(transform.forward* animator.GetFloat("Forward") * frontForce);
            //Vector3 newPosition = (transform.position + transform.forward * animator.GetFloat("Forward") * speed * Time.deltaTime);
            //    rBody.velocity = (transform.forward * animator.GetFloat("Forward") * speed);
            cContoroller.Move(transform.forward * animator.GetFloat("Forward") * speed * Time.deltaTime);
        };
           
    }
}

