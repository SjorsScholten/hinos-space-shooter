using System;
using UnityEngine;

namespace hinos.weapon
{
    public class WeaponData : ScriptableObject {
        [SerializeField] private string displayName;
        [SerializeField, TextArea] private string description;
    }

    [Serializable]
    public class WeaponInstance {
        [SerializeField] private WeaponData data;
        [SerializeField] private GameObject gameObject;

        private float timeBetweenShots;
        private float timeSinceLastShot;
    }

    public class PlayerWeaponController {

        public void HandleFireInput(bool value){
            if(value) {
            
            }
        }
    }


}