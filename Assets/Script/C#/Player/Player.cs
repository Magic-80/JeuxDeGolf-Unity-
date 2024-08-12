using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Script.C_.Player
{
    public class Player : MonoBehaviour
    {
        private bool _isCharging;
        private float _chargeTime;

        public PlayerData data;
        public Ball.Ball ball;
        public Slider sliderCharge;
        
        //public event Action<bool> OnCharged;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isCharging = true;
                _chargeTime = 0f;
                //OnCharged?.Invoke(true);
            }
            
            if (_isCharging)
            {
                _chargeTime += Time.deltaTime;
                float chargeAmount = _chargeTime / data.maxChargeTime;
                sliderCharge.value = chargeAmount;
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _isCharging = false; 
                //OnCharged?.Invoke(false);
                
                ball.SetVelocity(_chargeTime * data.chargeSpeed);
                StartCoroutine(LerpSliderValue(0f, 0.5f));
            }
        }
        
        
        private IEnumerator LerpSliderValue(float targetValue, float duration)
        {
            float startTime = Time.time;
            float initialValue = sliderCharge.value;

            while (Time.time - startTime < duration)
            {
                float elapsed = Time.time - startTime;
                float t = Mathf.Clamp01(elapsed / duration);

                sliderCharge.value = Mathf.Lerp(initialValue, targetValue, t);

                yield return null;
            }
            
            sliderCharge.value = targetValue;
        }
    }
}