using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destry : MonoBehaviour
{
    private string EnemyTag = "Enemy";    // ínñ É^ÉO


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == EnemyTag)
        {
            Destroy(collision.gameObject);
        }
    }
}
