﻿using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    public AnimationCurve m_MagnitudeCurve;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ShakeOnce(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            Vector3 position = Random.insideUnitSphere * (magnitude * m_MagnitudeCurve.Evaluate(elapsedTime / duration)) * Time.deltaTime;
            transform.position = originalPosition + position;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}