using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpSkip : MonoBehaviour
{
    public Slider Skipslider;
    public float valuePow;

    private bool isSkip=false;

    public bool IsSkip()
    {
        return isSkip;
    }

    // Start is called before the first frame update
    void Start()
    {
        Skipslider.value = 0;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Skipslider.value >= 1)
        {
            Skipslider.value = 1;
            isSkip = true;
        }

        if (Input.GetButton("Fire1"))
        {
            if (Skipslider.value <= 1)
            {
                Skipslider.value = Skipslider.value + valuePow * Time.deltaTime;
            }
        }
        else
        {
            if (Skipslider.value < 1)
            {
                Skipslider.value = Skipslider.value - valuePow * Time.deltaTime;
            }
        }



    }
}
