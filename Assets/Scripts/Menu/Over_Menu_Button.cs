using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over_Menu_Button : MonoBehaviour
{
    public GameObject m_MenuButton;
    public void MouseOver(bool isOn)
    {
        m_MenuButton.GetComponent<Animator>().SetBool("IsAnimate", isOn);
    }
}
