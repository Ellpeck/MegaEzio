using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiBox : MonoBehaviour {

    private new SpriteRenderer renderer;
    private new BoxCollider2D collider;

    private void Start() {
        this.renderer = this.GetComponent<SpriteRenderer>();
        this.collider = this.GetComponent<BoxCollider2D>();
    }

    public void Enable() {
        this.renderer.enabled = true;
        this.collider.enabled = true;
    }

    public void Disable() {
        this.renderer.enabled = false;
        this.collider.enabled = false;
    }

}