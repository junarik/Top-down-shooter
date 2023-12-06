using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;

    private Vector2 moveAmount;
    private Animator anim;

    public int health;

    //В редакторі для кожного окремого сердця
    public GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator hurtAnim;


    private SceneTransition sceneTransitions;

    public GameObject hurtSound;

    public GameObject trail;
    private float timeBtwTrail;
    public float startTimeBtwTrail;
    public Transform groundPos;

    private void Start()
    {
        //Підключимо анімації самого гравця
        anim = GetComponent<Animator>();

        // Підключимо Фізику
        rb = GetComponent<Rigidbody2D>();

        //Підключимо скрипт SceneTransition
        sceneTransitions = FindObjectOfType<SceneTransition>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        // Швидкість, + враховуємо діагональ, тому normalized, щоб була 1
        moveAmount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero)
        {
            if (Time.time >= timeBtwTrail)
            {
                Instantiate(trail, groundPos.position, Quaternion.identity);
                timeBtwTrail = Time.time + startTimeBtwTrail;
            }
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
        Instantiate(hurtSound, transform.position, Quaternion.identity);
        health -= amount;
        UpdateHealthUI(health);

        //Визвається окрема панель для одного мигання
        hurtAnim.SetTrigger("hurt");
        if (health <= 0)
        {
            Destroy(this.gameObject);
            sceneTransitions.LoadScene("Lose");
        }
    }

    //визивається у pickup weapons
    public void ChangeWeapon(Weapon weaponToEquip) {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));

        
        Instantiate(weaponToEquip, transform.position, transform.rotation, transform);
    }

    void UpdateHealthUI(int currentHealth) {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].GetComponent<Image>().sprite = fullHeart;
            } else {
                hearts[i].GetComponent<Image>().sprite = emptyHeart;
            }

        }

    }

    //визивається у pickup hurts
    public void Heal(int healAmount) {
        if (health + healAmount > 5)
        {
            health = 5;
        } else {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }


}
