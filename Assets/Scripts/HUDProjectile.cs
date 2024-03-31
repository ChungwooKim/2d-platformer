using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDProjectile : MonoBehaviour
{
    PlayerController player;
    Image image;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        if (player.hasProjectile)
        { 
            image.enabled = true;
        }

        else 
        {
            image.enabled = false;
        }
    }
}
