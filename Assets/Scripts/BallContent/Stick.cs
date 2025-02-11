using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField]private float _clubDistanceFromBall = 1.0f;
    
    public void Dragging(Vector3 ballPosition,float normalizedDragDistance,Vector3 direction)
    {
        float maxRotationAngle = 45f;
        float accelerationFactor = 15f;
        float rotationZ = Mathf.Lerp(0, maxRotationAngle * accelerationFactor, normalizedDragDistance);
        Vector2 toBall = transform.position - ballPosition;
        float angle = Mathf.Atan2(toBall.y, toBall.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationZ));
        Vector3 offset = new Vector3(-direction.x, -direction.y, 0).normalized * _clubDistanceFromBall;
        transform.position = ballPosition + offset;
    }
    
    public void SetValue(bool enabled)
    {
        gameObject.SetActive(enabled);
    }

    public void ReturnDefaultLocalEuler()
    {
        SetValue(false);
        transform.localEulerAngles = Vector3.zero;
    }
}