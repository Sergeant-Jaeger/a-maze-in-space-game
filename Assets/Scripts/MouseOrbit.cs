using System.Collections;
using UnityEngine;
 
[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbit : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distance = 5.0f;

    [SerializeField]
    private float xSpeed = 120.0f;

    [SerializeField]
    private float ySpeed = 120.0f;

    [SerializeField]
    private float yMinLimit = -20f;

    [SerializeField]
    private float yMaxLimit = 80f;

	private float x = 0.0f;
	private float y = 0.0f;

    public static float ClampAngle(float angle, float min, float max) {
        if (angle < -360F) {
            angle += 360F;
        }

        if (angle > 360F) {
            angle -= 360F;
        }

        return Mathf.Clamp(angle, min, max);
    }

    private void Start() {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}

	private void LateUpdate() {
		if (target)
		{
			if (Input.GetMouseButton(0))
			{
				x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			}

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);

			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = (rotation * negDistance) + target.position;

			transform.rotation = rotation;
			transform.position = position;
		}
	}
}