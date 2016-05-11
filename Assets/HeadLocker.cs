using UnityEngine;
using System.Collections;

public class HeadLocker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.LeftAlt)){
            gameObject.GetComponent<HeadLookController>().enabled = false;
        }
        if(Input.GetKeyUp(KeyCode.LeftAlt)){
            gameObject.GetComponent<HeadLookController>().enabled = true;
        }
    }
}
