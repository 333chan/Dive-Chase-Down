using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public DoorTrg Dtrg;
    private bool isDtrg = false;  // ドアトリガー
    private bool isPingPong = true;  // ドアトリガー

    public float PingPong;

    public GameObject ExitLogo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        isDtrg = Dtrg.IsPDoor();

        if (isDtrg)
        {
            Vector3 pos = new Vector3(transform.position.x,
                transform.position.y +2.4f,
                transform.position.z);

            if (isPingPong)
            {


                Instantiate(ExitLogo, pos, Quaternion.identity);
                isPingPong = false;

            }
        }
        else
        {
            isPingPong = true;
        }
    }
}
