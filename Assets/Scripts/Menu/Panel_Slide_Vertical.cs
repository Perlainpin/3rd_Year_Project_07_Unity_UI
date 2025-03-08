using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.Collections.LowLevel.Unsafe;

public class SlidingPanelVertical : MonoBehaviour
{
    public RectTransform panel; // Référence au RectTransform du panneau
    public float closedPositionY; // Position Y fermée (panneau hors de l'écran, en bas)
    public float openPositionY; // Position Y ouverte (panneau visible)
    public float slideDuration = 0.5f; // Durée du glissement en secondes

    private Coroutine slideCoroutine; // Référence à la coroutine en cours
    public bool isOn;

    void Awake()
    {
        isOn = true;
        // Initialiser le panneau en position fermée (en bas)
        panel.anchoredPosition = new Vector2(panel.anchoredPosition.x, closedPositionY);
    }

    public void OnToggleValueChanged()
    {

        // Si une coroutine est déjà en cours, l'arrêter
        if (slideCoroutine != null)
        {
            StopCoroutine(slideCoroutine);
        }

        // Définir la nouvelle position cible
        float targetY = isOn ? openPositionY : closedPositionY;

        // Lancer une nouvelle coroutine pour effectuer le glissement
        slideCoroutine = StartCoroutine(SlideToPosition(targetY));

        isOn = !isOn;
    }

    private IEnumerator SlideToPosition(float targetY)
    {
        // Obtenir la position actuelle du panneau
        Vector2 startPosition = panel.anchoredPosition;
        Vector2 targetPosition = new Vector2(startPosition.x, targetY);

        // Glisser sur la durée définie
        float elapsedTime = 0f;
        while (elapsedTime < slideDuration)
        {
            // Interpolation linéaire entre la position de départ et la position cible
            panel.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Attendre le frame suivant
        }

        // S'assurer que la position finale est atteinte
        panel.anchoredPosition = targetPosition;

        // La coroutine est terminée
        slideCoroutine = null;
    }
}
