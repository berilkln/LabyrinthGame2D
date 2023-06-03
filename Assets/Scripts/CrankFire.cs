using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankFire : MonoBehaviour
{
    
    [SerializeField] Transform firePoint;
    public GameObject damageBall;

    private void Start()
    {
        StartCoroutine(Shoot());
    }



    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.9f);
            GameObject newBall = Instantiate(damageBall, firePoint.position, firePoint.rotation);
        }



    }
}
