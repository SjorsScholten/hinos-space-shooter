using UnityEngine;

namespace hinos.ship
{
    [System.Serializable]
    public class ShipInstance {
        [SerializeField] private ShipData data;
        [SerializeField] private GameObject gameObject;

        // Components
        private ShipMovement movementComponent;
        private ShipHealth healthComponent;

        public ShipData Data {
            get => data;
        }

        public ShipMovement Movement {
            get => movementComponent;
        }

        public ShipInstance(ShipData data) {
            this.data = data;
        }

        public void Initialize(GameObject source) {
            if(gameObject == null) {
                Debug.LogError($"[SHIP] Initialization Error: no gameobject attatched");
                return;
            }

            movementComponent = gameObject.GetComponent<ShipMovement>();
            healthComponent = gameObject.GetComponent<ShipHealth>();
        }


    }
}
