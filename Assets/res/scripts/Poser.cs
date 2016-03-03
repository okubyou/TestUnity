using UnityEngine;
using System.Collections;

public class Poser : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            pose();
        }
    }

    public void pose(){
        if (Time.timeScale == 0) {
            Time.timeScale = 1.0f;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        } else {
            Time.timeScale = 0;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
