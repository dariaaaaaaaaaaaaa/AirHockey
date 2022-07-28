using System.Collections;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerMain : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private GameObject player;
        [SerializeField] private TouchAreaHandler touchArea;
        [SerializeField] private float hitForce = 6;
        [SerializeField] private float hitBallTimeOffset = 0.1f;
        
        private float _lastHitTime;

        private void Start()
        {
            touchArea.StartTracking();
        }
        
        void Update()
        {
            if (touchArea.IsTouched)
            {
                var mousePos = touchArea.CurrentPosition;

                mousePos = touchArea.Bounds.Clamp(mousePos);
                player.gameObject.transform.position = mousePos;
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider && other.collider.CompareTag("Ball") && _lastHitTime + hitBallTimeOffset < Time.time )
            {
                var ballRB = other.collider.GetComponent<Rigidbody2D>();
                var direction = ballRB.position - player.GetComponent<Rigidbody2D>().position;
                direction.Normalize();
                ballRB.AddForce(direction * touchArea.CurrentFinger.ScaledDelta * hitForce); //* touchArea.CurrentTouch.deltaPosition.magnitude
                _lastHitTime = Time.time;
            }
        }
        
    }
}