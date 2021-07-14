using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarColorChange : MonoBehaviour
{
    public GameObject bar;
    public Color middleColor;
    public Color edgeColor;
    public float midPos;
    public float rightEdgePos;
    public float leftEdgePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bar.transform.position.x > 0)
        {
            float lerpParm = Mathf.InverseLerp(midPos, rightEdgePos, bar.transform.position.x);
            bar.GetComponent<Image>().color = Color.Lerp(middleColor, edgeColor, lerpParm);
        }
        if (bar.transform.position.x < 0)
        {
            float lerpParm = Mathf.InverseLerp(midPos, leftEdgePos, bar.transform.position.x);
            bar.GetComponent<Image>().color = Color.Lerp(middleColor, edgeColor, lerpParm);
        }

    }
}
