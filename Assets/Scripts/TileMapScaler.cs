using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapScaler : MonoBehaviour
{
    public Camera mainCamera;
    public float tileSize = 1.0f;

    void Start()
    {
        AdjustTileMapScale();
    }

    private void Update()
    {
        AdjustTileMapScale();
    }
    void AdjustTileMapScale()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float orthographicSize = mainCamera.orthographicSize;
        float aspectRatio = screenWidth / screenHeight;

        float cameraWidth = orthographicSize * aspectRatio;
        float cameraHeight = orthographicSize;

        float tilesWidth = cameraWidth * 2 / tileSize;
        float tilesHeight = cameraHeight * 2 / tileSize;

        // Выберите минимальное значение между tilesWidth и tilesHeight
        float tileScale = Mathf.Min(tilesWidth, tilesHeight);

        // Установите размер сетки тайлов в зависимости от разрешения экрана
        transform.localScale = new Vector3(tileScale, tileScale, 1);
    }
    /*void AdjustTileMapScale()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float orthographicSize = mainCamera.orthographicSize;
        float aspectRatio = screenWidth / screenHeight;

        float cameraWidth = orthographicSize * aspectRatio;
        float cameraHeight = orthographicSize;

        float tilesWidth = cameraWidth * 2 / tileSize;
        float tilesHeight = cameraHeight * 2 / tileSize;

        // Установите размер сетки тайлов в зависимости от разрешения экрана
        transform.localScale = new Vector3(tilesWidth, tilesHeight, 1);
    }*/
}
