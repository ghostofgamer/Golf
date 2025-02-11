using System;
using UnityEngine;

namespace BallContent
{
    public class BallInput : MonoBehaviour
    {
        public event Action<Vector3> MouseDownClicked;
        
        public event Action <Vector3>MouseDragged;
        
        public event Action MouseUpClicked;
        
        private void OnMouseDown()
        {
            MouseDownClicked?.Invoke(Input.mousePosition);
        }

        private void OnMouseDrag()
        {
            MouseDragged?.Invoke(Input.mousePosition);
        }

        private void OnMouseUp()
        {
            MouseUpClicked?.Invoke();
        }
    }
}