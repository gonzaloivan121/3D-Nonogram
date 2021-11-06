using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    private Touch touchZero;
    private Touch touchOne;

    private Quaternion rotationX;
    private Quaternion rotationY;
    private Quaternion rotationZ;

    private readonly float rotateSpeedModifier = .1f;

    public float maxZoom = 5f;
    public float minZoom = 1f;

    void Update() {
        if (Input.touchCount == 1) {
            touchZero = Input.GetTouch(0);
            if (touchZero.phase.Equals(TouchPhase.Moved)) {
                RotateShape();
            }
        } else if (Input.touchCount == 2) {
            touchZero = Input.GetTouch(0);
            touchOne = Input.GetTouch(1);
            if (touchZero.phase.Equals(TouchPhase.Moved)) {
                RotateShape();
                Zoom(CalculatePinchDifference() * .0075f);
            }
        }
    }

    void RotateShape() {
        rotationX = Quaternion.Euler(touchZero.deltaPosition.y * rotateSpeedModifier, 0f, 0f);
        rotationY = Quaternion.Euler(0f, -touchZero.deltaPosition.x * rotateSpeedModifier, 0f);
        rotationZ = Quaternion.Euler(0f, 0f, touchOne.deltaPosition.x * rotateSpeedModifier);

        transform.rotation = rotationY * transform.rotation;
        transform.rotation = rotationX * transform.rotation;
        transform.rotation = rotationZ * transform.rotation;
    }

    void Zoom(float increment) {
        transform.localScale = ClampScale(increment);
    }

    Vector3 ClampScale(float increment) {
        return new Vector3(
            Mathf.Clamp(transform.localScale.x + increment, minZoom, maxZoom),
            Mathf.Clamp(transform.localScale.y + increment, minZoom, maxZoom),
            Mathf.Clamp(transform.localScale.z + increment, minZoom, maxZoom)
        );
    }

    float CalculatePinchDifference() {
        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        return currentMagnitude - prevMagnitude;
    }

}
