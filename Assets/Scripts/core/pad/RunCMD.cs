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

            Quaternion rotation = Quaternion.LookRotation(new Vector3(xV, 0, zV), charactor.gameObject.transform.up);
            Vector3 v = rotation * charactor.forward;
            Debug.Log(v);

            charactor.gameObject.transform.LookAt(rotation * charactor.forward);

            float translation = charactor.runSpeed * Time.deltaTime;

            transform.Translate(0,0, translation);
        }

    }
}
