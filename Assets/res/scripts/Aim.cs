using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButton(0)) {
            animator.SetBool("fire", true);
        } else {
            animator.SetBool("fire", false);
        }

        if(Input.GetMouseButton(1)) {
            animator.SetBool("aim", true);
            gameObject.GetComponent<HeadLookController>().enabled = true;

            if(Vector3.Angle(
                new Vector3(transform.forward.x, 0, transform.forward.z),
                new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z)
                ) > 90
            )
                transform.forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        } else{
            animator.SetBool("aim", false);
            gameObject.GetComponent<HeadLookController>().enabled = false;
        }
    }

}
