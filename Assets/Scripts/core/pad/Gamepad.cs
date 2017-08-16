using UnityEngine;
using System.Collections;
using UnityEditor.Animations;
using UnityEditor;
using Assets.Scripts.core.pad;

public class Gamepad : MonoBehaviour {
    [SerializeField]
    public GameObject config;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (config == null) {
            return;
        }

        int state = animator.GetCurrentAnimatorStateInfo(0).shortNameHash;

        foreach (BasicPadCommond cmd in config.GetComponents<BasicPadCommond>()) {
            if (Input.GetButtonDown(cmd.key) && cmd.checkActivable(state)) {
                cmd.exec(gameObject);
            }
        }
    }
}
