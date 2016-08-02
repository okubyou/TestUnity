using UnityEngine;
using System.Collections;

public class gunPositionController : MonoBehaviour {

    public Transform aimTarget;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        int layerMask = 3 << 8;// 8 : Player layer 9: enemy view sited
        layerMask = ~layerMask;
        RaycastHit hit;

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * 10, Color.magenta);
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
            transform.LookAt(hit.point);
        } else {
            transform.LookAt(aimTarget);
        }

        Vector3 targePosition = hit.point;
        Debug.DrawLine(transform.position, targePosition, Color.cyan);

    }
}