using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core {
    class Map {
        // 视窗
        public Rect viewport = new Rect(0,0, 25f,25f);

        // 渲染区域
        Rect renderRect = new Rect();

        // 当前的地图内容
        Dictionary<string, GameObject[]> canvas = new Dictionary<string, GameObject[]>();
        Dictionary<string, Boolean> canvasRenderFlag = new Dictionary<string, bool>();

        Vector2 helpPoint = new Vector2();

        MAP_DATA data;

        public Map() {
        }

        public void load() {
            data = new MAP_DATA();
            data.tiles = new Dictionary<string, Vector3?[]>();
        }

        public void save() {
        }

        public void render() {
            // 获取渲染区域
            // 坐标要进行转换，获取 tile 的坐标
            renderRect.x = Mathf.Floor(viewport.x / MAP_DATA.TILE_WIDTH);
            renderRect.y = Mathf.Floor(viewport.y / MAP_DATA.TILE_HEIGHT);
            renderRect.width = Mathf.Ceil(viewport.xMax / MAP_DATA.TILE_WIDTH) - renderRect.x;
            renderRect.height = Mathf.Ceil(viewport.yMax / MAP_DATA.TILE_HEIGHT) - renderRect.y;
            Debug.Log("renderRect:" + renderRect);

            for (float x = renderRect.x; x < renderRect.xMax; x++) {
                for (float y = renderRect.y; y < renderRect.yMax; y++) {
                    string key = x + "_" + y;
                    if (!data.tiles.ContainsKey(key)) {
                        data.tiles.Add(key, MAP_DATA.randomSpawn(x, y));
                    }

                    if (!canvas.ContainsKey(key)) {
                        canvas.Add(key, null);
                    }
                }
            }


            foreach (string key in canvas.Keys) {
                string[] keys = key.Split('_');
                helpPoint.Set(Convert.ToSingle(keys[0]), Convert.ToSingle(keys[1]));

                if (renderRect.Contains(helpPoint)) {
                    if (canvas[key] == null) {
                        renderTiles(key, data.tiles[key]);
                    }
                    else {
                        // 已渲染
                    }
                }
                // 移除
                else {
                    removeTiles(canvas[key]);
                    canvas.Remove(key);
                }
            }
        }

        void renderTiles(string key, Vector3? [] data) {
            Debug.Log("renderTiles:" + key);
            canvas[key] = Globals.terrainSpawner.spawn(data);
        }

        void removeTiles(GameObject [] bricks) {
            Debug.Log("removeTiles");
            foreach (GameObject brick in bricks) {
                GameObject.DestroyObject(brick);
            }
        }
    }

    public struct MAP_DATA {
        public const float TILE_WIDTH = 10f;
        public const float TILE_HEIGHT = 10f;

        public Dictionary<string, Vector3? []> tiles;

        public static Vector3?[] randomSpawn(float x, float y) {
            Vector3?[] tiles = new Vector3?[(int)(TILE_WIDTH * TILE_HEIGHT)];

            int index = 0;
            float xStart = x * TILE_WIDTH;
            float yStart = y * TILE_HEIGHT;
            float xMax = xStart + TILE_WIDTH;
            float yMax = yStart + TILE_HEIGHT;

            for (x = xStart; x < xMax; x++) {
                for (y = yStart; y < yMax; y++) {
                    Boolean hasbrick = UnityEngine.Random.Range(0f, 1f) > 0.8f;
                    if (hasbrick) {
                        float height = Mathf.Floor(UnityEngine.Random.Range(1, 4));
                        tiles[index] = new Vector3(x, height, y);
                    }
                    else {
                        tiles[index] = new Vector3(x, 1, y);
                    }

                    index++;
                }
            }
            return tiles;
        }
    }
}
