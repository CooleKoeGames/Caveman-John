using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private Rigidbody2D rb;
    private bool dead;

    public GameOver gameOver;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("death");
                GetComponent<PlayerMovement>().enabled = false;
                rb.bodyType = RigidbodyType2D.Static;
                gameOver.gameOver();
                dead = true;
            }
        }
    }

    public void Update()
    {
        if (Timer.currentTime == 0f && !dead)
        {
            anim.SetTrigger("death");
            GetComponent<PlayerMovement>().enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            gameOver.gameOver();
            dead = true;
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ItemCollector.foodCollected = 0;
    }
}
