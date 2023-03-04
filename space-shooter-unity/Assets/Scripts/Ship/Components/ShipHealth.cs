using System;
using UnityEngine;

namespace hinos.ship
{
    public class ShipHealth : MonoBehaviour, IDamageHandler {
        private int health;
        public event Action OnHealthChangedEvent;

        public void SetHealth(int value) {
            health = value;
            OnHealthChangedEvent.Invoke();
        }
        
        public void HandleDamageRecieved(DamageData data) {
            //shipController.ApplyDamage(data);
        }
    }
}
