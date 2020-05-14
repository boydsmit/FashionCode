using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteMaker : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public Texture2D[] textureArray;
    public Color[] colorArray;
    

    private Texture2D _texture;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        //making texture
        _texture = MakeTexture(textureArray, colorArray);
        
        _spriteRenderer.sprite = MakeSprite(_texture);
    }

    void ChangeColor(string hexString)
    {
        var color = new Color();
        ColorUtility.TryParseHtmlString (hexString, out color);
    }

    public Texture2D MakeTexture(Texture2D[] layers, Color[] layerColors)
    {
        //create texture
        var newTexture = new Texture2D(layers[0].width, layers[0].height);
        
        var colorsArray = new Color[newTexture.width * newTexture.height];

        var adjustedLayers = new Color[layers.Length][];

        for (var i = 0; i < layers.Length; i++)
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

                var getPixels = layers[i].GetPixels(getX, getY, getWidth, getHeight);
                if (layers[i].width >= newTexture.width && layers[i].height >= newTexture.height)
                {
                    adjustedLayers[i] = getPixels;
                }
                else
                {
                    var sizedLayer = ClearTexture(newTexture.width, newTexture.height);
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
        
        for (var x = 0; x < newTexture.width; x++) {
            for (var y = 0; y < newTexture.width; y++)
            {
                var pixelIndex = x + (y * newTexture.width);
                for (var i = 0; i < layers.Length; i++)
                {
                    var srcPixel = adjustedLayers[i][pixelIndex];
                    
                    //apply layer color
                    if (srcPixel.r != 0 && srcPixel.a != 0 && i < layerColors.Length)
                    {
                        srcPixel = ApplyColorToPixel(srcPixel, layerColors[i]);
                    }
                    
                    if (srcPixel.a == 1)
                    {
                        colorsArray[pixelIndex] = srcPixel;
                    } else if (srcPixel.a > 0)
                    {
                        colorsArray[pixelIndex] = NormalBlend(colorsArray[pixelIndex], srcPixel);
                    }
                }
            }
        }
        newTexture.SetPixels(colorsArray);
        newTexture.Apply();

        newTexture.wrapMode = TextureWrapMode.Clamp;
        //tex.filterMode = FilterMode.Point;

        return newTexture;
    }

    private static Sprite MakeSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0,0 ,texture.width, texture.height), Vector2.one * 0.5f);
    }

    Color NormalBlend(Color dest, Color src)
    {
        var srcAlpha = src.a;
        var destAlpha = (1 - srcAlpha) * dest.a;
        var destLayer = dest * destAlpha;
        var srcLayer = src * srcAlpha;
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

    private static Texture2D ClearTexture(int width, int height)
    {
        var clearTexture = new Texture2D(width, height);
        var clearPixels = new Color[width * height];
        clearTexture.SetPixels(clearPixels);
        return clearTexture;
    }

}
