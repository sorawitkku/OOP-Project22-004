using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    // Start is called before the first frame update
    void Start()
    {  
       Player.position = new Vector3(0, 0 ,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
