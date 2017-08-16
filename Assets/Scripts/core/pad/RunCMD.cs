using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core.pad {
    class RunCMD : BasicPadCommond {
        [SerializeField]
        float speed = 2.0f;
        [SerializeField]
        float rotationSpeed = 2.0f;

        public RunCMD() : base() {
        }

        protected override void Start() {
            base.Start();
            speed = 2.0f;
        }

        public override void exec(GameObject player) {
            Animator controllor = player.GetComponent<Animator>();
            Transform transform = player.transform;

            controllor.SetBool("move", true);

            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            controllor.SetFloat("direction", rotation);

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }

    }
}
