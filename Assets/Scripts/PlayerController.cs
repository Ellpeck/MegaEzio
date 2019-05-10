using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int coinAmount;

    public void AddCoins(int amount) {
        this.coinAmount += amount;
    }

    public void TakeCoins(int amount) {
        this.coinAmount = Math.Max(0, this.coinAmount - amount);
    }

}