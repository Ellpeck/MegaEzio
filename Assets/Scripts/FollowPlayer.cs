using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public bool verticalScroll;
    private GameObject player;

    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        var goal = this.player.transform.position;
        var position = this.transform.position;

        if (this.verticalScroll) {
            this.transform.position = new Vector3(goal.x, goal.y, position.z);
        } else {
            this.transform.position = new Vector3(goal.x, position.y, position.z);
        }
    }

}