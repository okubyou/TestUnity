using UnityEngine;
using System.Collections;

public class viewTriger : MonoBehaviour {

    private GameObject _parent;
    CharacterController charContrller;
    Vector3 targetPosition;

    // Use this for initialization
    void Start () {
        //親オブジェクトを取得
        _parent = transform.parent.gameObject;
        Debug.Log(_parent.name);

    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerStay(Collider _collider) {
        if (_collider.gameObject.CompareTag("Player")){
            //_collider.transform.positionとCharacterControllerの中心のズレを補正
            charContrller = _collider.GetComponent<CharacterController>();
            targetPosition = _collider.transform.position + charContrller.center;
            //視界用のコライダーのレイヤーはenemyViewSitにする必要があります　:パラメータで設定できるようにしたい
            if (!Physics.Linecast(targetPosition, _parent.transform.position,9)){// 9 : enemyViewSite layer
                _parent.SendMessage("inSite");
            }
        }
    }

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.CompareTag("Player")){
            _parent.SendMessage("enterSite");
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            _parent.SendMessage("exitSite");
        }
    }
}

