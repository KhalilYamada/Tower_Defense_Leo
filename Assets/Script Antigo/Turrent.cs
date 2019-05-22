using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{  
    private Transform target;

    [Header("Attributes")]
    public float FireRate = 1f;
    private float FireCountdown = 0f;
    public float range = 15f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Inimigo";
    public Transform partToRotate;
    public float turnSpeed = 10f;


    public GameObject bulletPrefab;
    public Transform firePoint;

    


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void Update()
    {
        if (target == null)
        {
            return;
        }

        //Target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (FireCountdown <= 0f)
        {
            Shoot();
            FireCountdown = 1f / FireRate;
        }

        FireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject nearstEnemy = null;

        foreach (GameObject Inimigo in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, Inimigo.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearstEnemy = Inimigo;
            }
        }

        if (nearstEnemy != null && shortesDistance <= range)
        {
            target = nearstEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

     
}
