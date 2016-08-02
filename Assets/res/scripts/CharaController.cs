using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CharaController : MonoBehaviour {

    private CharacterController charController;
    private Animator animator;
    public Vector3 direction;
    public bool AIM = false;
    [SerializeField] float speed = 2.0f;
    private Vector3 moveDirection;

    // Use this for initialization
    void Start() {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update() {

        //カメラからみた入力の前後左右を取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        direction = cameraForward * Input.GetAxis("Vertical") +
            Camera.main.transform.right * Input.GetAxis("Horizontal");

        //単位(?)化
        direction = direction.normalized;

        //ジャンプ
        if (Input.GetButtonDown("Jump")) {
            //charController.SimpleMove(new Vector3(10, 30, 0));
        }

        //歩き
        if (Input.GetKey(KeyCode.LeftShift)) {
            direction *= 0.3f;              //XXX magic number
        }

        //しゃがみ
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            animator.SetBool("onAllFours", true);//しゃがみフラグ
        }
        if (Input.GetKey(KeyCode.LeftControl)) {
            direction *= 0.22f; // !!! Magic Number !!!   
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            animator.SetBool("onAllFours", false);
        }

        //入力の残滓で急激に方向が変わるのを抑制
        if (Math.Abs(Input.GetAxis("Vertical")) > 0.14f || Math.Abs(Input.GetAxis("Horizontal")) > 0.14f) {
            transform.forward = direction;
        }

        //構え  // 注 : 方向の変更を行う
        aim();

        //移動処理
        moveDirection = moveDirection * 0.9f;
        moveDirection = moveDirection + direction * 0.2f;
        if(moveDirection.magnitude > 1) {
            moveDirection = moveDirection.normalized;
        }
        charController.SimpleMove(moveDirection * speed);
        if(moveDirection.magnitude < 0.01f) {
            moveDirection = new Vector3(0,0,0);
        }

        //アニメーターに前進速度を設定
        animator.SetFloat("forward", moveDirection.magnitude);

    }

    void aim(){
        if(Input.GetMouseButton(0)) {
            animator.SetBool("fire", true);
        } else {
            animator.SetBool("fire", false);
        }

        if((Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftControl)) || AIM) {
            if(!Input.GetKeyDown(KeyCode.LeftControl)) {
                animator.SetBool("aim", true);
                gameObject.GetComponent<HeadLookController>().enabled = true;
                gameObject.GetComponent<IKController>().enabled = true;
                //if(Vector3.Angle(
                //    new Vector3(transform.forward.x, 0, transform.forward.z),
                //    new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z)
                //    ) > 90
                //){

                transform.forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
                //}
            }
        } else {
            animator.SetBool("aim", false);
            gameObject.GetComponent<HeadLookController>().enabled = false;
            gameObject.GetComponent<IKController>().enabled = false;
        }
    }
}
