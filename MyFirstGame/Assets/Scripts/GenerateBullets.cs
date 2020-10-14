using UnityEngine;

namespace Assets.Scripts
{
    public class GenerateBullets : MonoBehaviour
    {
        public GameObject BulletPrefab;
        public GameObject Player;
        public float BulletSpeed = 300f;
        public float TriggerSpeed = 3f;

        private float _nextBullet = 0f;
        private Vector2 _direction;

        void FixedUpdate()
        {
            if (Time.time > _nextBullet && Input.GetKey(KeyCode.Mouse0) && Player != null)
            {
                GameObject bullet = InstantiateBullet();
                mouseDirection();
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(_direction.x * BulletSpeed, _direction.y * BulletSpeed);
                _nextBullet = Time.time + 1 / TriggerSpeed;
            }
        }

        private GameObject InstantiateBullet()
        {
            GameObject bullet = Instantiate(BulletPrefab) as GameObject;
            bullet.transform.position = Player.transform.position;
            bullet.transform.rotation = Player.transform.rotation;
            return bullet;
        }

        private void mouseDirection()
        {
            Vector3 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _direction = (mouseDirection - Player.transform.position).normalized;
        }
    }
}
