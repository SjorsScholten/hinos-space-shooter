using UnityEngine;

namespace hinos.ship
{
    public class PlayerShipController {
        private ShipInstance shipInstance;

        public PlayerShipController(ShipInstance shipInstance) {
            this.shipInstance = shipInstance;
        }

        public void AddBomb() {
            
        }

        public void RemoveBomb() {

        }

        public void HandleCruiseInput(bool value) {
            shipInstance.Movement.SetCruising(value);
        }

        public void HandleMoveInput(Vector2 moveVector) {
            var direction = moveVector.normalized;
            var throttle = moveVector.magnitude;
            shipInstance.Movement.HandleMove(direction, throttle);
        }

        public void HandleRotateInput(float turnAxis) {
            shipInstance.Movement.HandleRotate(turnAxis);
        }

        public void HandleFireInput(bool value) {
            if(value) {
                
            }
        }
    }
}
