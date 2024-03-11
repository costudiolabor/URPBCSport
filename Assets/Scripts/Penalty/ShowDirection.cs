using UnityEngine;

[System.Serializable]
public class ShowDirection {
    [SerializeField] private Transform target;
    public void Show(float difference, Transform parentBall, Vector2 direction, float distance) {
        // distance /= 100;
        // var targetPosition = new Vector3(direction.x, ball.position.y, direction.y);
        // targetPosition = ball.TransformDirection(targetPosition);
        // //targetPosition = ball.InverseTransformDirection(targetPosition);
        // targetPosition *= distance;
        // target.position = targetPosition;
        // Debug.DrawLine(ball.position, targetPosition, Color.red, 0.5f); 
        
        Quaternion rotation = Quaternion.Euler(0f, difference / 50, 0f);
        parentBall.localRotation = rotation;
        target.position = parentBall.position;
        target.rotation = parentBall.localRotation;
    }
}