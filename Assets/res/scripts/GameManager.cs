using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    const int NORMAL = 0;
    //警戒　1
    const int ALERT =  2;
    //攻撃 戦闘 3 
    const int GOAL = 4;

    static int mode = NORMAL;
    static float timeCount = 0;
    public Text timeText;


    public static void startAlertMode(){
        if (mode == NORMAL) {
            mode = ALERT;
            GameManager.timeCount += 5;
        }
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        timeCount += Time.deltaTime;
        timeText.text = timeCount.ToString("##0.00");
    }
}
