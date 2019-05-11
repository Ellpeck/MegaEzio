using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoins : MonoBehaviour {

    public PlayerController player;
    private TextMeshProUGUI text;

    private void Start() {
        this.text = this.GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        this.text.text = this.player.coinAmount.ToString();
    }

}