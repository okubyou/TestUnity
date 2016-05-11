using UnityEngine;
using System.Collections;

public class Enemycontroller : MonoBehaviour {

    Rigidbody rb;
    //SoundManager soundMgr;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void inSite(){
        GameManager.startAlertMode();
        //soundMgr.playSound();
    }

    void enterSite(){
        
    }

    void exitSite(){

    }

}
