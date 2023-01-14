using System;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _characterPosition;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed;

        private void LateUpdate()
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            transform.position = Vector3.Lerp(transform.position, _characterPosition.position + _offset,
                _speed * Time.deltaTime);
        }
    }
}