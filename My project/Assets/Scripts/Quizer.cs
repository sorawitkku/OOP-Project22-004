using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quizer : Collidable
{
    public string quiz;
    protected bool collided;
    protected Vector3 vector;

    protected override void OnCollide(Collider2D coll)
    {   

        if (coll.name == "P'to" && !collided)
        {   
            collided = true;
            GameManager.instance.ShowText(quiz.ToString(), 20, Color.white,new Vector3(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y+0.16f,0), Vector3.zero * 50, 5f) ;
        }
    }
}
