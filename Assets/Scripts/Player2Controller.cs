using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
{
    public float speed;
    public Text countText;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private int count;
    public int maxHealth = 3;
    int currentHealth;
    public static int level;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        currentHealth = maxHealth;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
        {
            level = 1;
        } 
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
        {
            level = 2;
        }

    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        if (level == 1)
        {
            if (count >= 556)
            {
                SceneManager.LoadScene("Level 2");
            }
        }

        if (level == 2)
        {
            if (count == 557)
            {
                SceneManager.LoadScene("WinScreen");

            }
        }

    }
    
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            count = count + 100;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "High Score: " + count.ToString();
    }

}
