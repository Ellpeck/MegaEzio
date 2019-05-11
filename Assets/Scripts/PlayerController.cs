using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int coinAmount;
    public List<Key> keys = new List<Key>();

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

}