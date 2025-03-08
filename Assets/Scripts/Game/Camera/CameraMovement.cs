using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private float _zoomStep, _minCameraSize, _maxCameraSize;

    [SerializeField] private SpriteRenderer _firstSpriteRenderer;
    [SerializeField] private SpriteRenderer _sencondSpriteRenderer;
    [SerializeField] private SpriteRenderer _thirdSpriteRenderer;
    [SerializeField] private SpriteRenderer _fourthSpriteRenderer;

    private SpriteRenderer _actualMapRenderer;

    private Vector3 _dragOrigin;

    public enum Scale { Regional, National, European, World };
    public Scale _milkScale;

    private float _mapMinX, _mapMaxX, _mapMinY, _mapMaxY;


    private void Awake()
    {
        _milkScale = Scale.Regional;
        UpdateMapRenderer(_firstSpriteRenderer);
    }

    private void Update()
    {
        PanCamera();

        HandleZoom();

        switch (_milkScale)
        {
            case Scale.National:
                UpdateMapRenderer(_sencondSpriteRenderer);
                _zoomStep = 0.005f;
                _minCameraSize = 0.05f;
                _maxCameraSize = 0.2f;
                break;
            case Scale.European:
                UpdateMapRenderer(_thirdSpriteRenderer);
                _zoomStep = 0.05f;
                _minCameraSize = 0.05f;
                _maxCameraSize = 1;
                break;
            case Scale.World:
                UpdateMapRenderer(_fourthSpriteRenderer);
                _zoomStep = 0.1f; 
                _minCameraSize = 0.05f;
                _maxCameraSize = 3.5f;
                break;
            default:
                break;
        }

    }

    private void UpdateMapRenderer(SpriteRenderer spriteRenderer)
    {
        _actualMapRenderer = spriteRenderer;

        _mapMinX = _actualMapRenderer.transform.position.x - _actualMapRenderer.bounds.size.x /2f;
        _mapMaxX = _actualMapRenderer.transform.position.x + _actualMapRenderer.bounds.size.x /2f;

        _mapMinY = _actualMapRenderer.transform.position.y - _actualMapRenderer.bounds.size.y / 1.5f;
        _mapMaxY = _actualMapRenderer.transform.position.y + _actualMapRenderer.bounds.size.y / 1.5f;
    }

    private void PanCamera()
    {

        if (Input.GetMouseButtonDown(2))
            _dragOrigin = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(2))
        {
            Vector3 difference = _dragOrigin - _camera.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log("origin " + _dragOrigin + " newPosition " + _camera.ScreenToWorldPoint(Input.mousePosition) + " = difference " + difference);

            _camera.transform.position = ClampCamera(_camera.transform.position + difference);

        }

        Debug.Log(_camera.transform.position);

    }
    private void HandleZoom()
    {
        if (Input.mouseScrollDelta.y == 0) return;

        if (Input.mouseScrollDelta.y > 0)
            ZoomIn();
        else 
            ZoomOut();
    }

    private void ZoomIn()
    {
        Debug.Log("zoomingIn");

        float newSize = _camera.orthographicSize - _zoomStep * Input.mouseScrollDelta.y;
        _camera.orthographicSize = Mathf.Clamp(newSize, _minCameraSize, _maxCameraSize);

        _camera.transform.position = ClampCamera(_camera.transform.position);
    }

    private void ZoomOut()
    {
        Debug.Log("zoomingOut");

        float newSize = _camera.orthographicSize + (-_zoomStep) * Input.mouseScrollDelta.y;
        _camera.orthographicSize = Mathf.Clamp(newSize, _minCameraSize, _maxCameraSize);

        _camera.transform.position = ClampCamera(_camera.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = _camera.orthographicSize;
        float camWidth = _camera.orthographicSize * _camera.aspect;

        float minX = _mapMinX + Mathf.Min(camWidth, _actualMapRenderer.bounds.size.x / 2f);
        float maxX = _mapMaxX - Mathf.Min(camWidth, _actualMapRenderer.bounds.size.x / 2f);

        float minY = _mapMinY + Mathf.Min(camWidth, _actualMapRenderer.bounds.size.x / 2f);
        float maxY = _mapMaxY - Mathf.Min(camWidth, _actualMapRenderer.bounds.size.x / 2f);

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, -10);
    }
}
