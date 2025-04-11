using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    public float min = 0.1f;
    public float max = 1;
    public float percentNum = 0.1f;
    public float curNum = 0.1f;
    public Text numTxt;
    public bool isSmall;

    private void Start()
    {
        numTxt.text = curNum < 1 ? curNum.ToString("0.0") : curNum.ToString();
    }

    public void Left()
    {
        if (curNum > min)
        {
            curNum -= percentNum;
            if (isSmall && curNum < 0.1f)
                curNum = 0.1f;
            numTxt.text = curNum<1? curNum.ToString("0.0") : curNum.ToString();
        }
    }

    public void Right()
    {
        if (curNum < max)
        {
            curNum += percentNum;
            if (isSmall && curNum > 1)
                curNum = 1;
            numTxt.text = curNum < 1 ? curNum.ToString("0.0") : curNum.ToString();
        }
    }
}
