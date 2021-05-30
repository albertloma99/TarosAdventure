using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class Orbit : MonoBehaviour {
 
   [SerializeField]
        public Transform player;

        [SerializeField]
        private float distance = 5f;

        [SerializeField]
        private float rotationSpeed = 300f;

        [SerializeField]
        private float minVerticalAngle = 15f, maxVerticalAngle = 45f;

        private Vector3 focusPoint;

        private Vector2 orbitAngles = new Vector2(45f, 0f);
        
        private CameraMatrixBaseChanger baseChanger;

        private bool m_CursorLocked = true;

        public LayerMask collision;

        private void OnValidate () {
            if (this.maxVerticalAngle < this.minVerticalAngle) {
                this.maxVerticalAngle = this.minVerticalAngle;
            }
        }

        private void Awake ()
        {
            this.baseChanger = this.player.gameObject.GetComponent<CameraMatrixBaseChanger>();
            this.baseChanger.Camera = this.transform;
            this.focusPoint = this.player.position;
            this.transform.localRotation = Quaternion.Euler(this.orbitAngles);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            m_CursorLocked = true;
        }

        private void LateUpdate ()
        {
            this.focusPoint = this.player.position;
            Quaternion lookRotation;
            if (ManualRotation()) {
                ConstrainAngles();
                lookRotation = Quaternion.Euler(this.orbitAngles);
            }
            else {
                lookRotation = this.transform.localRotation;
            }

            Vector3 lookDirection = lookRotation * Vector3.forward;
            Vector3 lookPosition = this.focusPoint - lookDirection * this.distance;
            
            if (Physics.Raycast(this.focusPoint, -lookDirection, out RaycastHit hit, this.distance, collision)) {
                lookPosition = this.focusPoint - lookDirection * hit.distance;
            }

            this.transform.SetPositionAndRotation(lookPosition, lookRotation);
        }
        

        private bool ManualRotation () {
            var input = new Vector2(
                -Input.GetAxis("Mouse Y"),
                Input.GetAxis("Mouse X")
            );
            const float e = 0.001f;
            //Es para que sea fluidete 
            if (!(input.x < -e) && !(input.x > e) && !(input.y < -e) && !(input.y > e)) return false;
            
            this.orbitAngles += this.rotationSpeed * Time.deltaTime * input;
            return true;
        }
        

        private void ConstrainAngles () {
            this.orbitAngles.x =
                Mathf.Clamp(this.orbitAngles.x, this.minVerticalAngle, this.maxVerticalAngle);

            if (this.orbitAngles.y < 0f) {
                this.orbitAngles.y += 360f;
            }
            else if (this.orbitAngles.y >= 360f) {
                this.orbitAngles.y -= 360f;
            }
        }
}
