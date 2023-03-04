using UnityEngine;

namespace hinos.ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipMovement : MonoBehaviour {
        [SerializeField] private float acceleration;
        [SerializeField] private float deceleration;
        [SerializeField] private float speed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private float cruiseModifier;

        private Vector2 velocity, desiredVelocity;
        private float angularVelocity, desiredAngularVelocity;
        private bool isCruising = false;

        private Transform myTransform;
        private Rigidbody2D myRigidbody2D;

        private void Awake() {
            myTransform = GetComponent<Transform>();
            myRigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            var maxSpeedChange = acceleration * Time.deltaTime;
            
            ProcessMovement(maxSpeedChange);
            ProcessRotation();
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

        public void SetCruising(bool value) {
            isCruising = value;
        }

        public void HandleMove(Vector2 direction, float throttle) {
            if(isCruising) {
                desiredVelocity = (Vector2)myTransform.up * (cruiseModifier * speed);
            }
            else { 
                desiredVelocity = direction * (throttle * speed);
            }
        }

        public void HandleRotate(float axis) {
            desiredAngularVelocity = axis * turnSpeed;
        }
    }
}
