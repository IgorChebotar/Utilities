using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class TextureUtilities
    {
        public static Texture2D GenerateTexture(Vector2Int size, Color color)
        {
            Texture2D texture = new Texture2D(size.x, size.y);
            texture.filterMode = FilterMode.Point;
            Color[] pixelColors = new Color[size.x * size.y];
            for (int i = 0; i < pixelColors.Length; i++)
            {
                pixelColors[i] = color;
            }

            texture.SetPixels(pixelColors);
            texture.Apply();
            return texture;
        }

        public static Texture2D DrawRectangle(this Texture2D context, Vector2Int center, Vector2Int extents, Color color)
        {
            if (context == null)
                throw new System.NullReferenceException("Context texture not exist");


            Color[] colors = new Color[context.width * context.height];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = color;
            }

            context.SetPixels(center.x, center.y, extents.x, extents.y, colors);
            context.Apply();

            return context;
        }
    }
}