﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTexture : MonoBehaviour
{
    private float iX = 0;
    private float iY = 1;
    public int _uvTieX = 1;
    public int _uvTieY = 1;
    public int _fps = 10;
    private Vector2 _size;
    public Material mat;
    private int _lastIndex = -1;

    void Start()
    {
        _size = new Vector2(1.0f / _uvTieX, 1.0f / _uvTieY);

        mat.SetTextureScale("_MainTex", _size);
    }



    void Update()
    {
        int index = (int)(Time.timeSinceLevelLoad * _fps) % (_uvTieX * _uvTieY);

        if (index != _lastIndex)
        {
            Vector2 offset = new Vector2(iX * _size.x, 1 - (_size.y * iY));
            iX++;
            if (iX / _uvTieX == 1)
            {
                if (_uvTieY != 1) iY++;
                iX = 0;
                if (iY / _uvTieY == 1)
                {
                    iY = 1;
                }
            }

            mat.SetTextureOffset("_MainTex", offset);


            _lastIndex = index;
        }
    }
}
