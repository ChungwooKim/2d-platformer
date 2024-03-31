using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    public float timeToBeDestroyed = 5f;

    Vector3 direction;
    Rigidbody2D rigidbody2D;

    public void Fire(Vector3 direction)
    {
        this.direction = direction;

        GameObject.Destroy(gameObject, timeToBeDestroyed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("발사체가 적과 충돌했습니다.");

            GameObject.Destroy(collision.collider.gameObject);
            GameObject.Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Platform"))
        {
            Debug.Log("발사체가 플랫폼과 충돌했습니다.");

            GameObject.Destroy(gameObject);
        }
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.Paused)
        {
            return;
        }
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = direction * moveSpeed;
    }

}
