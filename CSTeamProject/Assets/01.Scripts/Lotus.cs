using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isSinking;
    private float sinkingSpeed = 0.6f;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            isSinking = true;

            Invoke("Sink", 3f);
        }
    }

    private void Sink()
    {
        LeanTween.moveY(gameObject, originalPosition.y - 1f, sinkingSpeed);
            Invoke("Rise", 5f);
    }

    private void Rise()
    {
        LeanTween.moveY(gameObject, originalPosition.y, sinkingSpeed)
            .setOnComplete(ResetSinking);
    }

    private void ResetSinking()
    {
        isSinking = false;
    }

    private void Update()
    {
        if (isSinking)
        {
            // 가라앉는 동안 애니메이션 추가할 자리(할거면)
        }
    }
}


