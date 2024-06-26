using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("플레이어가 가시와 충돌했습니다.");
            Debug.Log(SceneManager.GetActiveScene().buildIndex);

            //게임 오버 이벤트
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.Instance.GameOver();
        }
    }
}
