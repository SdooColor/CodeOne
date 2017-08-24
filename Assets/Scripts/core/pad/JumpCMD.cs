using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core.pad {
    class JumpCMD : BasicPadCommond {
        public JumpCMD() : base() {
            states = "idle|run|jump";
        }

        public override void updatePlayer(Charactor charactor) {
            charactor.animator.SetTrigger("jump");
        }
    }
}
