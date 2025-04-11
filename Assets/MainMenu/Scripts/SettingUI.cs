using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public GameObject mainGO;

    public void Cancle()
    {
        gameObject.SetActive(false);
        mainGO.SetActive(true);
    }
}
