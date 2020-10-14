using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SchipCollision : MonoBehaviour
    {
        public GameObject HeartPrefab;
        public GameObject ExplosionPrefab;
        public GameObject GameOverScreen;
        public int Lives = 3;

        private readonly Stack<GameObject> _hearts = new Stack<GameObject>();
        private Vector2 _screenBounds;
        private const int Corner = 30;

        void Start()
        {
            _screenBounds =
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                    Camera.main.transform.position.z));

            for (int i = 1; i <= Lives; i++)
            {
                GameObject heart = Instantiate(HeartPrefab) as GameObject;
                heart.transform.position = new Vector3(_screenBounds.x - i * Corner, _screenBounds.y - Corner);
                _hearts.Push(heart);
            }
        }

        void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (collisionInfo.collider.tag == "Meteorite")
            {
                Destroy(collisionInfo.gameObject);
                Destroy(_hearts.Pop());
                Lives--;

                if (Lives <= 0)
                {
                    GameObject exp = Instantiate(ExplosionPrefab) as GameObject;
                    exp.transform.position = gameObject.transform.position;
                    Destroy(this.gameObject);
                    GameOverScreen.SetActive(true);
                }
            }
        }
    }
}