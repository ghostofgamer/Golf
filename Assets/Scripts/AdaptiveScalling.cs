using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveScalling : MonoBehaviour
{
    public RectTransform golfField;

    public Camera mainCamera;
    public float baseOrthographicSize = 5.0f;
    public float baseScreenWidth = 1920.0f;
    public GameObject mapContainer; 
    public float baseScale = 1.0f;
    public float baseScreenHeight = 1080.0f;
    void Start()
    {
        AdaptCameraToScreenSize();
    }

    private void Update()
    {
        AdaptCameraToScreenSize();
    }

    void AdaptCameraToScreenSize()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float targetAspect = baseScreenWidth / baseScreenHeight;
        float windowAspect = (float)screenWidth / (float)screenHeight;
        float scaleHeight = windowAspect / targetAspect;

        float scaleFactor = 1.0f;

        if (scaleHeight < 1.0f)
        {
            scaleFactor = scaleHeight;
        }
        else
        {
            scaleFactor = 1.0f / scaleHeight;
        }

        mapContainer.transform.localScale = new Vector3(baseScale * scaleFactor, baseScale * scaleFactor, baseScale * scaleFactor);
        
        
        /*float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float targetAspect = 9f / 16.0f; // Целевое соотношение сторон
        float windowAspect = (float)screenWidth / (float)screenHeight;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Rect rect = mainCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            mainCamera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = mainCamera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            mainCamera.rect = rect;
        }*/
    }
    
    
    
    
    /*void Start()
    {
        AdaptToScreenSize();
    }

    private void Update()
    {
        AdaptToScreenSize();
    }
    
    void AdaptToScreenSize()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        if (screenWidth < 600)
        {
            golfField.anchorMin = new Vector2(0.05f, 0.05f);
            golfField.anchorMax = new Vector2(0.95f, 0.95f);
        }
        else if (screenWidth > 1200)
        {
            golfField.anchorMin = new Vector2(0.15f, 0.15f);
            golfField.anchorMax = new Vector2(0.85f, 0.85f);
        }
        else
        {
            golfField.anchorMin = new Vector2(0.1f, 0.1f);
            golfField.anchorMax = new Vector2(0.9f, 0.9f);
        }
    }*/
}
