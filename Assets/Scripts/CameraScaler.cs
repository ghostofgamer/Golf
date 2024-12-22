using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public Camera mainCamera;
    public float targetAspect = 9.0f / 16.0f; // Целевое соотношение сторон

    void Start()
    {
        AdjustCamera();
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    void AdjustCamera()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Rect rect = mainCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.center = new Vector2(0.5f, 0.5f);

            mainCamera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = mainCamera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.center = new Vector2(0.5f, 0.5f);

            mainCamera.rect = rect;
        }
    }
}
