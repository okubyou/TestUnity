using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

    public Transform aimTarget;
    public Transform barrelTransform;

    RaycastHit hit;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void LateUpdate() {
      
        int layerMask = 3 << 8;// 8 : Player layer 9: enemy view sited
        layerMask = ~layerMask;
        Vector3 targetPoint;

        //銃がオブジェクトにめりこんだ際に手首がおかしな角度まで曲がるのを防止 
        if(Physics.Raycast(Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)
        && ((hit.point - barrelTransform.position).magnitude > 0.5f)) {
            targetPoint = hit.point;
            //barrelTransform.LookAt(hit.point, Camera.main.transform.up);
        } else {
            targetPoint = transform.position + transform.parent.forward;
                //aimTarget.position;// transform.position;// + transform.forward //
            //barrelTransform.LookAt(aimTarget, Camera.main.transform.up);
        }

        barrelTransform.LookAt(targetPoint, Camera.main.transform.up);
        transform.forward = barrelTransform.forward;
        //なんか左に倒して構えちゃうので回転させて縦に構えさせる
        transform.Rotate(Vector3.forward, -90);

        Vector3 targePosition = hit.point;
        Debug.DrawLine(transform.position, targePosition, Color.cyan);
    }
}
