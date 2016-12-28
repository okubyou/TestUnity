using UnityEngine;
using System.Collections;

public class AoiSoundManager : MonoBehaviour {

    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    private Animator animator;
    CharaController charController;

    AnimatorStateInfo animationStateinfo;

    // Use this for initialization
    void Start (){
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        charController = gameObject.GetComponent<CharaController>();

        audioSource.clip = sound1;
    }
	
	// Update is called once per frame
	void Update(){
        

        if(animator.GetFloat("forward") > 2.5) {
            if(audioSource.isPlaying == false) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }

        //これのほうが自然だが、なんかディレイが入る
        //animationStateinfo = animator.GetCurrentAnimatorStateInfo(0);
        //if(animationStateinfo.IsName("Base Layer.run")) {
        //    if(audioSource.isPlaying == false) {
        //        audioSource.Play();
        //    }
        //} else {
        //    audioSource.Stop();
        //}

        //if(charController.direction.magnitude >= 0.5f) {
        //    if(audioSource.isPlaying == false) {
        //        audioSource.Play();
        //    }
        //} else {
        //    audioSource.Stop();
        //}
    }

    void play() {
        
    }

}
