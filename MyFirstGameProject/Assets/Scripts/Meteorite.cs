using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Meteorite : MonoBehaviour
    {
        public GameObject ExplosionPrefab;
        public int Lives { get; set; }

        private Vector2 _screenBounds;
        private const float CornerSize = 100;

        void Start()
        {
            SetLives();

            _screenBounds =
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                    Camera.main.transform.position.z));
            _screenBounds.x += CornerSize;
            _screenBounds.y += CornerSize;
        }

        void Update()
        {
            if (transform.position.x < -_screenBounds.x || transform.position.x > _screenBounds.x ||
                transform.position.y < -_screenBounds.y || transform.position.y > _screenBounds.y)
            {
                Destroy(this.gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D collisionInfo)
        {
            if (collisionInfo.transform.tag.ToLower() == "bullet")
            {
                Lives--;
                if (Lives <= 0)
                {
                    ExplodeMeteorite();
                    ChangeScore();
                }
            }
        }

        void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (collisionInfo.transform.tag.ToLower() == "player")
                ExplodeMeteorite();
        }

        private void ExplodeMeteorite()
        {
            GameObject exp = Instantiate(ExplosionPrefab) as GameObject;
            exp.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }

        private void ChangeScore()
        {
            try
            {
                Text Score = GameObject.FindWithTag("Score").GetComponent<Text>();
                Score.text = Int32.TryParse(Score.text, out var score)
                    ? (score + gameObject.transform.localScale.x).ToString()
                    : "Error";
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e.ToString());
            }
        }

        private void SetLives()
        {
            switch (transform.localScale.x)
            {
                case 10:
                    Lives = 1;
                    break;
                case 15:
                    Lives = 2;
                    break;
                case 20:
                    Lives = 3;
                    break;
            }
        }
    }
}