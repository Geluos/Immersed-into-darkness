using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public int maxHealthPlayer = 100;
    public int currentHealthPlayer;
    private float moveInput;
    private bool faceRight = true;

    private bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int startExtraJump;
    private int extraJump;
    public float jumpForce;
    public HealthBar healthBar;

    public GameObject fireball;
    public Transform spawn;
    private float timeBtwFB;
    public float startTimeBtwFB;
    public TextMeshProUGUI textTimeBtwFB;
    public GameObject reloadImg;

    public GameObject DiedImg;

    private UnityEngine.Object explosionGreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJump = startExtraJump;
        currentHealthPlayer = maxHealthPlayer;
        healthBar.SetMaxHealth(maxHealthPlayer);
        explosionGreen = Resources.Load("ExplosianGreen");
    }

    private void Update()
    {
        if (isGround == true)
        {
            extraJump = startExtraJump;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump --;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        FireBall();
        Heal();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage();
        }

        if(currentHealthPlayer<=0)
        {

            DiedImg.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (faceRight == false && moveInput > 0)
        {
            Flip();
        } else if (faceRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void TakeDamage()
    {
        currentHealthPlayer -= 10;
        healthBar.SetHealth(currentHealthPlayer);
    }

    public void Heal()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentHealthPlayer < maxHealthPlayer)
            {
                currentHealthPlayer += 10;
                healthBar.SetHealth(currentHealthPlayer);
                GameObject explosionGreenRef = (GameObject)Instantiate(explosionGreen);
                explosionGreenRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    public void FireBall()
    {
        if (timeBtwFB <= 0)
        {
            textTimeBtwFB.text = ' '.ToString();
            reloadImg.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Vector2 spawnpos = new Vector2(spawn.position.x, spawn.position.y + 3);
                Instantiate(fireball, spawnpos, Quaternion.identity);
                timeBtwFB = startTimeBtwFB;
            }
        }
        else
        {
            reloadImg.SetActive(true);
            timeBtwFB -= Time.deltaTime;
            textTimeBtwFB.text = Mathf.Ceil(timeBtwFB).ToString();
        }
    }
}
