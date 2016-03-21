using UnityEngine;
using System.Collections;

public class AoiSoundManager : MonoBehaviour {

    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    CharaController charController;

    // Use this for initialization
    void Start (){
        audioSource = gameObject.GetComponent<AudioSource>();
        charController = gameObject.GetComponent<CharaController>();

        //audioSource
    }
	
	// Update is called once per frame
	void Update(){
	
	}

    //void play(){
    //    if(charController.direction.magnitude >= 0.5f){
    //        //audioSource.Play();
    //    }
    //}

}
