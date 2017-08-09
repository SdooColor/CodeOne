using UnityEngine;
using System.Collections;
using Assets.Scripts.core;

public class Main: MonoBehaviour {
    [SerializeField]
    public Transform mainCamera;

	// Use this for initialization
	void Start () {
        Globals.map = new Map();
        Globals.terrainSpawner = new TerrainSpawner(transform.parent);

        Globals.map.load();
    }
	
	// Update is called once per frame
	void Update () {
        Globals.map.viewport.x = mainCamera.transform.position.z - Globals.map.viewport.width * 0.5f;
        Globals.map.viewport.y = mainCamera.transform.position.x - 10f - Globals.map.viewport.height;

        Globals.map.render();
	}
}
