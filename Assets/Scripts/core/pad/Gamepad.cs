using UnityEngine;
using System;
using System.Collections.Generic;

public class Gamepad : MonoBehaviour {
    BasicPadCommond[] totalCMDs;
    Character character;

    // Use this for initialization
    void Start () {
        totalCMDs = GetComponents<BasicPadCommond>();
        character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
        int state = character.getState(0);

        foreach (BasicPadCommond cmd in totalCMDs) {
            if (Input.GetKeyDown(cmd.key) && cmd.checkActivable(state)) {
                cmd.startCMD(character);
            }
        }
    }
}
