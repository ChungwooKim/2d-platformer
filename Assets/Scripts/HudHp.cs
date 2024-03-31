using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHp : MonoBehaviour
{
    public Sprite hasHpSprite;
    public Sprite hasNoHpSprite;

    public List<Image> hearts = new List<Image>();

    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        for(int i=0; i<hearts.Count; i++) 
        {
            if (i < player.hp)
            {
                hearts[i].sprite = hasHpSprite;
            }

            else
            {
                hearts[i].sprite = hasNoHpSprite;
            }
        }
    }
}
