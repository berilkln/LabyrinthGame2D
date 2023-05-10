using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] GameObject restartPanel;
    [SerializeField] Text scoreText, spiritText;
    private float speed = 5f;
    private Vector2 moveVelocity;
    int score = 0;
    int playerLife = 3;


    private void Start()
    {
        spiritText.text = "Spirit: " + playerLife;
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(h, v);
        moveVelocity = movement.normalized * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        PlayerRun(h, v);
        PlayerDirection(h);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            Destroy(collision.gameObject);
            score += 2;
            scoreText.text = "Score: " + score.ToString(); 

        }
        if (collision.tag == "Spirit")
        {
            Destroy(collision.gameObject);
            playerLife++;
            spiritText.text = "Spirit: " + playerLife;

        }
    }

    void Dead(GameObject g)
    {
        if (g.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            restartPanel.SetActive(true);

            playerLife--;
            Debug.Log("can" + playerLife);
            if (playerLife <= 0)
            {
                SceneManager.LoadScene("StartScene");
            }







        }
    }



    #region Yön İşlemi
    void PlayerDirection(float h)
    {
        if (h > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    #endregion

    void PlayerRun(float h, float v)
    {

        if (h != 0 || v != 0)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
    }














}//class
