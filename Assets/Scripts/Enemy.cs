using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState
    { 
        Patrol, //적이 순찰하는 상태
        Chase   //플레이어 캐릭터를 추적하는 상태
    }

    enum EnemyDirection
    { 
        Left = -1,
        Idle = 0,
        Right = 1
    }

    public float chasingRange = 2f;
    public float changeMindTime = 3f;
    public float moveForce = 2f;
    public float xDirection;
    public bool isGrounded;

    [SerializeField] EnemyState state;
    [SerializeField] EnemyDirection direction;

    [SerializeField] float movement;
    [SerializeField] Vector3 edgeOffset;
    [SerializeField] Vector3 directionToPlayer;
    [SerializeField] float distanceToPlayer;

    Rigidbody2D rigidbody2d;
    Animator animator;
    GameObject player;

    [SerializeField] float elapsedTime;  //마지막으로 방향을 바꾸고 나서 경과한 시간

    private void Start()
    {
        state = EnemyState.Patrol;
        direction = EnemyDirection.Idle;

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        movement = xDirection * moveForce;

        if (Mathf.Abs(movement) > 0.1f)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        //플레이어 캐릭터로 향하는 방향 벡터
        directionToPlayer = player.transform.position - transform.position;

        //플레이어 캐릭터와의 거리
        distanceToPlayer = directionToPlayer.magnitude;

        //적 캐릭터의 앞부분이 절벽이 아닌가?
        isGrounded = Physics2D.CircleCast(transform.position + edgeOffset, 0.3f, Vector2.down, 1.1f, LayerMask.GetMask("Platforms"));
        if(!isGrounded) //isGrounded == false
        {
            /*if (direction == EnemyDirection.Left)
            {
                direction = EnemyDirection.Right;
            }
            else
            {
                direction = EnemyDirection.Left;
            }*/

            direction = direction == EnemyDirection.Left ? EnemyDirection.Right : EnemyDirection.Left;
            xDirection = (float)direction;
            elapsedTime = 0;
        }


        if (xDirection != 0)
        {
            transform.localScale = new Vector3(xDirection, 1, 1);
        }

        if (state == EnemyState.Patrol)
        {
            elapsedTime += Time.deltaTime;
            
            if (elapsedTime >= changeMindTime)
            {
                direction = (EnemyDirection)Random.Range(- 1, 2);
                xDirection = (float)direction;
                elapsedTime = 0;
            }

            if (distanceToPlayer <= chasingRange)
            {
                state = EnemyState.Chase;
            }
        }
        else if(state == EnemyState.Chase) 
        {
            direction = directionToPlayer.x < 0 ? EnemyDirection.Left : EnemyDirection.Right;
            xDirection = (float)direction;

            if(distanceToPlayer > chasingRange)
            {
                state = EnemyState.Patrol;
            }
        }
    }

    private void LateUpdate()
    {
        edgeOffset = new Vector3(transform.localScale.x * 0.5f, 0, 0);
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(movement, rigidbody2d.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + edgeOffset, transform.position + edgeOffset + Vector3.down * 1.1f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chasingRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        { 
            Debug.Log("플레이어가 적과 충돌했습니다.");
            collision.collider.SendMessage("Damage", 1);
        }
    }
}
