using UnityEngine;
using System.Collections;

//charControllerの中心や高さをアニメーションに対応しオフセットや縮小します
public class f02_offseter : StateMachineBehaviour {

    CharacterController charController;
    [SerializeField] Vector3 offSet;
    [SerializeField] float heightRate = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        charController = animator.GetComponent<CharacterController>();
        charController.center = charController.center * heightRate;
        charController.height = charController.height * heightRate;
        charController.center = charController.center + offSet;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        charController.center = charController.center - offSet;
        charController.height = charController.height / heightRate;
        charController.center = charController.center / heightRate;    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
