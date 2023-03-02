public class Hovering_PlayerShipState : PlayerShipState {
    public Hovering_PlayerShipState(PlayerShip source, PlayerShipStateFactory factory) : base(source, factory, "Hovering") {
    }

    public override void Enter() {
        
    }

    public override void Exit() {
        
    }

    public override void Update() {
        var moveDirection = source.moveVectorInput.normalized;
        var moveLength = source.moveVectorInput.magnitude;
        source.HandleMove(moveDirection, moveLength);

        var turnAxis = source.turnAxisInput;
        source.HandleTurn(turnAxis);
    }

    public override void ChangeState() {
        if(source.cruisePressed) {
            SwitchState(factory.GetCruisingState());
        }
    }
}
