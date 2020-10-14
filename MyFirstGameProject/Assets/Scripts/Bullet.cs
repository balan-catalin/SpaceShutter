using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        private Vector2 _screenBounds;
        private Rigidbody2D _rb;

        // Start is called before the first frame update
        void Start()
        {
            _rb = this.GetComponent<Rigidbody2D>();
            _screenBounds =
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < -_screenBounds.x || transform.position.x > _screenBounds.x ||
                transform.position.y < -_screenBounds.y || transform.position.y > _screenBounds.y)
            {
                Destroy(this.gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D colliderInfo)
        {
            if(colliderInfo.tag.ToLower() == "meteorite")
                Destroy(this.gameObject);
        }
    }
}
