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
    [SerializeField] GameObject restartPanel, endPanel, gameoverPanel;
    //[SerializeField] GameObject[] spiritImage;
    [SerializeField] Text scoreText, spiritText;
    private float speed = 5f;
    private Vector2 moveVelocity;
    int score = 0;
    public int playerLife = 3;
    public static bool isDead = false;
    public static bool isStart = true;

    private void Start()
    {
        //PlayerPrefs.DeleteKey("PlayerLife");
        playerLife = PlayerPrefs.GetInt("PlayerLife");
        spiritText.text = "Spirit: " + playerLife;
        if (GameManager.isRestart) //!!
        {
            isDead = false;

        }
        
    }
    private void FixedUpdate()
    {
        if (!isStart)
        {
            return;
        }
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
        if (collision.tag == "Spirit" && playerLife<=3)
        {
            
            Destroy(collision.gameObject);
            playerLife++;
            spiritText.text = "Spirit: " + playerLife;

        }
        if(collision.tag == "House")
        {
            endPanel.SetActive(true);
        }
    }

    void Dead(GameObject g)
    {
        if (g.CompareTag("Enemy"))
        {

            isDead = true;
            Destroy(this.gameObject);
            restartPanel.SetActive(true);
            playerLife--;
            
            PlayerPrefs.SetInt("PlayerLife", playerLife);
            

            Debug.Log("can" + playerLife);
            if (playerLife == -1)
            {
                Debug.Log("Calısti");
                gameoverPanel.SetActive(true);
                //SceneManager.LoadScene("SampleScene");
                
            }


        }
    }
    public void ResetScore()
    {
        if (playerLife == 0)
        {
            gameoverPanel.SetActive(true);
            Debug.Log("Calısti");
            PlayerPrefs.DeleteKey("PlayerLife");
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
