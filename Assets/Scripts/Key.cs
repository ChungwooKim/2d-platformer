using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("ÇÃ·¹ÀÌ¾î°¡ ¿­¼è¿Í Ãæµ¹Çß½À´Ï´Ù.");

            //¿­¼è È¹µæ Ã³¸®
            PlayerController playerController = collision.collider.gameObject.GetComponent<PlayerController>();
            playerController.hasKey = true;

            //¿­¼è ¼Ò¸ê Ã³¸®
            GameObject.Destroy(gameObject);
        }
    }
}
