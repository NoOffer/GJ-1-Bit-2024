using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject BulletWall;
    public GameObject SwordPat;
    public Transform shotLocation;
    public float attackInterval = 2f;
    public float bossLifetime = 100f;
    public float projectileSpeed = 10f;

    private float attackTimer = 0f;
    private float lifeTimer = 0f;
    private int currentAttack = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = bossLifetime;
    }
    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Die();
        }
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            Attack();
            attackTimer = 0f;  // Reset attack timer
        }

    }

    void Attack()
    {
        switch (currentAttack)
        {
            case 0:
                FireBullet();
                break;
            case 1:
                FireBulletWall();
                break;
            case 2:
                SwordPattern();
                break;
        }
        // Cycle through the attacks (0, 1, 2, then back to 0)
        currentAttack = (currentAttack + 1) % 3;
    }

    void FireBullet()
    {



    }

    void FireBulletWall()
    {


    }

    void SwordPattern()
    {


    }

    void Die()
    {
        
        Debug.Log("Boss has died!");
        Destroy(gameObject);  
    }


}






