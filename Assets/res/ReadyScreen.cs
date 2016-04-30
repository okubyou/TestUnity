using UnityEngine;
using System.Collections;

public class ReadyScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown) {
            GameManager.setMode(GameManager.NORMAL);
            Time.timeScale = 1;
            Destroy(transform.gameObject);
        }
	}
}
