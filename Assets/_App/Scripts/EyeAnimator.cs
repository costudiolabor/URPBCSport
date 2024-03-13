using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FootballAR
{
    public class EyeAnimator : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _characterRenderer;

        [SerializeField, Range(0, 3)] private float _blinkSpeed = 0.1f;
        [SerializeField, Range(1, 10)] private float _blinkInterval = 3f;

        private WaitForSeconds _blinkDelay;
        private Coroutine _blinkCoroutine;
        
        private const int LAUGTHER = 27;

        private const int EYE_BLINK_LEFT = 19; //eyeBlinkLeft
        private const int EYE_BLINK_RIGHT = 82; //eyeBlinkRight
        
        private const int EYE_LOOK_UP_LEFT = 18;
        private const int EYE_LOOK_UP_RIGHT = 81; 
        
        private const int EYE_LOOK_OUT_LEFT = 76; 
        private const int EYE_LOOK_OUT_RIGHT = 16; 
        
        private const int MAX_BLINK_VALUE = 80; 
        private const int MIN_BLINK_VALUE = 0;
        private const int HORIZONTAL_LOOK_VALUE = 60;
        private const int VERTICAL_LOOK_VALUE = 50;
        
        private const int MIN_LAUGH_VALUE = -5;
        private const int MAX_LAUGH_VALUE = 15;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _blinkDelay = new WaitForSeconds(_blinkSpeed);
            CancelInvoke();
            InvokeRepeating(nameof(AnimateEyes), 1, _blinkInterval);
        }

        private void AnimateEyes()
        {
            RotateEyes();
            Laugh();
            _blinkCoroutine = BlinkEyes().Run();
        }

        private void Laugh()
        {
            float value = Random.Range(MIN_LAUGH_VALUE, MAX_LAUGH_VALUE);
            _characterRenderer.SetBlendShapeWeight(LAUGTHER, value);
        }

        private void RotateEyes()
        {
            float vertical = Random.Range(-VERTICAL_LOOK_VALUE, VERTICAL_LOOK_VALUE);
            float horizontal = Random.Range(-HORIZONTAL_LOOK_VALUE, HORIZONTAL_LOOK_VALUE);

            _characterRenderer.SetBlendShapeWeight(EYE_LOOK_UP_LEFT, vertical);
           _characterRenderer.SetBlendShapeWeight(EYE_LOOK_UP_RIGHT, vertical);
            _characterRenderer.SetBlendShapeWeight(EYE_LOOK_OUT_LEFT, -horizontal);
            _characterRenderer.SetBlendShapeWeight(EYE_LOOK_OUT_RIGHT, horizontal);
        }

        private IEnumerator BlinkEyes()
        {
            _characterRenderer.SetBlendShapeWeight(EYE_BLINK_LEFT, MAX_BLINK_VALUE);
            _characterRenderer.SetBlendShapeWeight(EYE_BLINK_RIGHT, MAX_BLINK_VALUE);
            
            yield return _blinkDelay;
            
            _characterRenderer.SetBlendShapeWeight(EYE_BLINK_LEFT, MIN_BLINK_VALUE);
            _characterRenderer.SetBlendShapeWeight(EYE_BLINK_RIGHT, MIN_BLINK_VALUE);
        }
    }
}