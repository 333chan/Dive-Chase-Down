using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestoryEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Destory()
    {
        //オブジェクトの削除
        Destroy(this.gameObject);
    }

}
