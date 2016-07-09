using UnityEngine;
using System.Collections;

public class aimCamera : MonoBehaviour {

    public Transform target;
    public float miniDistance;
    private Animator animator;
    bool aiming = false;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftControl)) {
            animator.SetBool("aim", true);
            aiming = true;
        } else {
            animator.SetBool("aim", false);
            aiming = false;
        }
    }

    void LateUpdate() {
        int layerMask = 1 << 8;// 8 : Player layer
        Vector3 distance = (target.position - Camera.main.transform.position);
        if(distance.sqrMagnitude < (miniDistance * miniDistance)) {
            if(aiming) {
                Camera.main.cullingMask = Camera.main.cullingMask & ~layerMask;
            }
        } else {
            Camera.main.cullingMask = Camera.main.cullingMask | layerMask; 
        }
    }
}
