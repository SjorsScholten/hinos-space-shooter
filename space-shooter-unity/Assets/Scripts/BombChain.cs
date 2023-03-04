using UnityEngine;

public class BombChain : MonoBehaviour {
    public int chainLength;
    public float bombOffset;
    public float smoothTime = 0.2f;
    public Transform anchor;
    public Transform[] bombTransforms;
    public Vector2[] smoothVelocities;

    private void Update() {
        bombTransforms[0].position = CalculatePosition(bombTransforms[0].position, anchor.position, ref smoothVelocities[0]);
    
        for(var i = 1; i < bombTransforms.Length; i ++) {
            bombTransforms[i].position = CalculatePosition(bombTransforms[i].position, bombTransforms[i - 1].position, ref smoothVelocities[i]);
        }
    }

    private Vector2 CalculatePosition(Vector3 position, Vector3 anchor, ref Vector2 velocity) {
        var direction = (position - anchor).normalized;
        var targetPoint = anchor + direction * bombOffset;
        return Vector2.SmoothDamp(position, targetPoint, ref velocity, smoothTime);
    }
}