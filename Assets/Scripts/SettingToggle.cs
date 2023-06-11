using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingToggle : MonoBehaviour
{
    public GameObject tab;
    public void toggleSetting() {
        tab.SetActive(!tab.activeSelf);
    }
}
