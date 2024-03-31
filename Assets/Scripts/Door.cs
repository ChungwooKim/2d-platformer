using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openedDoorSprite;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ���� �浹�߽��ϴ�.");

            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();
            if (player == null)
            {
                return;
            }

            if (player.hasKey)
            {
                //�÷��̾� ���踦 ����
                player.hasKey = false;

                //���� �� ó��
                spriteRenderer.sprite = openedDoorSprite;
                boxCollider2d.enabled = false;
            }
        }
    }
}
