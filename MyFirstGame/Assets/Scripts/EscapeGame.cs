using UnityEngine;

namespace Assets.Scripts
{
    public class EscapeGame : MonoBehaviour
    {
        public GameObject GameOverScreen;
        public GameObject Explosion;

        private GameObject _player;

        void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }  

        void Update()
        {
            if (Input.GetKey(KeyCode.Escape) && _player != null)
            {
                GameOverScreen.SetActive(true);
                ExplodePlayer();
            }
        }

        private void ExplodePlayer()
        {
            GameObject exp = Instantiate(Explosion) as GameObject;
            exp.transform.position = _player.transform.position;
            Destroy(_player);
        }
    }
}
