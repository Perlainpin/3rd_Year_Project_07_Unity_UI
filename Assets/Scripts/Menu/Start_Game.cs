using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class Start_Game : MonoBehaviour
{
    public GameObject m_TitlePanel;
    public GameObject m_MainMenuPanel;

    private float m_SlideDuration = 0.5f;
    private Coroutine m_SlideCoroutine;

    void Start()
    {
        m_TitlePanel.GetComponent<SlidingPanelVertical>().OnToggleValueChanged();
        m_MainMenuPanel.GetComponent<SlidingPanelVertical>().OnToggleValueChanged();

        
        // Si une coroutine est déjà en cours, l'arrêter
        if (m_SlideCoroutine != null)
        {
            StopCoroutine(m_SlideCoroutine);
        }

        m_TitlePanel.GetComponent<Animator>().SetBool("IsAnimate", false);

        m_SlideCoroutine = StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        float elapsedTime = 0f;
        while (elapsedTime < m_SlideDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null; // Attendre le frame suivant
        }

        m_TitlePanel.GetComponent<Animator>().SetBool("IsAnimate", true);
        // La coroutine est terminée
        m_SlideCoroutine = null;
    }


}
