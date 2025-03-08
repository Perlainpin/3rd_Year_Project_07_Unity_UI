using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over_Stats_Button : MonoBehaviour
{
    public RectTransform panel; // R�f�rence au RectTransform du panneau
    public float closedPositionY; // Position Y ferm�e (panneau hors de l'�cran, en bas)
    public float openPositionY; // Position Y ouverte (panneau visible)
    public float slideDuration = 0.5f; // Dur�e du glissement en secondes

    private Coroutine slideCoroutine; // R�f�rence � la coroutine en cours

    public void MouseOver(bool isOn)
    {
        OnToggleValueChanged(isOn);
    }

    public void OnToggleValueChanged(bool isOn)
    {

        // Si une coroutine est d�j� en cours, l'arr�ter
        if (slideCoroutine != null)
        {
            StopCoroutine(slideCoroutine);
        }

        // D�finir la nouvelle position cible
        float targetY = isOn ? openPositionY : closedPositionY;

        // Lancer une nouvelle coroutine pour effectuer le glissement
        slideCoroutine = StartCoroutine(SlideToPosition(targetY));
    }

    private IEnumerator SlideToPosition(float targetY)
    {
        // Obtenir la position actuelle du panneau
        Vector2 startPosition = panel.anchoredPosition;
        Vector2 targetPosition = new Vector2(startPosition.x, targetY);

        // Glisser sur la dur�e d�finie
        float elapsedTime = 0f;
        while (elapsedTime < slideDuration)
        {
            // Interpolation lin�aire entre la position de d�part et la position cible
            panel.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Attendre le frame suivant
        }

        // S'assurer que la position finale est atteinte
        panel.anchoredPosition = targetPosition;

        // La coroutine est termin�e
        slideCoroutine = null;
    }
}
