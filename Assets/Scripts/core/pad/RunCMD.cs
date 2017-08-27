using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core.pad {
    class RunCMD : BasicPadCommond {

        public RunCMD() : base() {
            states = "idle|run";
            handleOnce = false;
        }

        public override void updatePlayer(Charactor charactor) {
            charactor.animator.SetBool("move", true);

            float zV = Input.GetAxis("Vertical");
            float xV = Input.GetAxis("Horizontal");

            Quaternion rotation = Quaternion.LookRotation(new Vector3(xV, 0, zV), charactor.mode.transform.up);

            charactor.gameObject.transform.LookAt(rotation * charactor.forward + charactor.mode.transform.position);

            float translation = charactor.runSpeed * Time.deltaTime;

            transform.Translate(0,0, translation);
        }

    }
}
