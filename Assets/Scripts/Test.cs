using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.LookAt(new Vector3(0, 0, 1), new Vector3(0,1,0));
	}
	
	// Update is called once per frame
	void Update () {
	}
}
