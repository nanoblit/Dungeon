using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{
    public GameObject MenuGO;

    public void SwitchMenu()
    {
        if (MenuGO.activeSelf) MenuGO.SetActive(false);
        else MenuGO.SetActive(true);
    }
}
