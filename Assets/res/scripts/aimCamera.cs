using UnityEngine;
using System.Collections;

public class aimCamera : MonoBehaviour {

    public Transform target;
    public float miniDistance;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(1)) {
            animator.SetBool("aim", true);
            //transform.GetComponent<cameraScript>().enabled = true;
            //aimcamera 有効化
        } else {
            animator.SetBool("aim", false);
            //transform.GetComponent<cameraScript>().enabled = false;
        }
    }

    void LateUpdate() {
        Vector3 distance = (target.position - Camera.main.transform.position);
        if(distance.sqrMagnitude < (miniDistance * miniDistance)) {
            int layerMask = 1 << 8;// 8 : Player layer 
            layerMask = ~layerMask;
            Camera.main.cullingMask = layerMask;
            Debug.Log("in");
        } else {
            Camera.main.cullingMask = ~0;
            Debug.Log("out");
        }
    }
}
