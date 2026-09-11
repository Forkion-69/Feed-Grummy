using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    //References
    private PlayerInput _playerInput;
    //Variables
    public static bool LeftMouseDown;
    public static Vector2 MousePosition;

    //Actions
    private InputAction _LeftMouseClickAction;
    private InputAction _MousePositionAction;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _LeftMouseClickAction = _playerInput.actions["LeftMouseClick"];
        _MousePositionAction = _playerInput.actions["MousePosition"];
    }
    void Update()
    {
        LeftMouseDown = _LeftMouseClickAction.WasPressedThisFrame();
        MousePosition = _MousePositionAction.ReadValue<Vector2>();
        
    }
}
