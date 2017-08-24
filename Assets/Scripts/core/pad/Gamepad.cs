using UnityEngine;
using System.Collections;
using UnityEditor.Animations;
using UnityEditor;
using Assets.Scripts.core.pad;

public class Gamepad : MonoBehaviour {
    BasicPadCommond[] cmds;
    Charactor charactor;

	// Use this for initialization
	void Start () {
        cmds = GetComponents<BasicPadCommond>();
        charactor = GetComponent<Charactor>();
	}
	
	// Update is called once per frame
	void Update () {
        int state = charactor.getState(0);

        foreach (BasicPadCommond cmd in cmds) {
            if (cmd.handleOnce ? Input.GetKeyDown(cmd.key) : Input.GetKey(cmd.key)) {
                if (cmd.checkActivable(state)) {
                    cmd.updatePlayer(charactor);
                }
            }
        }
    }
}
