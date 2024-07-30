using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private int amount;
    public TextMeshPro amounttext;
    public SpriteRenderer spriteRenderer;
    public ItemType type;

    public int _amount
    {
        get { return amount; }
        set
        {
            amount = value;
            amounttext.text = amount.ToString();
        }
    }

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Setsprite()
    {
        switch (type)
        {
            case ItemType.heal:
                spriteRenderer.sprite = GameManager.instance.gameAssets.HealSprt;
                break;
            case ItemType.pizza:
                spriteRenderer.sprite = GameManager.instance.gameAssets.pizzaSprt;
                break;
            case ItemType.onion:
                spriteRenderer.sprite = GameManager.instance.gameAssets.onionSprt;
                break;
            case ItemType.cookie:
                spriteRenderer.sprite = GameManager.instance.gameAssets.cookieSprt;
                break;
            default:
                break;
        }

    }
}
