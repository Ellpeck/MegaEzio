using UnityEngine;

public class Crate : MonoBehaviour, IAttackable {

    public void OnAttack(GameObject player) {
        var crate = Physics2D.OverlapPoint(this.transform.position + Vector3.up);
        if (crate == null || !crate.CompareTag("Crate"))
            Destroy(this.gameObject);
    }

}