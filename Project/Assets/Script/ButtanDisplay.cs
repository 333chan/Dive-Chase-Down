using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtanDisplay : MonoBehaviour
{


    public DoorTrg Dtrg;
    private bool isDtrg = false;  // �h�A�g���K�[
    private bool isPop = true;  // �o�����g���K�[

    public Connection connection;
    private bool isConnect = false;  // �p�b�h�ڑ��g���K�[


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
                if (!isConnect)   // �ڑ�����Ă��Ȃ��ꍇ
                {
                    Instantiate(Key_E, pos, Quaternion.identity);
                }
                else   // �ڑ�����Ă���ꍇ
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
