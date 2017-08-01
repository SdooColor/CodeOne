using UnityEngine;
using System.Collections;
using Assets.Scripts.core;

public class Main: MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject brick = Resources.Load("Prefab/brick") as GameObject;
        brick.transform.position = new Vector3(0, -2, 0);
        brick.transform.Translate(0, 2, 0);
        Instantiate(brick);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
