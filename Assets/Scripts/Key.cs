using UnityEngine;

public class Key : MonoBehaviour {

    public Color color;

    private new CircleCollider2D collider;
    private Rigidbody2D body;

    private Collider2D followingPlayer;
    private bool playerInside;

    private void Start() {
        foreach (var coll in this.GetComponents<CircleCollider2D>()) {
            if (!coll.isTrigger) {
                this.collider = coll;
                break;
            }
        }
        this.body = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (!this.followingPlayer) {
                this.followingPlayer = other;
                var controller = other.GetComponent<PlayerController>();
                if (controller != null)
                    controller.AddKey(this);

                this.collider.enabled = false;
                this.body.gravityScale = 0;
            }
            this.playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            this.playerInside = false;
    }

    private void Update() {
        if (!this.followingPlayer)
            return;

        if (!this.playerInside) {
            var dist = this.followingPlayer.transform.position - this.transform.position;
            this.body.AddForce(dist * 10);
        } else {
            this.body.velocity *= 0.75F;
        }
    }

    public enum Color {

        Red,
        Green,
        Blue,
        Yellow

    }

}