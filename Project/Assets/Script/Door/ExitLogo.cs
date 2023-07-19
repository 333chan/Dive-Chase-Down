using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExitLogo : MonoBehaviour
{
    private GameObject Doortrg;
    DoorTrg doorTrgScript;
    private bool isDtrg = false;  // ドアトリガー
    private bool isPop = true;  // 生成トリガー

    // Start is called before the first frame update
    void Start()
    {
        Doortrg = GameObject.Find("DoorTrg");
        doorTrgScript = Doortrg.GetComponent<DoorTrg>();

    }

    // Update is called once per frame
    void Update()
    {
        isDtrg = doorTrgScript.IsPDoor();
        if (isDtrg)
        {
            if (isPop)
            {
                transform.DOMove(new Vector3(transform.position.x,
                   -6.5f,
                   transform.position.z)
                    , 0.4f).SetLoops(-1, LoopType.Yoyo);
                isPop = false;
            }
        }

        if (!isDtrg)
        {

            DOTween.KillAll();
            Destroy(gameObject);

        }
        

    }
}
