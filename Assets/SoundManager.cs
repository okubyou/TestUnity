using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour{

    [SerializeField] AudioClip sound1;
    static AudioSource audioSource;

    static SoundManager instance;

    void Awake() {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start (){
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static SoundManager getInstance(){
        if(instance == null){
            instance = new SoundManager();
        }
        return instance;
    }

    public void playSound(){
        if(audioSource.isPlaying != true) {
            audioSource.PlayOneShot(sound1, 0.5f);
        }
    }
}
