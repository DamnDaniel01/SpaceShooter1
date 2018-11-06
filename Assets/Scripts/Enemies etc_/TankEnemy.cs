﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : EnemyController
{

    // Use this for initialization
    void Start()
    {

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            HP--;
        }

        if (HP < 1)
        {
            Destroy(Enemy);

            Score.scoreValue += 10;
        }
    }
}
