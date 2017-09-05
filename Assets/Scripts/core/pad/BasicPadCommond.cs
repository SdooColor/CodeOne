using System;
using UnityEngine;

public class BasicPadCommond : MonoBehaviour {
    [SerializeField]
    public string key;

    [NonSerialized]
    public string states;

    protected int[] stateList;
    protected bool actived = false;
    protected Character player;

    public BasicPadCommond() {
    }

    void Start () {
        string[] list = states.Split('|');
        stateList = new int[list.Length];
        for (int i = list.Length - 1; i >= 0; i--) {
            stateList[i] = Animator.StringToHash(list[i]);
        }
    }

    public bool checkActivable(int state) {
        return Array.IndexOf(stateList, state) != -1;
    }

    public void startCMD(Character character) {
        actived = true;
        player = character;
        entry();
    }

    void Update() {
        if (actived) {
            updatePlayer();
        }
    }

    public void endCMD() {
        actived = false;
        player = null;
    }

    public virtual void entry() {
        // cmd entry
    }

    public virtual void updatePlayer() {
        // update after enter the cmd
    }

    public virtual void exit() {
        // exit the cmd
    }
}
