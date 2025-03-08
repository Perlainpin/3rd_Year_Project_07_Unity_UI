using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main : MonoBehaviour
{
    [Header("Input")]
    private Input_System action;
    private InputAction Menu;
    private InputAction Interact;
    private InputAction Camera;

    public GameObject m_MenuPanel;
    public GameObject m_MenuPanelBackground;
    public GameObject m_OptionsMenuPanel;
    public GameObject m_ControlsMenuPanel;

    private void Awake()
    {
        action = new Input_System();
    }

    private void OnEnable()
    {
        Menu = action.Milk_Action_Map.Menu;
        Menu.Enable();

        Menu.performed += OpenMenu;
    }

    private void OnDisable()
    {
        Menu.Disable();

        Menu.performed -= OpenMenu;
    }
    private void OpenMenu(InputAction.CallbackContext context)
    {
        if (!m_OptionsMenuPanel.GetComponent<SlidingPanelVertical>().isOn)
        {
            m_OptionsMenuPanel.GetComponent<SlidingPanelVertical>().OnToggleValueChanged();
        }
        else if (!m_ControlsMenuPanel.GetComponent<SlidingPanelVertical>().isOn)
        {
            m_ControlsMenuPanel.GetComponent<SlidingPanelVertical>().OnToggleValueChanged();
        }
        else
        {
            m_MenuPanelBackground.SetActive(!m_MenuPanelBackground.activeSelf);
        }

        m_MenuPanel.GetComponentInChildren<SlidingPanelVertical>().OnToggleValueChanged();

    }
}
