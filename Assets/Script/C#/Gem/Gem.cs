using UnityEngine;
using TMPro;

namespace Script.C_.Gem
{
    public class Gem : MonoBehaviour
    {
        public TMP_Text scoreText; 

        private int _score = 0;

        private void Start()
        {
            UpdateScoreText();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                _score++;
                UpdateScoreText();
                Debug.Log(other.name);
            }
        }

        private void UpdateScoreText()
        { 
            scoreText.text = _score.ToString();
            Debug.Log(scoreText);
        }
    }
}
