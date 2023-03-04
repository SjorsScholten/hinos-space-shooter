using UnityEngine;

namespace hinos.ship
{
    [CreateAssetMenu(menuName = "Hinos/Ship", fileName = "new Ship")]
    public class ShipData : ScriptableObject {
        [SerializeField] private string displayName;
        [SerializeField, TextArea] private string description;
        [SerializeField] private GameObject prefab;

        public string DisplayName {
            get => displayName;
        }

        public string Description {
            get => description;
        }
    }
}
