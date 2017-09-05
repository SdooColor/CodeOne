using UnityEngine;
using System;
using Assets.Scripts.core;

public class Character : MonoBehaviour {
    [NonSerialized]
    public Animator animator;

    // current mode's forward
    public Vector3 forward;
    public Vector3 up;
    public float velocity = 2f;
    public Vector3 speed;

    public float gravity = 10f;

    public bool isGrounded;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        forward = transform.forward;
        up = transform.forward;
        speed = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        basicMoveFoo();
        basicUdpatePositionFoo();
    }

    void OnCollisionStay(Collision colision) {
        isGrounded = colision.gameObject.tag == Globals.TAG_FLOOR;
            animator.SetBool("isGrounded", true);
    }

    void OnCollisionExit(Collision colision) {
        if (colision.gameObject.tag == Globals.TAG_FLOOR) {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    // it's a basic move controller
    // 能被更高优先级的动作控制其执行开关
    void basicMoveFoo() {
        float zV = Input.GetAxis("Vertical");
        float xV = Input.GetAxis("Horizontal");

        speed.y -= gravity * Time.deltaTime;
        // 已经在地面上了，无法产生向下的速度
        if (speed.y < 0 && isGrounded) {
            speed.y = 0;
        }

        if (xV != 0 || zV != 0) {
            animator.SetBool("move", true);
            // 当前速度基于 forward 方向的旋转量
            Quaternion speedRotation = Quaternion.LookRotation(new Vector3(xV, 0, zV), transform.up);
            float speedY = speed.y;
            speed = speedRotation * forward * velocity;
            speed.Set(speed.x , speedY, speed.z);
        }
        else {
            animator.SetBool("move", false);
            speed.Set(0, speed.y, 0);
        }
    }

    void basicUdpatePositionFoo() {
        transform.position += speed * Time.deltaTime;

        // speed equal zero character turn to forward
        if (Vector3.Equals(speed, Vector3.zero)) {
            transform.LookAt(forward + transform.position);
        }
        // else turn to the speed
        else {
            transform.LookAt(new Vector3(speed.x, 0, speed.z) + transform.position);
        }
    }

    public void updateForward(Vector3 forward) {
        this.forward.Set(forward.x, forward.y, forward.z);
    }

    public int getState(int layer) {
        return animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
    }
}
