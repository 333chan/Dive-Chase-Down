using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMove : MonoBehaviour
{
    public Player2 player;    // プレイヤー情報
    private Vector3 PlayerOffset;   // プレイヤーの初期位置
    private Vector3 Pos;    // 初期位置
    private Vector3 vel;    
    public float Move; // 移動量

    public CameraTrg Ctrg;
    private bool isCtrg = false;  // カメラトリガー

    // Start is called before the first frame update
    void Start()
    {
        PlayerOffset = player.transform.position;
        Pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isCtrg = Ctrg.IsPlayer();
        if(isCtrg == false)
        {
            if (player.SpeedX < 0 && player.rb2d.velocity.x < 0)
            {

                transform.position = new Vector3(
                transform.position.x + Move*Time.deltaTime,
                transform.position.y,
                transform.position.z);
            }
            if (player.SpeedX > 0 && player.rb2d.velocity.x > 0)
            {
                transform.position = new Vector3(
                transform.position.x - Move * Time.deltaTime,
                transform.position.y,
                transform.position.z);
            }
        }


    }
}
