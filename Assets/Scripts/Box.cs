using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    public GameObject[] objectsToSpawn;
    public float spawnSpeed;

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Player"))
            return;
        foreach (var point in other.contacts) {
            if (point.normal.y < 0.5F)
                continue;
            
            foreach (var obj in this.objectsToSpawn) {
                var instance = Instantiate(obj, this.transform.position, Quaternion.identity);
                var body = instance.GetComponent<Rigidbody2D>();
                if (body != null) {
                    body.AddForce(new Vector2(
                        Random.Range(-this.spawnSpeed, this.spawnSpeed),
                        Random.Range(-this.spawnSpeed, this.spawnSpeed)));
                }
            }
            Destroy(this.gameObject);
            break;
        }
    }

}