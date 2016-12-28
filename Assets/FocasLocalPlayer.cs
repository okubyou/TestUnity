using UnityEngine;
using UnityEngine.Networking;

public class FocasLocalPlayer : NetworkBehaviour {

    [SerializeField]
    Behaviour[] behaviours;

    // Use this for initialization
    void Start () {
        if(!localPlayerAuthority) {
            foreach(var behaviour in behaviours) {
                behaviour.enabled = false;
            }
        }
    }

    void OnApplicationFocus(bool focusStatus) {
        if(localPlayerAuthority) {
            foreach(var behaviour in behaviours) {
                behaviour.enabled = focusStatus;
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
