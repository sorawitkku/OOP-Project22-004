using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Mover
{
    private bool isAlive = true;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(isAlive)
            UpdateMotor(new Vector3(x, y, 0));
        DontDestroyOnLoad(gameObject);
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmounts;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmounts.ToString(), 15, Color.magenta, transform.position, Vector3.zero, 0.5f);
            GameManager.instance.OnHitPointChange();

            if (GameManager.instance.player.hitpoint <= 0)
            {
                GameManager.instance.player.hitpoint = 0;
                Death();
            }

        }
    }

    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.deathMenu.SetTrigger("show");
    }

    public void Respawn_1()
    {
        hitpoint += maxHitpoints;
        isAlive = true;
        lastImmune = Time.time;
    }
}

