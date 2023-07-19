using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyutoRespawn : MonoBehaviour
{
    public Player2 Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Player.transform.position = this.transform.position;
            Player.rb2d.velocity = new Vector2(Player.rb2d.velocity.x,0);
        }
    }
}
