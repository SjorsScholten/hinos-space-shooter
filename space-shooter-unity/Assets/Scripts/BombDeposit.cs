using UnityEngine;

public class BombDeposit : MonoBehaviour {
    [SerializeField] private int bombCount;

    public void Update() {

    }

    public void OnTriggerEnter2D(Collider2D other) {
        var handler = other.GetComponent<IBombHandler>();
        if(handler != null) {
            ProcessRetrieval(handler);
        }
    }

    private void ProcessRetrieval(IBombHandler handler) {
        if(bombCount > 0) {
            handler.HandleRetrieveBombFromDeposit(this);
        }
    }

}
