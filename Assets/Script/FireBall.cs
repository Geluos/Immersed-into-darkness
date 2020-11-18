using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    private Transform target;
    public int damage;

    private UnityEngine.Object explosionRed;

    private GameObject explosionRedRef;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        explosionRed = Resources.Load("ExplosianRed");
        explosionRedRef = (GameObject)Instantiate(explosionRed);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        explosionRedRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.tag == "Enemy")
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            Destroy(explosionRedRef);
        }
    }
}
