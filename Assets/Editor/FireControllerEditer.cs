using UnityEditor;
using UnityEngine;
using System.Collections;

// Creates an instance of a primitive depending on the option selected by the user.

[CustomEditor(typeof(FireController))]
[CanEditMultipleObjects]
public class FireControllerEditer: Editor {

    public override void OnInspectorGUI() {
        //serializedObject.Update();

        FireController fireController = target as FireController;

        fireController.bullet = EditorGUILayout.IntField("bullet", fireController.bullet);
        fireController.rateOfFire = EditorGUILayout.IntField("rateOfFire", fireController.rateOfFire);
        fireController.burstMode = (FireController.BURST_MODE)EditorGUILayout.EnumPopup("burstMode",fireController.burstMode);

    }
}
