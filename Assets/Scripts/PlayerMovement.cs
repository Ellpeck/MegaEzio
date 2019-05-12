using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private static readonly int AnimatorSpeed = Animator.StringToHash("Speed");
    private static readonly int AnimatorJumping = Animator.StringToHash("Jumping");

    public float moveSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Animator animator;
    private Rigidbody2D body;

    private float inputHor;
    private bool jump;

    private Vector2 currentVelocity;
    private bool facingLeft;
    private bool jumping;

    private void Start() {
        this.animator = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        this.inputHor = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
            this.jump = true;
    }

    private void FixedUpdate() {
        var onGround = false;
        var colliders = Physics2D.OverlapCircleAll(this.groundCheck.position, 0.1F, this.groundLayer);
        foreach (var other in colliders) {
            if (other.gameObject != this.gameObject && !other.isTrigger) {
                onGround = true;
                break;
            }
        }

        if (onGround) {
            if (this.jump)
                this.body.AddForce(new Vector2(0, this.jumpForce));
            this.jumping = this.jump;
        }

        var goalSpeed = this.inputHor * this.moveSpeed;
        var velocity = this.body.velocity;
        var targetVelocity = new Vector2(goalSpeed, velocity.y);
        this.body.velocity = Vector2.SmoothDamp(velocity, targetVelocity, ref this.currentVelocity, 0.05F);

        if (goalSpeed != 0 && this.facingLeft != goalSpeed < 0) {
            this.facingLeft = goalSpeed < 0;
            this.transform.Rotate(0, 180, 0);
        }

        this.animator.SetFloat(AnimatorSpeed, Math.Abs(goalSpeed));
        this.animator.SetBool(AnimatorJumping, this.jumping);

        this.jump = false;
    }

}