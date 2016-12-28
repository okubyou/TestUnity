using UnityEngine;
using System.Collections;

public class FireLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position,transform.forward * 100, Color.red);
	}
}
