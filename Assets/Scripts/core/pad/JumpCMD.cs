using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core.pad {
    class JumpCMD : BasicPadCommond {
        public JumpCMD() : base() {
        }

        public override void exec(GameObject player) {
            Animator controllor = player.GetComponent<Animator>();
            controllor.SetTrigger("jump");
        }
    }
}
