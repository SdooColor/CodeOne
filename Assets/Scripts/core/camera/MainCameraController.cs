using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float distance = 10f;
    [SerializeField]
    public float sensitivity = 200f;

    [SerializeField]
    float xRotation = 25f;
    [SerializeField]
    float yRotation = 0f;

    Charactor charactor;

    Quaternion cameraQ;

    // Use this for initialization
    void Start() {
        charactor = target.GetComponent<Charactor>();
        updateCamera();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Mouse0)) {
            xRotation += Time.deltaTime * sensitivity * -Input.GetAxis("Mouse Y");
            yRotation += Time.deltaTime * sensitivity * Input.GetAxis("Mouse X");

            // clamp in rang
            xRotation = Mathf.Clamp(xRotation, 0, 70);
            yRotation = Mathf.Clamp(yRotation, -70, 70);
        }
        else if (Input.GetKey(KeyCode.Mouse1)) {
            xRotation += Time.deltaTime * sensitivity * -Input.GetAxis("Mouse Y");

            // change charactor forward , only for yRotation
            float deltaYRotation = Time.deltaTime * sensitivity * Input.GetAxis("Mouse X");
            // plus at current camear roation's y
            float forwardYRoation = transform.rotation.eulerAngles.y + deltaYRotation;
            // reset yRotation
            yRotation = 0;

            // update forward
            charactor.updateForward(Quaternion.Euler(0, forwardYRoation, 0 )* Vector3.forward);
        }

        updateCamera();
    }

    void updateCamera() {
        // frist rotate camera forward charactor's forward, then rotate to the x,yRotation
        transform.rotation = Quaternion.LookRotation(charactor.forward,Vector3.up) * Quaternion.Euler(xRotation, yRotation, 0);
        transform.position = transform.rotation * (-Vector3.forward * distance) + charactor.transform.position;
    }
}
