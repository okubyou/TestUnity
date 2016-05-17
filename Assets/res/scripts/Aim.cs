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
        if (Input.GetMouseButton(1)){
            animator.SetBool("aim", true);
        
            if(Vector3.Angle(
                new Vector3(transform.forward.x, 0, transform.forward.z), 
                new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z)
                ) > 45
            ) 
            transform.forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        }
    }

}
