using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearCamera : MonoBehaviour
{
    private string PlayerTag = "Player";    // プレイヤータグ

    public Player2 Player;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position -= transform.up * MoveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PlayerTag)
        {
          //  Player.rb2d.gravityScale = 0;
            //Player.rb2d.velocity = Vector3.zero;
            //Player.transform.position = new Vector2(transform.position.x, transform.position.y);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)

        {
          //  Player.rb2d.gravityScale = 0;
            //Player.rb2d.velocity = Vector3.zero;
            //Player.transform.position = new Vector2 (transform.position.x, transform.position.y);
            //  Player.rb2d.velocity = Vector3.zero;
        }
    }
}
