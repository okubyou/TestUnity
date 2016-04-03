using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static readonly int READY = 0;
    public static readonly int NORMAL = 1;
    //警戒　2
    public static readonly int ALERT =  3;
    //攻撃 戦闘 4 
    public static readonly int GOAL = 5;

    static int mode = READY;
    static float timeCount = 0;
    public Text timeText;

    public static void startAlertMode(){
        if (mode == NORMAL){
            mode = ALERT;
            GameManager.timeCount += 5;
        }
    }

    public static void setMode(int _mode){
        mode = _mode;
    }

    // Use this for initialization
    void Start (){
	    
	}
	
	// Update is called once per frame
	void Update () {
        if((mode != GOAL)&&(mode != READY)){
            timeCount += Time.deltaTime;
            timeText.text = timeCount.ToString("##0.00");
        }
    }
}
