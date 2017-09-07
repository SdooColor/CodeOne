using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.core {
    class TerrainSpawner {
        const string BRICK_PATH = "Prefab/brick";
        const string FLOOR_PATH = "Prefab/floor";

        GameObject brick;
        GameObject floor;
        Transform stage;

        public TerrainSpawner(Transform stage) {
            brick = Resources.Load(BRICK_PATH) as GameObject;
            floor = Resources.Load(FLOOR_PATH) as GameObject;
            this.stage = stage;
        }

        /*
        * 根据数据生成对应的地形 GameObject
        */
        public GameObject[,] spawn(Vector3?[,] tileData) {
            int column = tileData.GetLength(0);
            int row = tileData.GetLength(1);

            GameObject[,] list = new GameObject[column, row];

            for (int c = 0; c < column ; c++) {
                for (int r = 0; r < row; r++) {
                Vector3? pos = tileData[c, r];
                    if (pos.HasValue) {
                        GameObject tile = GameObject.Instantiate(pos.Value.y == 1f ? floor : brick, stage, false) as GameObject;
                        tile.transform.localScale = new Vector3(1f, pos.Value.y, 1f);
                        tile.transform.position = new Vector3(pos.Value.x, pos.Value.y * 0.5f, pos.Value.z);
                        list[c, r] = tile;
                    }
                }
            }

            return list;
        }
    }
}
