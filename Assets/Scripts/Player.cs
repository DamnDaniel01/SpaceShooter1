using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;

    public float speed;

    public GameObject Projectile;

    public GameObject GameOver;

    public Transform Firepoint;

    // Use this for initialization
    void Start()
    {
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(Projectile, Firepoint.position, Firepoint.rotation);
        }

        if (HP < 1)
        {
            Destroy(gameObject);

            Time.timeScale = 0;

            GameOver.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        HP--;

        if (other.gameObject.tag == "TankEnemy")
        {
            HP = 0;
        }
    }
}
