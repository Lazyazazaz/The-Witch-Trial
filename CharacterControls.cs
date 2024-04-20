using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControls : MonoBehaviour
{
    public static CharacterControls Instance { get; private set; }

    private CharacterInputActions characterInputActions;

    public event EventHandler OnCharacterAttack;

    private void Awake()
    {
        Instance = this;
        characterInputActions = new CharacterInputActions();
        characterInputActions.Enable();
        characterInputActions.Combat.Attack.started += CharacterAttack_started;
    }

    private void CharacterAttack_started(InputAction.CallbackContext obj)
    {
        OnCharacterAttack?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = characterInputActions.Character.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }
}
