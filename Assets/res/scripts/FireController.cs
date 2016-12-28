using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

    ParticleSystem fireEffect;
    public enum BURST_MODE {
        safety = 0, //安全　SafetyMode
        semiAuto = 1,//単射
        twoShotBurst = 2,
        threeShotBursts = 3,
        fullAuto = 4,//連射
    }

    [SerializeField]
    public int bullet = 0;
    [SerializeField]
    public int rateOfFire = 120;
    [SerializeField]
    public BURST_MODE burstMode = BURST_MODE.safety;

    private float coolDown;

    

    // Use this for initialization
    void Start () {
        fireEffect = GetComponent<ParticleSystem>();
        
    }
	
	// Update is called once per frame
	void Update () {      
        coolDown -= Time.deltaTime;
	}

    void fire() {

        if(Input.GetMouseButtonDown(0)) { 

            if(bullet <= 0) {
                return;    
            }
            if(coolDown > 0) {
                return;
            }

            fireEffect.Play();
            bullet--;
            coolDown = 60 / rateOfFire;
        }
    }

}
