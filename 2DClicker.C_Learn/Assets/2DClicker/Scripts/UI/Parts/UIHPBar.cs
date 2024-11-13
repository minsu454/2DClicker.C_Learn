using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : MonoBehaviour
{
    public Image uiBar;

    public void SetUIBar(int curValue, int maxValue)
    {
        uiBar.fillAmount = (float)curValue / maxValue;
    }
}
