using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Projectile projectilePrefab;

    public int hp = 3;
    public float jumpForce = 15f;
    public float moveForce = 5f;

    public float xDirection;
    public bool isGrounded;

    public bool hasKey;
    public bool hasProjectile;

    [SerializeField] float movement;
    Rigidbody2D rigidbody2d;
    Animator animator;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Damage(int damage)
    {
        //Debug.Log(damage + "만큼 데미지를 받았다!!");
        Debug.Log($"{damage}만큼 데미지를 받았다!!");

        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            //게임 오버 이벤트
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.Instance.GameOver();
        } 

        animator.SetTrigger("Hurt");
    }

    void Update()
    {
        //플레이어 캐릭터 방향 처리
        xDirection = Input.GetAxis("Horizontal");
        /*if (xDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(xDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/
        if(Mathf.Abs(xDirection) > 0 ) 
        {
            if (xDirection < 0) transform.localScale = new Vector3(-1, 1, 1);
            else transform.localScale = new Vector3(1, 1, 1);
        }

        movement = xDirection * moveForce;
        if (Mathf.Abs(movement) > 0.1f)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        else 
        {
            animator.SetFloat("Speed", 0f);
        }
        
        //플레이어가 땅(Platforms)에 발을 딛고 있는가?
        isGrounded = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 1.1f, LayerMask.GetMask("Platforms"));
        animator.SetBool("Grounded", isGrounded);

        //조건: 스페이스 바를 눌렀을 때 + 플레이어가 땅에 발을 딛고 있을 때 + 게임 매니저의 상태가 "Running"일 때
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && GameManager.Instance.State == GameManager.GameState.Running)
        {
            //Debug.Log("점프!!");
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        if (hasProjectile && Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("발사체 발사!!!");

            Vector3 playerDirection = new Vector3(transform.localScale.x, 0, 0);

            Projectile projectile = GameObject.Instantiate<Projectile>(
                projectilePrefab, 
                transform.position + playerDirection, 
                Quaternion.identity);

            projectile.Fire(playerDirection);
        }

        //hasProjectile = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(movement, rigidbody2d.velocity.y);
    }
}
