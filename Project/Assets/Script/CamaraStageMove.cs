using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamaraStageMove : MonoBehaviour
{

    public StageTrg ToStage1;    // シーン遷移判定
    private bool isToStage1 = false;  // シーンフラグ

    public float MoveLen;
    public float waitTime;
    public float Time;
    public bool  isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isToStage1 = ToStage1.IsStage();

        if (isToStage1)
        {
            if(!isMove)
            {
                isMove = true;
                StartCoroutine(Move());
                
            }
            
        }
    }

    public IEnumerator Move()
    {

        yield return new WaitForSeconds(waitTime);
        transform.DOMove(new Vector2(transform.position.x, transform.position.y + MoveLen), Time);
    }

}
