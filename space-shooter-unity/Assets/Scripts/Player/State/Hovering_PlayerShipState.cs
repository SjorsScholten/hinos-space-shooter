/*
public class Hovering_PlayerShipState : PlayerShipState {
    public Hovering_PlayerShipState(PlayerShip source, PlayerShipStateFactory factory) : base(source, factory, "Hovering") {
    }

    public override void Enter() {
        
    }

    public override void Exit() {
        
    }

    public override void Update() {
        var moveDirection = source.PlayerInput.MoveVector.normalized;
        var moveLength = source.PlayerInput.MoveVector.magnitude;
        source.HandleMove(moveDirection, moveLength);

        var turnAxis = source.PlayerInput.TurnAxis;
        source.HandleTurn(turnAxis);
    }

    public override void ChangeState() {
        if(source.PlayerInput.CruisePressed) {
            SwitchState(factory.GetCruisingState());
        }
    }
}
*/