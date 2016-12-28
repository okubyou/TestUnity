using UnityEngine;
using UnityEngine.Networking;

public class NavigatorController : NetworkBehaviour {

    Vector3 inputVector = new Vector3();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");
        transform.position += inputVector * 4 * Time.deltaTime; 

	}
}
