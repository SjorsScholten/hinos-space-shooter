using UnityEngine;
using UnityEngine.InputSystem;
using hinos.util;
using hinos.ship;
/*
    private void ProcessRollEffect(float axis) {
        //TODO: Use animation to apply roll effect
        var currentRot = shipObject.transform.localRotation;
        var targetRot = Quaternion.Euler(0, axis * 45f, 0);
        var maxRotChange = 90f * Time.deltaTime;
        shipObject.transform.localRotation = Quaternion.RotateTowards(currentRot, targetRot, maxRotChange); ;
    }
*/


public class Player : MonoBehaviour {
    [SerializeField] private ShipInstance shipInstance;
    private PlayerShipController controller;

    private DefaultActions actions;
    private Vector2 moveVector;
    private float turnAxis;
    private bool cruisePressed;
    private bool firePressed;

    public void Awake() {
        actions = new DefaultActions();
        controller = new PlayerShipController(shipInstance);
        shipInstance.Initialize(this.gameObject);
    }

    private void OnEnable() {
        actions.Player.Enable();
    }

    private void OnDisable() {
        actions.Player.Disable();
    }

    public void Update() {
        PollInput();

        controller.HandleCruiseInput(cruisePressed);
        controller.HandleMoveInput(moveVector);
        controller.HandleRotateInput(turnAxis);
    }

    public void Initialize() {

    }

    public void PollInput() {
        moveVector = actions.Player.Move.ReadValue<Vector2>();
        turnAxis = actions.Player.Turn.ReadValue<float>();

        firePressed = actions.Player.Fire.IsPressed();
        cruisePressed = actions.Player.Cruise.IsPressed();
    }
}