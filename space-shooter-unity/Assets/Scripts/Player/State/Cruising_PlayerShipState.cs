public class Cruising_PlayerShipState : PlayerShipState {
    public Cruising_PlayerShipState(PlayerShip source, PlayerShipStateFactory factory) : base(source, factory, "Cruising") {
    }

    public override void Enter() {
        
    }

    public override void Exit() {
        
    }

    public override void Update() {
        var heading = source.transform.up;
        var throttle = source.moveVectorInput.y;
        source.HandleMove(heading, 1 + throttle);

        var turnAxis = source.turnAxisInput;
        source.HandleTurn(turnAxis);
    }

    public override void ChangeState() {
        if(!source.cruisePressed) {
            SwitchState(factory.GetHoveringState());
        }
    }
}