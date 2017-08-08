using UnityEngine;
using System.Collections;
using Assets.Scripts.core;

public class Main: MonoBehaviour {

	// Use this for initialization
	void Start () {
        Globals.map = new Map();
        Globals.terrainSpawner = new TerrainSpawner(transform.root);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
