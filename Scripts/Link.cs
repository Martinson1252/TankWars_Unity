using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Link : MonoBehaviour
{
    public void OpenLink(TextMeshProUGUI t)
    {
        Application.OpenURL(t.text.Trim('(',')'));
    }
}
