using System;
using System.Collections;
using Lean.Touch;
using UnityEngine;

namespace Player
{
    public class TouchArea : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Bounds2D bounds;
        
        private bool _isTouched;
        private Touch _currentTouch;
        private Coroutine _currentRoutine;
        
        public bool IsTouched => _isTouched;
        public Touch CurrentTouch => _currentTouch;
        public Bounds2D Bounds => bounds;

        public void StartTracking()
        {
            if (_currentRoutine != null)
            {
                return;
            }
            _currentRoutine = StartCoroutine(TouchTracker());
        }

        public void EndTracking()
        {
            if (_currentRoutine == null)
            {
                return;
            }
            StopCoroutine(_currentRoutine);
            _currentRoutine = null;
        }
        
        private IEnumerator TouchTracker()
        {
            while (true)
            {
                var touches = Input.touches;
                for (var i = 0; i < touches.Length; i++)
                {
                    var touch = touches[i];
                    print("Phase: " + (touch.phase != TouchPhase.Began));
                    print("Bounds: " + !bounds.IsInside(GetTouchPos(touch)));
                    if (touch.phase != TouchPhase.Began || !bounds.IsInside(GetTouchPos(touch)))
                    {
                        continue;
                    }

                    _isTouched = true;
                    var fingerId = i;
                    while (IsActiveTouchState())
                    {
                        //Debug.Log($"Finger {fingerId}: Phase: {Input.touches[fingerId].phase}");
                        _currentTouch = Input.touches[fingerId];
                        yield return null;
                    } 

                    _isTouched = false;
                    //Debug.Log("Broke the cycle");
                    break;
                }
                //Debug.Log("Check finger");

                yield return null;
            }
        }


        private void Update()
        {
            if (Input.touchCount > 0) print(Input.GetTouch(0).phase);
        }

        private bool IsActiveTouchState()
        {
            return _currentTouch.phase == TouchPhase.Moved
                   || _currentTouch.phase == TouchPhase.Stationary
                   || _currentTouch.phase == TouchPhase.Began;
        }
        
        private Vector2 GetTouchPos(Touch touch)
        {
            return camera.ScreenToWorldPoint(touch.position);
        }
        
        public Vector2 GetCurrentTouchPos()
        {
            return camera.ScreenToWorldPoint(_currentTouch.position);
        }
    }
}