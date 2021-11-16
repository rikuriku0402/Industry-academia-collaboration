using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguin3 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f, jumpForce = 7f;

    private Rigidbody2D rb;

    private Transform groundChaeckPos;

    [SerializeField] private LayerMask groundLayer;

    private PlayerAnimation playerAnimation;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundChaeckPos = transform.GetChild(0).transform;
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        AnimatePlayer();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
    private void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsGrounded())
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChaeckPos.position, 0.1f, groundLayer);
    }

    private void AnimatePlayer()
    {
        playerAnimation.PlayJump(rb.velocity.y);
        playerAnimation.Running(IsGrounded());
    }
}
