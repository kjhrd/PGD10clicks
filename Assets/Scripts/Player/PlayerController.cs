using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int clicks = 0;
    public bool isGrounded = false;
    public bool randomized = false;
    public int keyBinding = 123;

    private Rigidbody2D rb;

    public float speed = 1000f;
    public float jumpForce = 100f;

    public

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { clicks++; }
        if (Input.GetMouseButtonDown(1)) { clicks++; }
        if (Input.GetMouseButtonDown(2)) { clicks++; }
        if (Input.GetMouseButton(0))
        {
            if (keyBinding.ToString()[0] == '1')
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else if (keyBinding.ToString()[0] == '2')
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
            else if (keyBinding.ToString()[0] == '3' && isGrounded)
            {
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (keyBinding.ToString()[1] == '1')
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else if (keyBinding.ToString()[1] == '2')
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
            else if (keyBinding.ToString()[1] == '3' && isGrounded)
            {
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
        if(Input.GetMouseButton(2))
        {
            if (keyBinding.ToString()[2] == '1')
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else if (keyBinding.ToString()[2] == '2')
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
            else if (keyBinding.ToString()[2] == '3' && isGrounded)
            {
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
        if (clicks%10==0 && !randomized)
        {
            Randomize();
            randomized = true;
        }
        else { randomized = false; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    private void Randomize()
    {
        var array = new int[] { 123, 132, 213, 231, 321, 312 };
        keyBinding = array[UnityEngine.Random.Range(0, array.Length-1)];
    }
}
