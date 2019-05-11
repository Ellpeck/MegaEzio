using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Sprite upSprite;
    public Sprite downSprite;
    public float downSeconds;

    private new SpriteRenderer renderer;
    private bool isDown;

    private InvisiBox[] invisiBoxesInScene;

    private void Start() {
        this.renderer = this.GetComponent<SpriteRenderer>();
        this.invisiBoxesInScene = FindObjectsOfType<InvisiBox>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!this.isDown && other.CompareTag("Player")) {
            this.StartCoroutine(this.Press());
        }
    }

    private IEnumerator Press() {
        this.isDown = true;
        this.renderer.sprite = this.downSprite;
        foreach (var box in this.invisiBoxesInScene)
            box.Enable();

        yield return new WaitForSeconds(this.downSeconds);

        this.isDown = false;
        this.renderer.sprite = this.upSprite;
        foreach (var box in this.invisiBoxesInScene)
            box.Disable();
    }

}