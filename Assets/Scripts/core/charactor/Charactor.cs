using UnityEngine;
using System.Collections;

public class Charactor : MonoBehaviour {
    // current mode's forward
    public Vector3 forward;
    public Vector3 up;
    public float runSpeed = 2;

    public Animator animator;

    GameObject mode;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        mode = gameObject;
        forward = gameObject.transform.forward;
        up = gameObject.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getState(int layer) {
        return animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
    }
}
