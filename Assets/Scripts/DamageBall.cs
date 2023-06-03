using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBall : MonoBehaviour
{

    [SerializeField]
    GameObject restartPanel;

    Rigidbody2D rb;
    float ballSpeed = 4f;
    float endTime = 5f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {

        rb.velocity = -transform.right * ballSpeed;

        Destroy(gameObject, endTime);
    }



}
