using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class GenerateMeteorits : MonoBehaviour
    {
        public GameObject MeteoritePrefab;
        public float RespawnTime = 0.5f;
        private Vector2 _screenBounds;
        private readonly float cornerSize = 50;

        void Start()
        {
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            _screenBounds.x += cornerSize;
            _screenBounds.y += cornerSize;
            StartCoroutine(AsteroidWave());
        }

        private void SpawnAsteroid()
        {
            GameObject ast = Instantiate(MeteoritePrefab) as GameObject;
            int random = RandomSize();
            Vector3 asteroidScale = new Vector3(random, random, random);

            switch (Random.Range(0, 4))
            {
                case 0:
                    ast.transform.position = new Vector2(-_screenBounds.x, Random.Range(-_screenBounds.y, _screenBounds.y)); //Left
                    ast.transform.localScale = asteroidScale;
                    break;
                case 1:
                    ast.transform.position = new Vector2(Random.Range(-_screenBounds.x, _screenBounds.x), _screenBounds.y); //Top
                    ast.transform.localScale = asteroidScale;
                    break;
                case 2:
                    ast.transform.position = new Vector2(_screenBounds.x, Random.Range(-_screenBounds.y, _screenBounds.y)); //Right
                    ast.transform.localScale = asteroidScale;
                    break;
                case 3:
                    ast.transform.position = new Vector2(Random.Range(-_screenBounds.x, _screenBounds.x), -_screenBounds.y); //Down
                    ast.transform.localScale = asteroidScale;
                    break;
            }
        }

        private int RandomSize()
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    //transform.tag = "Level 1";
                    return 10;
                case 1:
                    //transform.tag = "Level 2";
                    return 15;
                case 2:
                    //transform.tag = "Level 3";
                    return 20;
                default:
                    //transform.tag = "Level 1";
                    return 10;
            }
        }

        IEnumerator AsteroidWave()
        {
            while (true)
            {
                yield return new WaitForSeconds(RespawnTime);
                SpawnAsteroid();
            }
        }
    }
}
