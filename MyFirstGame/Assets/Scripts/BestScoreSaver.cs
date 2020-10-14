using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BestScoreSaver : MonoBehaviour
    {
        private string _path;
        private int _bestScore = 0;
        private Text _textComponent;

        void Start()
        {
            _path = Application.dataPath + "\\BestScore.txt";

            _textComponent = gameObject.GetComponent<Text>();

            if (!File.Exists(_path))
                File.CreateText(_path);

            ReadBestScore();
        }

        void FixedUpdate()
        {
            if (int.TryParse(GameObject.FindWithTag("Score").GetComponent<Text>().text, out var score) &&
                int.TryParse(_textComponent.text, out var bestScore) && score > bestScore)
                _textComponent.text = score.ToString();
        }

        void OnDestroy()
        {
            WriteBestScore();
        }

        void ReadBestScore()
        {
            using (var sr = File.OpenText(_path))
            {
                if ((_textComponent.text = sr.ReadLine()) != null)
                {
                    int.TryParse(_textComponent.text, out _bestScore);
                }
            }
        }

        void WriteBestScore()
        {
            if (int.TryParse(_textComponent.text, out var score) && score > _bestScore)
                using (var sw = File.CreateText(_path))
                {
                    sw.WriteLine(score);
                }
        }
    }
}