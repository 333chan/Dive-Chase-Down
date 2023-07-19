using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Fead : MonoBehaviour
{
    public float a;
    public float feadSpeed;
    Image feadIamge;

    // Start is called before the first frame update
    void Start()
    {
        feadIamge = GetComponent<Image>();
        a = feadIamge.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (SplashScreen.isFinished)
        {
            if(a <= 0)
            {
                feadIamge.enabled = false;
            }
            else
            {
                a -= feadSpeed * Time.deltaTime;
                feadIamge.color = new Color(feadIamge.color.r, feadIamge.color.g, feadIamge.color.b, a);
            }

        }
    }
}
