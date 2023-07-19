using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollson : MonoBehaviour
{
    private string BulletTag = "Bullet";    // ’eƒ^ƒO
    private bool isBullet = false;    // ’e”»’è

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsEnemyBullet()
    {
        return isBullet;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == BulletTag)
        {
            isBullet = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == BulletTag)
        {
            isBullet = false;
        }
    }
}
