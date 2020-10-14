using UnityEngine;

namespace Assets.Scripts
{
    public class ShipMovement : MonoBehaviour
    {
        public int Speed;

        private Rigidbody2D _rb;
        private Vector2 _screenBounds;
        private Vector2 _direction;

        private void Start()
        {
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        }

        private void Update()
        {
            ConstrainToScreenBounds();
        }

        private void FixedUpdate()
        {
            RotateAfterMouse();

            GetMouseDirection();

            HorizontalMove();

            VerticalMove();

            Stop();
        }

        private void ConstrainToScreenBounds()
        {
            if (transform.position.x > _screenBounds.x)
            {
                transform.position = new Vector2(_screenBounds.x, transform.position.y);
            }
            if (transform.position.x < -_screenBounds.x)
            {
                transform.position = new Vector2(-_screenBounds.x, transform.position.y);
            }
            if (transform.position.y > _screenBounds.y)
            {
                transform.position = new Vector2(transform.position.x, _screenBounds.y);
            }
            if (transform.position.y < -_screenBounds.y)
            {
                transform.position = new Vector2(transform.position.x, -_screenBounds.y);
            }
        }

        private void Stop()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _rb.velocity = new Vector2(_rb.velocity.x * 0.7f, _rb.velocity.y * 0.7f);
            }
        }

        private void VerticalMove()
        {
            switch (Input.GetAxisRaw("Vertical"))
            {
                case 1:
                    _rb.AddForce(new Vector2(_direction.x * Speed, _direction.y * Speed));
                    break;
                case -1:
                    _rb.AddForce(new Vector2(_direction.x * -Speed, _direction.y * -Speed));
                    break;
            }
        }

        private void HorizontalMove()
        {
            switch (Input.GetAxisRaw("Horizontal"))
            {
                case 1:
                    _rb.AddForce(new Vector2(_direction.y * Speed, _direction.x * -Speed));
                    break;
                case -1:
                    _rb.AddForce(new Vector2(_direction.y * -Speed, _direction.x * Speed));
                    break;
            }
        }

        private void GetMouseDirection()
        {
            Vector3 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _direction = (mouseDirection - transform.position).normalized;
        }

        private void RotateAfterMouse()
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
