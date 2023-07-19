using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtanDisplay : MonoBehaviour
{


    public DoorTrg Dtrg;
    private bool isDtrg = false;  // ドアトリガー
    private bool isPop = true;  // 出現個数トリガー

    public Connection connection;
    private bool isConnect = false;  // パッド接続トリガー


    public float PosY;

    public GameObject Buttan_B;
    public GameObject Key_E;
    private Vector3 pos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isDtrg = Dtrg.IsPDoor();
        isConnect = connection.IsConnection();

        Vector3 pos = new Vector3(transform.position.x,
            transform.position.y + PosY,
            transform.position.z);


        if (isDtrg)
        {
            if (isPop)
            {
                if (!isConnect)   // 接続されていない場合
                {
                    Instantiate(Key_E, pos, Quaternion.identity);
                }
                else   // 接続されている場合
                {
                    Instantiate(Buttan_B, pos, Quaternion.identity);
                }


                isPop = false;
            }
        }
        else
        {
            isPop = true;
        }
    }
}
