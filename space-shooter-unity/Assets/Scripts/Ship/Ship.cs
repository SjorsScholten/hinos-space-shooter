using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace hinos.ships {

    [CreateAssetMenu(menuName = "Hinos/Ship", fileName = "new Ship")]
    public class ShipData : ScriptableObject {
        [SerializeField] private string displayName;
        [SerializeField, TextArea] private string description;

        public string DisplayName {
            get => displayName;
        }

        public string Description {
            get => description;
        }
    }

    public class ShipInstance {
        private ShipData data;
        
        private int health;

        private int bombCount;

        public event Action OnHealthChangedEvent;

        public ShipInstance(ShipData data) {
            this.data = data;
        }

        public void Initialize() {

        }
    }

    public class ShipController {

        public void ApplyDamage() {

        }

        public void RemoveBomb() {

        }
    }
}
