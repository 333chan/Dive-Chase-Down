using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpBedCollsionOff : MonoBehaviour
{
    public BoxCollider2D Bed;
    public OpPlayer opPlayer;
    private bool isPlayerGetUp = false;
    private bool isCollsionOff = false;

    public float WaitTime;

    // Start is called before the first frame update
    void Start()
    {
        Bed = Bed.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerGetUp = opPlayer.IsGetUp();
        if(!isCollsionOff&&isPlayerGetUp)
        {
            StartCoroutine(CollsionOff());
        }
    }

    public IEnumerator CollsionOff()
    {

        yield return new WaitForSeconds(WaitTime);
        Bed.enabled = false;
        isCollsionOff = true;
    }
}
