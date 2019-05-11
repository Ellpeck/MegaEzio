using UnityEngine;

public class Lock : MonoBehaviour {

    public Key.Color color;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            var controller = other.gameObject.GetComponent<PlayerController>();
            if (controller != null && controller.ConsumeKey(this.color)) {
                Destroy(this.gameObject);
            }
        }
    }

}