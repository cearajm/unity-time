using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // [Header("Input Action Asset")]
    // [SerializeField] private InputActionAsset playerControls;

    // [Header("Action Map Name Reference")]
    // [SerializeField] private string actionMapName = "Player";

    // [Header("Action Name References")]
    // [SerializeField] private string movement = "Movement";
    // [SerializeField] private string rotation = "Rotation";
    // [SerializeField] private string jump = "Jump";
    // [SerializeField] private string sprint = "Sprint";
    // [SerializeField] private string movement = "Move";
    // [SerializeField] private string rotation = "Look";
    // [SerializeField] private string jump = "Jump";
    // [SerializeField] private string sprint = "Sprint";

    // [SerializeField] private string pause = "Pause";
    // private InputAction pauseAction;
    // public bool PauseTriggered { get; private set; }

    public PauseMenu pauseMenu;

    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction pauseAction;

    public Vector2 MovementInput { get; private set; }
    public Vector2 RotationInput { get; private set; }
    public bool JumpTriggered { get; private set; }
    public bool SprintTriggered { get; private set; }
    public bool PauseTriggered { get; private set; }


    private void Start()
    {
        // InputActionMap mapReference = playerControls.FindActionMap(actionMapName);
        // Debug.Log("ref: " + mapReference);

        // movementAction = mapReference.FindAction(movement);
        // rotationAction = mapReference.FindAction(rotation);
        // jumpAction = mapReference.FindAction(jump);
        // sprintAction = mapReference.FindAction(sprint);

        movementAction = InputSystem.actions.FindAction("Move");
        rotationAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");
        sprintAction = InputSystem.actions.FindAction("Sprint");

        pauseAction = InputSystem.actions.FindAction("Cancel");

        // movementAction.Enable();

        // pauseAction = mapReference.FindAction(pause);

        SubscribeActionValuesToInputEvents();

        pauseMenu.Test();
        Debug.Log(pauseAction);
    }

    private void SubscribeActionValuesToInputEvents()
    {
        // called every time the input action changes
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;

        jumpAction.performed += inputInfo => JumpTriggered = true;
        jumpAction.canceled += inputInfo => JumpTriggered = false;

        sprintAction.performed += inputInfo => SprintTriggered = true;
        sprintAction.canceled += inputInfo => SprintTriggered = false;

        pauseAction.performed += inputInfo => PauseTriggered = true;
        pauseAction.canceled += inputInfo => PauseTriggered = false;

        // pauseAction.canceled += inputInfo => PauseTriggered = false;

    }

    private void OnEnable()
    {
        // playerControls.FindActionMap(actionMapName).Enable();
        // InputSystem.Enable();
    }

    // private void OnDisable()
    // {
    //     playerControls.FindActionMap(actionMapName).Disable();
    // }


}
