using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottan : MonoBehaviour
{
    private GameObject Doortrg;
    DoorTrg doorTrgScript;

    private GameObject Player;
    Transform PlayerTrans;

    private bool isDtrg = false;  // ドアトリガー
    private bool isPop = true;  // 生成トリガー

    // Start is called before the first frame update
    void Start()
    {
        Doortrg = GameObject.Find("DoorTrg");
        doorTrgScript = Doortrg.GetComponent<DoorTrg>();

        Player = GameObject.FindWithTag("Player");
        PlayerTrans = Player.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        isDtrg = doorTrgScript.IsPDoor();
        if (isDtrg)
        {
            transform.position = new Vector3(PlayerTrans.position.x, PlayerTrans.position.y+1.0f);

            if (isPop)
            { 
                isPop = false;
            }
        }

        if (!isDtrg)
        {
            Destroy(gameObject);

        }


    }
}
