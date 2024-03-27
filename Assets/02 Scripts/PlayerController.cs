using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;


    public float speed;
    public float jumpForce = 10;
    public Rigidbody2D rb2d;
    private int deaths = 0;
    [SerializeField] private float moveVertical; // = Input.GetAxis("Vertical");
    [SerializeField] float moveHorizontal;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] Health playerHealth;
    public Transform groundChecker;
    //flip
    bool facingRight = true;
    public Transform lastCheckPoint;    //last collided checkpoint.

    [Header("Debug")]
    [SerializeField] private bool isGrounded;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastCheckPoint = GameObject.FindGameObjectWithTag("CheckPoint1").transform; // Finds initial checkpoint
        playerHealth = gameObject.GetComponent<Health>();
    }


    private void FixedUpdate()  // Runs before update.
    {
        isGrounded = IsGrounded();  // Uses function to determine if the player is on the floor.
        if (playerHealth.health <= 0) DeathSituation();
        CheckFallOutLevel();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);   // Determine velocity and apply to playerObject.

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)  //if SPACE & player is on ground, makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        //Flip animation
        if (moveHorizontal > 0 && facingRight == false)
        {
            Flip();
        }
        if (moveHorizontal < 0 && facingRight == true)
        {
            Flip();
        }
        //Animation automation
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        animator.SetFloat("Vertical", rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.P)) MapChecker.instance.NextLevel();
    }


    public void UpdateCheckPoint(Transform checkpoint)
    {
        lastCheckPoint = checkpoint;
    }

    private bool IsGrounded()
    {
        //Debug.DrawRay(groundChecker.position, -Vector3.up * 0.3f , Color.red, 3.0f);   // Visiualizing raycast
        return Physics2D.Raycast(groundChecker.position, -Vector3.up, 0.3f, groundLayerMask);    // Raycast down to check if collision is made.
    }


    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public void DeathSituation()
    {
        rb2d.velocity = Vector3.zero;
        transform.position = lastCheckPoint.position;
        playerHealth.ResetHealth();
        deaths += 1;
        UIManager.instance.DisplayDeaths(deaths);
    }

    [SerializeField] private TextMeshProUGUI textMeshPro;
    private void UpdateDeathCounter()
    {
        textMeshPro.text = deaths.ToString();
    }

    void CheckFallOutLevel()
    {
        if (transform.position.y < -80) DeathSituation(); //Debug.Log("Fallen out of map");
    }

}

