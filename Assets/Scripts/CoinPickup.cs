using UnityEngine;

public class CoinPickup : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            var controller = other.GetComponent<PlayerController>();
            if (controller != null) {
                controller.AddCoins(1);
                Destroy(this.transform.parent.gameObject);
            }
        }
    }

}