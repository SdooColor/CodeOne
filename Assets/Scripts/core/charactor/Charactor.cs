using UnityEngine;
using System.Collections;

public class Charactor : MonoBehaviour {
    // current mode's forward
    public Vector3 forward;
    public Vector3 up;
    public float runSpeed = 2;

    public Animator animator;

    public GameObject mode;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        mode = gameObject;
        forward = transform.forward;
        up = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void updateForward(Vector3 forward) {
        transform.rotation = Quaternion.LookRotation(forward);
        this.forward.Set(forward.x, forward.y, forward.z);
        Debug.Log("updateForward:" + forward);
    }

    public int getState(int layer) {
        return animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
    }
}
