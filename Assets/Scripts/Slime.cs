using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Slime : MonoBehaviour {

    private static readonly int AnimatorSpeed = Animator.StringToHash("Speed");

    public Transform groundCheck;
    public LayerMask collidingLayer;
    public float speed;

    private Rigidbody2D body;
    private Animator animator;

    private bool facingRight;

    private void Start() {
        this.body = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        foreach (var point in other.contacts) {
            if (this.facingRight ? point.normal.x <= -0.75F : point.normal.x >= 0.75F) {
                this.TurnAround();
                break;
            }

            if (point.normal.y <= -0.45F && other.gameObject.CompareTag("Player")) {
                Destroy(this.gameObject);
                return;
            }
        }
        if (other.gameObject.CompareTag("Player")) {
            var controller = other.gameObject.GetComponent<PlayerController>();
            if (controller != null)
                controller.TakeDamage(1);
        }
    }

    private void FixedUpdate() {
        if (!Physics2D.Raycast(this.groundCheck.position, Vector2.down, 0.1F, this.collidingLayer))
            this.TurnAround();

        this.body.AddForce(new Vector2(this.facingRight ? this.speed : -this.speed, 0));
        this.animator.SetFloat(AnimatorSpeed, this.speed);
    }

    private void TurnAround() {
        this.facingRight = !this.facingRight;
        this.transform.Rotate(0, 180, 0);
        this.body.velocity = Vector2.zero;
    }

}