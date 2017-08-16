using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BasicPadCommond : MonoBehaviour {
    [SerializeField]
    public string key;
    [SerializeField]
    public string states;

    int[] stateList;

    public BasicPadCommond() {
    }

	protected virtual void Start () {
        string[] list = states.Split('|');
        stateList = new int[list.Length];
        for (int i = list.Length - 1; i >= 0; i--) {
            stateList[i] = Animator.StringToHash(list[i]);
        }
	}

    public bool checkActivable(int state) {
        return Array.IndexOf(stateList, state) != -1;
    }

    public virtual void exec(GameObject player) {
    }
}
