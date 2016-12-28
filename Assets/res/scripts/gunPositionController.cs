using UnityEngine;
using System.Collections;

public class gunPositionController : MonoBehaviour {

    public Transform aimTarget;
    RaycastHit hit;
    GameObject childObject;
    public Vector3 hitPoint;

    // Use this for initialization
    void Start () {
        childObject = gameObject.transform.FindChild("gunPosition").gameObject;
    }

    // Update is called once per frame
    void Update() {
        //protectFromWall();
    }

    void LateUpdate(){

        protectFromWall();

        int layerMask = 3 << 8;// 8 : Player layer 9: enemy view sited
        layerMask = ~layerMask;

        
        transform.LookAt(aimTarget, Camera.main.transform.up);
             Debug.DrawRay(Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.TransformDirection(Vector3.forward) * 10, Color.magenta);
        if(Physics.Raycast(Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
            
            //Debug.Log(((transform.position - hit.point).normalized - Camera.main.transform.forward).magnitude);
            //体の後ろ側を狙わないようにする処理 (カメラとhit.pointが近すぎる場合はhit.pointをで上書きしない)
            //if((((transform.position - hit.point).normalized - Camera.main.transform.forward).magnitude) > 0.5) {    
                //↓ Angle()とかつかってもっとシンプルにできそう
                hitPoint = (hit.point - transform.position).normalized - transform.parent.forward;
                transform.LookAt(hit.point, Camera.main.transform.up);
            //}            
        }

       // Vector3 targePosition = hit.point;
       // Debug.DrawLine(transform.position, targePosition, Color.cyan);
    }

    void protectFromWall() {
        int layerMask = 3 << 8;// 8 : Player layer 9: enemy view site
        layerMask = ~layerMask;
        RaycastHit gunPositionHit;


        //銃の位地が壁にめり込まないようにする処理
        Vector3 basePosition = (transform.position + transform.forward * 0.42f);
        if(Physics.Linecast(transform.position, basePosition, out gunPositionHit, layerMask, QueryTriggerInteraction.Ignore)) {
            childObject.transform.position = gunPositionHit.point;
            //childObject.transform.position = childObject.transform.position - transform.forward;
        } else {
            childObject.transform.position = basePosition;
        }
    }
}