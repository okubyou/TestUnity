using UnityEngine;
using System.Collections;

public class f02_model_offseter : StateMachineBehaviour {

    Transform modelPosition;
    [SerializeField]
    Vector3 offSet;
    [SerializeField]
    float heightRate = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        modelPosition = animator.transform.FindChild("models").transform;
        Debug.Log(animator.transform.FindChild("models").transform.localPosition);
        modelPosition.localPosition = modelPosition.localPosition + offSet;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log(animator.transform.FindChild("models").transform.localPosition);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        modelPosition.localPosition = modelPosition.localPosition - offSet;
    }
}
