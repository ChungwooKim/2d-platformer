using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePickUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ �߻�ü�� �浹�Ͽ����ϴ�.");

            //�߻�ü ȹ�� ó��
            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();
            player.hasProjectile = true;

            //�߻�ü �Ҹ� ó��
            GameObject.Destroy(gameObject);
        }
    }
}
