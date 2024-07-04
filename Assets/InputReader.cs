using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputReader : MonoBehaviour
{
    public WalkBehaviour walkBehaviour;

    private PlayerInput playerInput;
    private InputAction walkAction;


    private void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();

        walkAction = playerInput.actions.FindAction("Move");
        walkAction.performed += OnMoveInput;

    }
    private void Awake()
    {
        if (walkBehaviour == null)
        {
            Debug.LogError($"{name}: {nameof(walkBehaviour)} is null!" +
                           $"\nThis class is dependant on a {nameof(walkBehaviour)} component!");
        }
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        if (walkBehaviour != null)
            walkBehaviour.Move(moveInput);
    }

    private void OnDisable()
    {
        walkAction.performed -= OnMoveInput;
    }
}
