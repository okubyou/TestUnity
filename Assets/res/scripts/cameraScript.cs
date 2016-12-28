using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

    public Transform target;
    private Renderer stackRenderer;
    //private Transform mainCam;

    // Use this for initialization
    void Start () {
        //mainCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update() {

        int layerMask = 3 << 8;// 8 : Player layer 9: enemy view site
        layerMask = ~layerMask;
        RaycastHit hit;

        //壁ぴったりまで寄らないように終点は Camera.main.transform.forward 分手前にする
        if(Physics.Linecast(target.position, Camera.main.transform.position + Camera.main.transform.forward,
            out hit, layerMask, QueryTriggerInteraction.Collide)) {
            Camera.main.transform.position = hit.point;
        }

    }

}
