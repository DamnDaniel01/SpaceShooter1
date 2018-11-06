using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyController
{
    public Transform Firepoint;

    public GameObject Projectile;
    
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Shoot", 1f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < -10)
        {
            Destroy(Enemy);

            Player1.HP -= 1;
        }

    }

    void Shoot()
    {
        Instantiate(Projectile, Firepoint.position, Firepoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            HP--;
        }

        if(HP < 1)
        {
            Destroy(Enemy);

            Score.scoreValue += 6;
        }
    }
}
