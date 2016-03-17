using UnityEngine;
using System.Collections;

public class AoiSoundManager : MonoBehaviour {

    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    // Use this for initialization
    void Start (){
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update (){
	
	}

    void play(){

    }

}
