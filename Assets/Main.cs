using UnityEngine;
using System.Collections;
using Assets.Scripts.core;

public class Main: MonoBehaviour {
    public Transform mainCamera;
    public Transform mainRole;

	// Use this for initialization
	void Start () {
        Globals.map = new Map();
        Globals.terrainSpawner = new TerrainSpawner(transform.parent);
        Globals.map.load();
    }
	
	// Update is called once per frame
	void Update () {
        Globals.map.followTarget(mainRole);
	}
}
