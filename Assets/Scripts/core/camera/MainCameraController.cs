using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float distance = 10f;
    [SerializeField]
    public float sensitivity = 200f;

    float xRoation = 0;
    float yRoation = 0;

    Charactor charactor;

    Quaternion cameraQ;

    // Use this for initialization
    void Start() {
        charactor = target.GetComponent<Charactor>();
        cameraQ = Quaternion.LookRotation(charactor.forward, Vector3.up);

        updateCamera();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Mouse0)) {
            xRoation += Time.deltaTime * sensitivity * -Input.GetAxis("Mouse Y");
            yRoation += Time.deltaTime * sensitivity * Input.GetAxis("Mouse X");

            xRoation = Mathf.Clamp(xRoation, 0, 70);
            yRoation = Mathf.Clamp(yRoation, -70, 70);

            Vector3 axis = new Vector3(xRoation, yRoation, 0);
            Quaternion deltaQ = Quaternion.Euler(xRoation, yRoation, 0);
            cameraQ = deltaQ;

            updateCamera();
        }
    }

    void updateCamera() {
        transform.position = cameraQ * (-charactor.forward * distance) + charactor.transform.position;
        transform.rotation = cameraQ;
    }
}
