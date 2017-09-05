using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core.pad {
    class JumpCMD : BasicPadCommond {
        public float jumpSpeed = 20f;

        public JumpCMD() : base() {
            states = "idle|run";
        }

        public override void entry() {
            player.animator.SetTrigger("jump");
            player.speed.y += jumpSpeed;
            endCMD();
        }
    }
}
