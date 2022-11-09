using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrong_answer : Collidable
{
    protected bool collided;
    protected override void OnCollide(Collider2D coll)

    {
        if (coll.name == "P'to" && !collided)
        {
            collided = true;
            GameManager.instance.ShowText("This is not the correct answer", 20, Color.red, new Vector3(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y + 0.16f, 0), Vector3.zero * 50, 1f);
            GameManager.instance.player.hitpoint -= 5;
            if (GameManager.instance.player.hitpoint < 0)
            {
                GameManager.instance.player.hitpoint = 0;
            }
            GameManager.instance.OnHitPointChange();
        }
    }
}
