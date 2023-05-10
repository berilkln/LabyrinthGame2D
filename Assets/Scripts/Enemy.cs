using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject[] points;
    private int pointIndex = 0;

    float enemySpeed = 4f;

    private void Update()
    {
        if (Vector2.Distance(points[pointIndex].transform.position, transform.position) < 2f)
        {
            pointIndex++;
            if (pointIndex >= points.Length)
            {
                pointIndex = 0;

            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[pointIndex].transform.position, enemySpeed * Time.deltaTime);
    }
}
