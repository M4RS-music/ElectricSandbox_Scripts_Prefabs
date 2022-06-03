using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Minimize : MonoBehaviour
{
    public GameObject panel;
    
    public void showHide()
    {
        if (panel.activeSelf) {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
}
