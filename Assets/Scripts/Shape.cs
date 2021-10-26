using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    private Touch touch;
    private Quaternion rotationX;
    private Quaternion rotationY;
    private float rotateSpeedModifier = .1f;

    public float maxZoom = 5f;

    void Update() {
        if (Input.touchCount == 1) {
            touch = Input.GetTouch(0);
            if (touch.phase.Equals(TouchPhase.Moved)) {
                RotateShape();
            }
        } else if (Input.touchCount == 2) {
            Zoom(CalculatePinchDifference() * .01f);
        }
    }

    void RotateShape() {
        rotationX = Quaternion.Euler(touch.deltaPosition.y * rotateSpeedModifier, 0f, 0f);
        rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotateSpeedModifier, 0f);
        transform.rotation = rotationY * transform.rotation;
        transform.rotation = rotationX * transform.rotation;
    }

    void Zoom(float increment) {
        Vector3 newScale = new Vector3(
            Mathf.Clamp(transform.localScale.x + increment, 1f, maxZoom),
            Mathf.Clamp(transform.localScale.y + increment, 1f, maxZoom),
            Mathf.Clamp(transform.localScale.z + increment, 1f, maxZoom)
        );
        transform.localScale = newScale;
    }

    float CalculatePinchDifference() {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        return currentMagnitude - prevMagnitude;
    }

}
