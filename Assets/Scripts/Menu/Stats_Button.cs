using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class Button : MonoBehaviour
{
    public GameObject m_AddText;
    public GameObject m_LessText;
    public GameObject m_StatsPanel;

    public float slideDuration = 0.5f; // Durée du glissement en secondes
    private Coroutine slideCoroutine; // Référence à la coroutine en cours

    private bool slideOn = false;

    public void OnClick()
    {
        slideOn = !slideOn;

        if (slideOn )
        {
            m_StatsPanel.SetActive(!m_StatsPanel.activeSelf);
        }

        m_AddText.SetActive(!m_AddText.activeSelf);
        m_LessText.SetActive(!m_LessText.activeSelf);

        if (slideCoroutine != null)
        {
            StopCoroutine(slideCoroutine);
        }

        slideCoroutine = StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null; // Attendre le frame suivant
        }

        // La coroutine est terminée
        if (!slideOn)
        {
            m_StatsPanel.SetActive(!m_StatsPanel.activeSelf);
        }
        slideCoroutine = null;
    }
}
