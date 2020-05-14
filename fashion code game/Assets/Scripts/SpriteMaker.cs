using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteMaker : MonoBehaviour
{
    private SpriteRenderer rend;

    public Texture2D[] textureArray;
    public Color[] colorArray;

    private Texture2D tex;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
        //making texture
        tex = MakeTexture(textureArray, colorArray);
        
        rend.sprite = MakeSprite(tex);;
    }

    public Texture2D MakeTexture(Texture2D[] layers, Color[] layerColors)
    {
        //create texture
        Texture2D newTexture = new Texture2D(layers[0].width, layers[0].height);
        
        Color[] colorArray = new Color[newTexture.width * newTexture.height];

        Color[][] adjustedLayers = new Color[layers.Length][];

        for (int i = 0; i < layers.Length; i++)
        {
            if (i == 0 || layers[i].width == newTexture.width && layers[i].height == newTexture.height)
            {
                adjustedLayers[i] = layers[i].GetPixels();
            }
            else
            {

                int getX, getWidth, setX, setWidth;

                getX = (layers[i].width > newTexture.width) ? (layers[i].width - newTexture.width) / 2 : 0;
                getWidth = (layers[i].width > newTexture.width) ? newTexture.width : layers[i].width;
                setX = (layers[i].width < newTexture.width) ? (newTexture.width - layers[i].width) / 2 : 0;
                setWidth = (layers[i].width < newTexture.width) ? layers[i].width : newTexture.width;
                
                int getY, getHeight, setY, setHeight;
                
                getY = (layers[i].height > newTexture.height) ? (layers[i].height - newTexture.height) / 2 : 0;
                getHeight = (layers[i].height > newTexture.height) ? newTexture.height : layers[i].height;
                setY = (layers[i].height < newTexture.height) ? (newTexture.height - layers[i].height) / 2 : 0;
                setHeight = (layers[i].height < newTexture.height) ? layers[i].height : newTexture.height;

                Color[] getPixels = layers[i].GetPixels(getX, getY, getWidth, getHeight);
                if (layers[i].width >= newTexture.width && layers[i].height >= newTexture.height)
                {
                    adjustedLayers[i] = getPixels;
                }
                else
                {
                    Texture2D sizedLayer = ClearTexture(newTexture.width, newTexture.height);
                    sizedLayer.SetPixels(setX, setY, setWidth, setHeight, getPixels);
                    adjustedLayers[i] = sizedLayer.GetPixels();
                }
                
            }
        }

        for (int i = 0; i < layerColors.Length; i++)
        {
            if (layerColors[i].a < 1)
            {
                layerColors[i] = new Color(layerColors[i].r, layerColors[i].g, layerColors[i].b, 1);
            }
        }
        
        
        for (int x = 0; x < newTexture.width; x++) {
            for (int y = 0; y < newTexture.width; y++)
            {
                int pixelIndex = x + (y * newTexture.width);
                for (int i = 0; i < layers.Length; i++)
                {
                    Color srcPixel = adjustedLayers[i][pixelIndex];
                    
                    //apply layer color
                    if (srcPixel.r != 0 && srcPixel.a != 0 && i < layerColors.Length)
                    {
                        srcPixel = ApplyColorToPixel(srcPixel, layerColors[i]);
                    }
                    
                    if (srcPixel.a == 1)
                    {
                        colorArray[pixelIndex] = srcPixel;
                    } else if (srcPixel.a > 0)
                    {
                        colorArray[pixelIndex] = NormalBlend(colorArray[pixelIndex], srcPixel);
                    }
                }
            }
        }
        newTexture.SetPixels(colorArray);
        newTexture.Apply();

        newTexture.wrapMode = TextureWrapMode.Clamp;
        //tex.filterMode = FilterMode.Point;

        return newTexture;
    }

    public Sprite MakeSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0,0 ,texture.width, texture.height), Vector2.one * 0.5f);
    }

    Color NormalBlend(Color dest, Color src)
    {
        float srcAlpha = src.a;
        float destAlpha = (1 - srcAlpha) * dest.a;
        Color destLayer = dest * destAlpha;
        Color srcLayer = src * srcAlpha;
        return destLayer + srcLayer;
    }

    Color ApplyColorToPixel(Color pixel, Color applyColor)
    {
        if (pixel.r == 1f)
        {
            return applyColor;
        }
        return pixel * applyColor;
    }

    Texture2D ClearTexture(int width, int height)
    {
        Texture2D clearTexture = new Texture2D(width, height);
        Color[] clearPixels = new Color[width * height];
        clearTexture.SetPixels(clearPixels);
        return clearTexture;
    }

}
