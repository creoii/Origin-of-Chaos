using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SpriteUtil
{
    public static Texture2D GetSprite(string path)
    {
        if (File.Exists(path))
        {
            byte[] data = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(data)) return texture;
        }
        return null;
    }

    public static void SetSprite(SpriteRenderer spriteRenderer, string path)
    {
        spriteRenderer.sprite = Resources.Load<Sprite>(path);
    }

    public static void SetSprite(Image image, string path)
    {
        image.sprite = Resources.Load<Sprite>(path);
    }
}