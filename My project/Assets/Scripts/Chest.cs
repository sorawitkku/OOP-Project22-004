using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 5;
    public int healAmount = 5;


    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.pesos += pesosAmount;
            GameManager.instance.player.hitpoint += healAmount;
            GameManager.instance.ShowText("+" + pesosAmount, 20, Color.yellow, transform.position, Vector3.up * 50, 0.3f);
            GameManager.instance.ShowText("+" + healAmount  + "hp", 20, Color.green, transform.position, Vector3.down * 50, 0.3f);
            GameManager.instance.OnHitPointChange();
        }
        
    }
    
}
