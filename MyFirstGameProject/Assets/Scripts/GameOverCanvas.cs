using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameOverCanvas : MonoBehaviour
    {
        void Start()
        {
            this.gameObject.SetActive(false);
        }
    }
}
