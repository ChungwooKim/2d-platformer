using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ����� �浹�߽��ϴ�.");

            //���� ȹ�� ó��
            PlayerController playerController = collision.collider.gameObject.GetComponent<PlayerController>();
            playerController.hasKey = true;

            //���� �Ҹ� ó��
            GameObject.Destroy(gameObject);
        }
    }
}
