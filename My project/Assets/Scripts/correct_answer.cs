using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correct_answer : Collidable
{
    protected bool collided;
    protected override void OnCollide(Collider2D coll)

    {
        if (coll.name == "P'to" && !collided)
        {
            collided = true;
            GameManager.instance.ShowText("This is the correct answer", 20, Color.green, new Vector3(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y + 0.16f, 0), Vector3.zero * 50, 1f);
            GameManager.instance.pesos += 100;
            GameManager.instance.player.hitpoint += 5;
            GameManager.instance.OnHitPointChange();
        }
    }
}
