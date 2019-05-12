using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public PlayerController player;
    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;

    private int lastHealth;

    private void Update() {
        var health = this.player.health;
        if (this.lastHealth != health) {
            this.lastHealth = health;
            for (var i = 0; i < this.hearts.Length; i++) {
                this.hearts[i].sprite = health > i ? this.fullHeart : this.emptyHeart;
            }
        }
    }

}