using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float distance = 10f;
    [SerializeField]
    public float sensitivity = 200f;

    float xRotation = 25f;
    float yRotation = 0f;

    Character character;

    // Use this for initialization
    void Start() {
        character = target.GetComponent<Character>();
        updateCamera();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Mouse0)) {
            xRotation += Time.deltaTime * sensitivity * -Input.GetAxis("Mouse Y");
            yRotation += Time.deltaTime * sensitivity * Input.GetAxis("Mouse X");

            // clamp in rang
            xRotation = Mathf.Clamp(xRotation, 0, 70);
            yRotation = Mathf.Clamp(yRotation, -90, 90);
        }
        else if (Input.GetKey(KeyCode.Mouse1)) {
            xRotation += Time.deltaTime * sensitivity * -Input.GetAxis("Mouse Y");
            // change charactor forward , only for yRotation
            float deltaYRotation = Time.deltaTime * sensitivity * Input.GetAxis("Mouse X");
            // update forward
            character.updateForward(Quaternion.AngleAxis(deltaYRotation + yRotation, Vector3.up) * character.forward);
            // reset
            yRotation = 0f;
        }

        updateCamera();
    }

    void updateCamera() {
        // frist rotate camera forward charactor's forward, then rotate to the x,yRotation
        transform.rotation = Quaternion.LookRotation(character.forward,Vector3.up) * Quaternion.Euler(xRotation, yRotation, 0);
        transform.position = transform.rotation * (-Vector3.forward * distance) + character.transform.position;
    }
}
