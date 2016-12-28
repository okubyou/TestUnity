using UnityEngine;
using UnityEngine.Networking;

public class DisableNetworkUnlocalplayerBehaviour: NetworkBehaviour {

    [SerializeField]
    Behaviour[] behaviours;

    void Start() {
        if(!isServer) {
            foreach(var behaviour in behaviours) {
                behaviour.enabled = false;
            }
        }
    }
}
