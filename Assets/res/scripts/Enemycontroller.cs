using UnityEngine;
using System.Collections;

public class Enemycontroller : MonoBehaviour {

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void inSite(){

    }

    void enterSite(){
        GameManager.startAlertMode();
    }

    void exitSite(){

    }

}
