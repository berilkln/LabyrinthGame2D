using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject rulesPanel;
    public void OpenRule() {
        rulesPanel.SetActive(true);

    }

    public void CloseRule()
    {
        rulesPanel.SetActive(false);

    }


    public void OyunuDurdur()
    {
        Time.timeScale = 0;
        rulesPanel.SetActive(true);


    }
    public void DevamEt()
    {
        Time.timeScale = 1;
        rulesPanel.SetActive(false);

    }
}
