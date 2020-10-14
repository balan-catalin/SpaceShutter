using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Assets.Scripts
{
    public class AutoDestroy : MonoBehaviour
    {
        public AudioSource Explosion;

        void Start()
        {
            StartCoroutine(KillOnAnimationEnd());
        }

        IEnumerator KillOnAnimationEnd()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}
