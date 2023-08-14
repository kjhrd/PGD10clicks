using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public GameObject endGame;

    public Text _score;
    public float score;

    public float dir = 1f;

    public int clicks = 0;
    public string scene = "Game1";
    public bool isGrounded = false;
    public bool randomized = false;
    public int keyBinding = 1560;

    private Rigidbody2D rb;
    private Animator _anim;
    [SerializeField]public List<SpriteRenderer> renderers = new List<SpriteRenderer>();

    [SerializeField]public float speed = 1000f;
    public float jumpForce = 100f;
    public float jumpCooldown = 1 / 144;
    public float jump = 0f;

    public float dashDistance = 2f;
    public float dashcooldown = 1f;
    public float dash = 0f;
    private int heart = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        dash += Time.deltaTime;
        jump += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) { clicks++; }
        if (Input.GetMouseButtonDown(1)) { clicks++; }
        if (Input.GetMouseButtonDown(2)) { clicks++; }
        if (Input.GetMouseButtonDown(0))
        {
            if (keyBinding.ToString()[1] == '5' && jump>jumpCooldown)
            {
                rb.AddForce(new Vector2(0, jumpForce));
                jump = 0f;
            }
            else if (keyBinding.ToString()[1] == '6' && dash >= dashcooldown)
            {
                transform.Translate(new Vector3(dashDistance*dir, 0f, 0f));
                dash = 0f;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (keyBinding.ToString()[2] == '6' && dash>=dashcooldown)
            {
                transform.Translate(new Vector3(dashDistance*dir, 0f, 0f));
                dash = 0f;
            }
            else if (keyBinding.ToString()[2] == '5' && jump > jumpCooldown)
            {
                rb.AddForce(new Vector2(0, jumpForce));
                jump = 0f;
            }
        }
        if (keyBinding.ToString()[0] == '1')
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.timeScale * Time.deltaTime * speed, 0f));
            if (Mathf.Abs((Input.GetAxis("Horizontal")) / Math.Abs(Input.GetAxis("Horizontal"))) > .1)
            { 
                dir = (Input.GetAxis("Horizontal")) / Math.Abs(Input.GetAxis("Horizontal"));
            }
        } else if (keyBinding.ToString()[0] == '2')
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal")*-1 * Time.timeScale * Time.deltaTime * speed, 0f));
            if (Mathf.Abs((Input.GetAxis("Horizontal") * -1) / Math.Abs(Input.GetAxis("Horizontal") * -1)) > .1)
            {
                dir = (Input.GetAxis("Horizontal") * -1) / Math.Abs(Input.GetAxis("Horizontal") * -1);
            }
        } else if (keyBinding.ToString()[0] == '0')
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * 0 * Time.timeScale * speed, 0f));
            dir = 1;
        }
        foreach (SpriteRenderer sp in renderers)
        {
            sp.flipX = dir==-1;
            if (!sp.flipX)
            {
                if (sp.gameObject.name == "央铋9")
                {
                    sp.sortingOrder = 7;
                }else if (sp.gameObject.name == "央铋12")
                {
                    sp.sortingOrder = 4;
                }
            }
            else
            {
                if (sp.gameObject.name == "央铋9")
                {
                    sp.sortingOrder = 11-7;
                }else if (sp.gameObject.name == "央铋12")
                {
                    sp.sortingOrder = 11-4;
                }
            }
        }

        _anim.SetFloat("velX", Mathf.Abs(Input.GetAxis("Horizontal") * Time.timeScale * Time.deltaTime * speed));
        _anim.SetFloat("velY", rb.velocity.y);

        if (clicks%10==0 && clicks != 0)
        {
            if (!randomized) { Randomize(); randomized = true; }
        }else 
        { 
            randomized = false;
        }
        if (transform.position.y < -13f)
        {
            endGame.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            heart--;
        }
    }

    private void Randomize()
    {
        var array = new int[] { 1560, 2560, 1650, 2650, 1567 };
        keyBinding = array[UnityEngine.Random.Range(0, array.Length-1)];
    }
}
