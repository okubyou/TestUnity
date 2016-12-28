using UnityEngine;
using System.Collections;

public class NetworkPlayer : MonoBehaviour {

    public GameObject freeLookCamera;

    // Use this for initialization
    void Start () { 
        Instantiate(freeLookCamera);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
