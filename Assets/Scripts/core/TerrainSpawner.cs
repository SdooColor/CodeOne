using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.core {
    class TerrainSpawner {
        const string BRICK_PATH = "Prefab/brick";

        GameObject brick;
        Transform stage;

        public TerrainSpawner(Transform stage) {
            brick = Resources.Load(BRICK_PATH) as GameObject;
            this.stage = stage;
        }

        /*
        * 根据数据生成对应的地形 GameObject
        */
        public GameObject[] spawn(Vector3?[] tileData) {
            GameObject[] list = new GameObject[tileData.Length];

            for (int index = 0; index < tileData.Length; index++) {
                Vector3? pos = tileData[index];
                if (pos.HasValue) {
                    GameObject tile = GameObject.Instantiate(brick, stage, false) as GameObject;
                    tile.transform.localScale = new Vector3(1f, pos.Value.y, 1f);
                    tile.transform.position = new Vector3(tileData[index].Value.x, tileData[index].Value.y * 0.5f, tileData[index].Value.z);
                }
            }
            return list;
        }
    }
}
