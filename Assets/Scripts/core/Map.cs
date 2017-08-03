using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core {
    class Map {
        const float VIEWPORT_WIDTH = 10f;
        const float VIEWPORT_HEIGHT = 10f;
        const float BUFF_LENGTH = 0f;
        // 视窗
        readonly Rect viewport = new Rect(0,0, VIEWPORT_WIDTH,VIEWPORT_HEIGHT);

        readonly Rect renderRect = new Rect();
        readonly Dictionary<string, GameObject[]> canvas = new Dictionary<string, GameObject[]>();
        readonly Vector2 helpPoint = new Vector2();

        MAP_DATA data;

        public Map() {
        }

        public void load() {
        }

        public void save() {
        }

        void render() {
            renderRect.Set(
                Mathf.Floor(viewport.x / MAP_DATA.TILE_WIDTH),
                Mathf.Floor(viewport.y / MAP_DATA.TILE_HEIGHT),
                Mathf.Ceil(viewport.xMax / MAP_DATA.TILE_WIDTH),
                Mathf.Ceil(viewport.yMax / MAP_DATA.TILE_HEIGHT)
                );

            foreach (string key in canvas.Keys) {
                string[] keys = key.Split('_');
                helpPoint.Set(System.Convert.ToSingle(keys[0]), System.Convert.ToSingle(keys[1]));
            }
        }

        void renderTile(Vector3 [] data) {
        }

        void removeTile(GameObject [] bricks) {
        }
    }

    public struct MAP_DATA {
        public const float TILE_WIDTH = 10f;
        public const float TILE_HEIGHT = 10f;
        public Dictionary<string, Vector3 []> tiles;
    }
}
