using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Button : MonoBehaviour
{
    public GameObject m_MenuPanel;
    public GameObject m_MenuPanelBackground;

    public void OnClick()
    {
        Debug.Log("click return button");

        m_MenuPanel.GetComponent<SlidingPanelVertical>().OnToggleValueChanged();

        m_MenuPanelBackground.SetActive(!m_MenuPanelBackground.activeSelf);
    }
}
