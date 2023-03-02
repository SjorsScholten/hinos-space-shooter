using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using hinos.util;

public class PlayerShip : MonoBehaviour, IStateMachine<PlayerShip> {
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float cruiseModifier;

    [SerializeField] private GameObject shipObject;

    // Input
    // TODO: Create input handler class
    private DefaultActions actions; 
    public Vector2 moveVectorInput { get; private set; }
    public float turnAxisInput { get; private set; }
    public bool cruisePressed { get; private set; }
    public bool firePressed { get; private set; }

    // Physics
    private Vector2 velocity, desiredVelocity;
    private float angularVelocity, desiredAngularVelocity;

    // State
    private PlayerShipStateFactory stateFactory;
    private State<PlayerShip> currentState;

    // Components
    private Transform myTransform;
    private Rigidbody2D myRigidbody2D;

    private void Awake() {
        myTransform = GetComponent<Transform>();
        myRigidbody2D = GetComponent<Rigidbody2D>();

        // Intialize input
        actions = new DefaultActions();

        // Initialize state
        stateFactory = new PlayerShipStateFactory(this);
        currentState = stateFactory.GetHoveringState();
    }

    private void OnEnable() {
        actions.Player.Enable();
    }

    private void OnDisable() {
        actions.Player.Disable();
    }

    private void Update() {
        PollInput();

        if(firePressed) {
            ProcessFireProjectile();
        }

        ProcessRollEffect();

        currentState.Update();
        currentState.ChangeState();
    }

    private void FixedUpdate() {
        var maxSpeedChange = acceleration * Time.deltaTime;

        ProcessMovement(maxSpeedChange);
        ProcessRotation();
    }

    private void PollInput() {
        moveVectorInput = actions.Player.Move.ReadValue<Vector2>();
        turnAxisInput = actions.Player.Turn.ReadValue<float>();
        firePressed = actions.Player.Fire.IsPressed();
        cruisePressed = actions.Player.Cruise.IsPressed();
    }

    private void ProcessMovement(float maxSpeedChange) {
        velocity = myRigidbody2D.velocity;
        velocity = Vector2.MoveTowards(velocity, desiredVelocity, maxSpeedChange);
        myRigidbody2D.velocity = velocity;
    }

    private void ProcessRotation() {
        angularVelocity = myRigidbody2D.angularVelocity;
        myRigidbody2D.angularVelocity = desiredAngularVelocity;
    }

    private void ProcessFireProjectile() {
        
    }

    private void ProcessRollEffect() {
        //TODO: Use animation to apply roll effect
        var currentRot = shipObject.transform.localRotation;
        var targetRot = Quaternion.Euler(0, turnAxisInput * 45f, 0);
        var maxRotChange = 90f * Time.deltaTime;
        shipObject.transform.localRotation = Quaternion.RotateTowards(currentRot, targetRot, maxRotChange); ;
    }

    public void HandleMove(Vector2 direction, float throttle) {
        desiredVelocity = direction * (throttle * speed);
    }

    public void HandleTurn(float steerAxis) {
        desiredAngularVelocity = steerAxis * turnSpeed;
    }

    public void HandleSwitchState(State<PlayerShip> oldState, State<PlayerShip> newState) {
        oldState.Exit();
        newState.Enter();
        currentState = newState;
    }
}
