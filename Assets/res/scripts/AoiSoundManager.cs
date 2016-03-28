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

        audioSource.clip = sound1;
    }
	
	// Update is called once per frame
	void Update(){
        if(charController.direction.magnitude >= 0.5f) {
            if(audioSource.isPlaying == false) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }

    void play() {
        
    }

}
