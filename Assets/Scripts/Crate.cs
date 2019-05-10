using UnityEngine;

public class Crate : MonoBehaviour, IAttackable {

    public GameObject[] containedItems;
    public float spawnSpeed;

    public void OnAttack(GameObject player) {
        var crate = Physics2D.OverlapPoint(this.transform.position + Vector3.up);
        if (crate != null && crate.CompareTag("Crate"))
            return;

        foreach (var item in this.containedItems) {
            var instance = Instantiate(item, this.transform.position, Quaternion.identity);
            var body = instance.GetComponent<Rigidbody2D>();
            if (body != null) {
                body.AddForce(new Vector2(
                    Random.Range(-this.spawnSpeed, this.spawnSpeed),
                    Random.Range(0, this.spawnSpeed)));
            }
        }
        Destroy(this.gameObject);
    }

}