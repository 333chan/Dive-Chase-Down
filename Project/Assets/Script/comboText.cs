using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comboText : MonoBehaviour
{
    public Text ComboText;
    public GameObject cavas;

    private Vector3 playerPos;  // プレイヤーの座標
    private GameObject canvas;  // キャンバス格納用



    // Start is called before the first frame update
    void Start()
    {
        //playerPos = player.GetComponent<Transform>().position;
        //canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            combos();
        }
    }

    public void combos()
    {
        //Text text;
        //text = Instantiate(combo,new Vector3(0,0,0),Quaternion.identity);
        //text.transform.SetParent(canvas.transform, false);
        //text.transform.position = playerPos;

    }
}
