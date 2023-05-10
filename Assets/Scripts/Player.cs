using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField]
    Animator anim;
    private float speed = 5f;
    private Vector2 moveVelocity;
    int score = 0;



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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            Destroy(collision.gameObject);
            score += 2;
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
