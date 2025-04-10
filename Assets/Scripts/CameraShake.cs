using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1.0f;
    [SerializeField] float shakeMagnitue = 0.5f;

    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {

            {
                transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitue;
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();

            }
            transform.position = initialPosition;



        }

    }
    
}
