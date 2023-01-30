/* 
 * MotionParallax script
 * Author: Cédric Fleury (Univ. Paris-Sud, LRI & Inria)
 * Date: 23/05/2015
 */

using UnityEngine;

public class MotionParallax : MonoBehaviour {

	// Define the screen position in a left-handed reference frame, with Y-up and
	// with the Z axis pointing towards the screen
	// WARNING: the screen has to be perpendicular to the Z axis.
	// The computation of the left, right, bottom, top values can deal with no perpendicular screen,
	// so the deformation is correct. But the camera is not rotated in the correct direction.
	// This roration should be added to fix that, but it is possible overcome this issue:
	// the Transform of the VRSystemCenter can be used to deal with the rotation of the screen.
	public Vector3 leftDownCorner  = new Vector3 (0, 0, 0);
	public Vector3 leftUpCorner    = new Vector3 (0, 0, 0);
	public Vector3 rightDownCorner = new Vector3 (0, 0, 0);

	Camera cam;
	OSCReceiveCameraAdaptive receiver;
    Vector3 headPosition = new Vector3(0, 0, -0.3f);

    // Use this for initialization
    void Start () {
        // get the main camera from the scene
		cam = Camera.main;
        // get the network receiver which receives the head position
		receiver = GetComponent<OSCReceiveCameraAdaptive> ();
	}

	void LateUpdate () {
        cam.transform.localPosition = gameObject.transform.localPosition;
        cam.transform.localRotation = gameObject.transform.localRotation;
        cam.transform.localScale = gameObject.transform.localScale;

        headPosition = receiver.GetHeadPosition();
        // Inverse the Z value to move the head backward relative to the screen.
        // The viewing frustrum is always computed in the positive side.
        headPosition.z = -headPosition.z;
        cam.transform.Translate (headPosition);

		float nearPlane = cam.nearClipPlane;
		float farPlane = cam.farClipPlane;

		// Projection of the head on the 2D horizontal and vertical planes
		Vector2 headHProj = new Vector2 (headPosition.x, headPosition.z);
		Vector2 headVProj = new Vector2 (headPosition.y, headPosition.z);

		// Compute the position of the left, right, bottom and top border of the screen
		// on the 2D horizontal and vertical planes
		Vector2 leftPoint = new Vector2 (leftDownCorner.x, leftDownCorner.z);
		Vector2 rightPoint = new Vector2 (rightDownCorner.x, rightDownCorner.z);
		Vector2 bottomPoint = new Vector2 (leftDownCorner.y, leftDownCorner.z);
		Vector2 topPoint = new Vector2 (leftUpCorner.y, leftUpCorner.z);

		// Compute the vectors on the 2D horizontal plane
		Vector2 right2head = headHProj - rightPoint;
		Vector2 right2left = leftPoint - rightPoint;
		Vector2 right2left_unit = right2left.normalized;

		// Compute the vectors on the 2D vertical plane
		Vector2 top2head = headVProj - topPoint;
		Vector2 top2bottom = bottomPoint - topPoint;
		Vector2 top2bottom_unit = top2bottom.normalized;

		// Compute the orthogonal projection of the head on the screen on the horizontal plane
		// and then compute the position of the left and right according to this projection
		float right = Vector2.Dot (right2head, right2left_unit);
		float left = right - right2left.magnitude;

		// Compute the distance of the head to the screen on the horizontal plane
		float horizontalDist = Mathf.Sqrt (right2head.sqrMagnitude - Mathf.Pow (right, 2));

		// Compute the orthogonal projection of the head on the screen on the vertical plane
		// and then compute the position of the top and bottom according to this projection
		float top = Vector2.Dot (top2head, top2bottom_unit);
		float bottom = top - top2bottom.magnitude;

		// Compute the distance of the head to the screen on the vertical plane
		float verticalDist = Mathf.Sqrt (top2head.sqrMagnitude - Mathf.Pow (top, 2));

		// Adjust the position according to the near plane (the position was the position of the
		// screen corners, so modify it in order to have the position of the near plane corners)
		left = nearPlane * left / horizontalDist;
		right = nearPlane * right / horizontalDist;
		bottom = nearPlane * bottom / verticalDist;
		top = nearPlane * top / verticalDist;

		// Compute the projection matrix
		cam.projectionMatrix = PerspectiveOffCenter (left, right, bottom, top, nearPlane, farPlane);
	}

	// Compute the projection matrix from the left, right, 
	// http://www.songho.ca/opengl/gl_projectionmatrix.html
	// http://docs.unity3d.com/ScriptReference/Camera-projectionMatrix.html
	static Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far) {
		float x = 2.0F * near / (right - left);
		float y = 2.0F * near / (top - bottom);
		float a = (right + left) / (right - left);
		float b = (top + bottom) / (top - bottom);
		float c = -(far + near) / (far - near);
		float d = -(2.0F * far * near) / (far - near);
		float e = -1.0F;
		Matrix4x4 m = new Matrix4x4();
		m[0, 0] = x;
		m[0, 1] = 0;
		m[0, 2] = a;
		m[0, 3] = 0;
		m[1, 0] = 0;
		m[1, 1] = y;
		m[1, 2] = b;
		m[1, 3] = 0;
		m[2, 0] = 0;
		m[2, 1] = 0;
		m[2, 2] = c;
		m[2, 3] = d;
		m[3, 0] = 0;
		m[3, 1] = 0;
		m[3, 2] = e;
		m[3, 3] = 0;
		return m;
	}

	// Draw the frustrum in the editor
	void OnDrawGizmosSelected ()
	{
		Vector3 rightUpCorner = new Vector3 (rightDownCorner.x, leftUpCorner.y, rightDownCorner.z);

		Gizmos.color = new Color (1, 1, 1, 1);
		Gizmos.matrix = gameObject.transform.localToWorldMatrix;
		Gizmos.DrawSphere (new Vector3 (0, 0, 0), 0.01f);

		Gizmos.color = new Color (0, 1, 1, 1);
		Gizmos.DrawSphere (headPosition, 0.01f);

		Gizmos.DrawLine (leftDownCorner, leftUpCorner);
		Gizmos.DrawLine (leftUpCorner, rightUpCorner);
		Gizmos.DrawLine (rightUpCorner, rightDownCorner);
		Gizmos.DrawLine (rightDownCorner, leftDownCorner);

		Gizmos.DrawLine (headPosition, headPosition + 10 * (leftDownCorner - headPosition));
		Gizmos.DrawLine (headPosition, headPosition + 10 * (leftUpCorner - headPosition));
		Gizmos.DrawLine (headPosition, headPosition + 10 * (rightDownCorner - headPosition));
		Gizmos.DrawLine (headPosition, headPosition + 10 * (rightUpCorner - headPosition));
	}
}
