using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 7f;
    public float speed = 9f;
    public bool grounded;
    public float jumpPower = 3.5f;
    public float dodgePower = 15f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private PlayerController player;
    private bool jump;
    private bool dodge;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        if (Input.GetKeyDown(KeyCode.UpArrow)&&grounded)
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.G)&& Input.GetKeyDown(KeyCode.H))
        {
            dodge = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);
        float limitSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitSpeed, rb2d.velocity.y);
        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
        if (dodge)
        {
            rb2d.AddForce(Vector2.right * dodgePower, ForceMode2D.Impulse);
            //rb2d.AddForce(Vector2.left * dodgePower, ForceMode2D.Impulse);
            dodge = false;
        }
        Debug.Log(rb2d.velocity.x);
    }
    void OnBecameInvisible()
    {
        transform.position = new Vector3(-6.12f, 1.26f, 0f);
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }
    }
}
