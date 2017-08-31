using UnityEngine;
using System.Collections;

public class Charactor : MonoBehaviour {
    // current mode's forward
    public Vector3 forward;
    public Vector3 up;

    public float runSpeed = 2;
    public Animator animator;

    public Vector3 currentSpeedV;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        forward = transform.forward;
        up = transform.forward;
        currentSpeedV = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        basicMoveFoo();
    }

    // it's a basic move controll
    // 能被更高优先级的动作控制其执行开关
    void basicMoveFoo() {
        float zV = Input.GetAxis("Vertical");
        float xV = Input.GetAxis("Horizontal");
        if (xV != 0 || zV != 0) {
            animator.SetBool("move", true);

            Quaternion rotation = Quaternion.LookRotation(new Vector3(xV, 0, zV), transform.up);
            transform.LookAt(rotation * forward + transform.position);
            transform.localPosition = rotation * (forward * runSpeed * Time.deltaTime) + transform.position;
        }
        else {
            animator.SetBool("move", false);
            transform.LookAt(forward + transform.position);
        }
    }

    public void updateForward(Vector3 forward) {
        transform.rotation = Quaternion.LookRotation(forward);
        this.forward.Set(forward.x, forward.y, forward.z);
    }

    public int getState(int layer) {
        return animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
    }
}
