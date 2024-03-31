using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDKey : MonoBehaviour
{
    public Sprite hasKeySprite;
    public Sprite hasNoKeySprite;

    PlayerController player;
    Image image;

    void Start()
    {
        //�÷��̾� ������Ʈ �̸� ����(ĳ��)
        player = FindObjectOfType<PlayerController>();

        //�̹��� ������Ʈ �̸� ����
        image = GetComponent<Image>();

        //���� GameObject�� ���縦 �˻�
        GameObject key = GameObject.FindGameObjectWithTag("Key");
        if (key == null)
        { 
            gameObject.SetActive(false);
        }

    }

    void Update()
    {
        if (player == null) return;

        if (player.hasKey)
        {
            image.sprite = hasKeySprite;
        }

        else
        {
            image.sprite = hasNoKeySprite;
        }
    }
}
