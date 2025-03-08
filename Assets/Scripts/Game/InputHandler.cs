
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClickLeft(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return;

        if (!rayHit.collider.gameObject.TryGetComponent(out IInteractive interactive)) return;


        interactive.OnClick();

    } 

    public void OnClickRight(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return;

        if (!rayHit.collider.gameObject.TryGetComponent(out IInteractive interactive)) return;

        
        interactive.Interact();

    }
    
    public void OnMapDrag(InputAction.CallbackContext context)
    {
        if (_mainCamera.TryGetComponent(out CameraMovement cameraMovement)) return;

    }
}
