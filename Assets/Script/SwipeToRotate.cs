using UnityEngine;

public class SwipeToRotate : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private bool isSwiping = false;
    public float rotationSpeed = 0.2f; // Adjust for faster/slower rotation

    void Update()
    {
        if (Input.touchCount == 1) // Detect single touch
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Moved && isSwiping)
            {
                currentTouchPosition = touch.position;
                Vector2 swipeDelta = currentTouchPosition - startTouchPosition;

                // Rotate around Y-axis based on horizontal swipe
                transform.Rotate(0, -swipeDelta.x * rotationSpeed, 0, Space.World);

                startTouchPosition = currentTouchPosition; // Update start position
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isSwiping = false;
            }
        }
    }
}
