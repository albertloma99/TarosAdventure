using Maths;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraMatrixBaseChanger : MonoBehaviour
    {
        public Transform Camera;

        public Vector3 GetMovement()
        {
            var toMatrix = new Matrix3x3(-this.Camera.right, this.Camera.up, this.Camera.forward);
            var fromMatrix = new Matrix3x3(new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 1));
            fromMatrix = toMatrix.Inverse * fromMatrix;
            Matrix3x3 conversionMatrix = fromMatrix;
            return conversionMatrix * new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
    }
}