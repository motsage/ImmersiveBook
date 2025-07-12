using UnityEngine;

public class PinchToScale : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;
    private bool isScaling = false;

    void Update()
    {
        if (Input.touchCount == 2) // Detect two fingers on screen
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Calculate the distance between the two fingers
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);

            if (!isScaling)
            {
                initialDistance = currentDistance;
                initialScale = transform.localScale;
                isScaling = true;
            }

            // Scale object based on pinch movement
            if (isScaling)
            {
                float scaleFactor = currentDistance / initialDistance;
                transform.localScale = initialScale * scaleFactor;
            }
        }
        else
        {
            isScaling = false;
        }
    }
}
