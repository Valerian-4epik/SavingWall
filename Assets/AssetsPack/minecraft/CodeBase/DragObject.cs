using System;
using UnityEngine;

namespace CodeBase {
    public class DragObject : MonoBehaviour {
        private Rigidbody _rigidbody;
        private Camera _camera;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main;
        }

        private void OnMouseDrag() {
            float distanceToScreen = _camera.WorldToScreenPoint(gameObject.transform.position).z;
            _rigidbody.isKinematic = false;
            transform.position =
                _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                    distanceToScreen));
        }

        private void OnMouseUpAsButton() {
            _rigidbody.isKinematic = true;
        }
    }
}