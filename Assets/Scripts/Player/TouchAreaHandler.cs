using System;
using System.Collections;
using Lean.Touch;
using UnityEngine;

namespace Player
{
    public class TouchAreaHandler : MonoBehaviour
    {
        [SerializeField] private Camera mainCam;
        [SerializeField] private Bounds2D bounds;

        private bool _isTouched;
        private LeanFinger _currentFinger;

        public bool IsTouched => _isTouched;
        public Vector2 CurrentPosition => GetWorldPos(_currentFinger.ScreenPosition);
        public Bounds2D Bounds => bounds;
        public LeanFinger CurrentFinger => _currentFinger;


        public void StartTracking()
        {
            LeanTouch.OnFingerDown += OnFingerDown;
        }

        public void EndTracking()
        {
            LeanTouch.OnFingerDown -= OnFingerDown;
        }

        private void OnFingerDown(LeanFinger finger)
        {
            if (!bounds.IsInside(GetWorldPos(finger.ScreenPosition)) || _isTouched)
            {
                return;
            }

            _isTouched = true;
            _currentFinger = finger;
            StartCoroutine(TrackFinger(finger));
        }

        private IEnumerator TrackFinger(LeanFinger finger)
        {
            yield return new WaitUntil(() => finger.Set);

            _currentFinger = null;
            _isTouched = false;
        }

        private Vector2 GetWorldPos(Vector2 screenPos)
        {
            return mainCam.ScreenToWorldPoint(screenPos);
        }
    }
}