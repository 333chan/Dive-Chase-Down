using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDoorTrg : MonoBehaviour
{
    private string CatTag = "Cat";    // ínñ É^ÉO
    private bool isCatDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsCatDoor()
    {
        return isCatDoor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == CatTag)
        {
            isCatDoor = true;
        }
    }
}
