using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int maxHealth;
    public int coinAmount;
    public int health;

    private readonly List<Key> keys = new List<Key>();

    private void Start() {
        this.health = this.maxHealth;
    }

    public void AddCoins(int amount) {
        this.coinAmount += amount;
    }

    public void TakeCoins(int amount) {
        this.coinAmount = Math.Max(0, this.coinAmount - amount);
    }

    public void AddKey(Key key) {
        this.keys.Add(key);
    }

    public bool ConsumeKey(Key.Color color) {
        foreach (var key in this.keys) {
            if (key.color == color) {
                this.keys.Remove(key);
                Destroy(key.gameObject);
                return true;
            }
        }
        return false;
    }

    public void TakeDamage(int amount) {
        this.health = Math.Max(0, this.health - amount);
    }

}