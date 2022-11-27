using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

#if UNITY_EDITOR

namespace Polyperfect.People
{
    public class AtlasGenerator : MonoBehaviour
    {
        public Texture2D texture2D;
        public int textureSize = 256;
        public Color[] colors = new Color[]
        {
        new Color32(70, 44, 61, 255),
        new Color32(94, 54, 62, 255),
        new Color32(122, 68, 75, 255),
        new Color32(159, 92, 85, 255),
        new Color32(189, 122, 90, 255),
        new Color32(238, 167, 112, 255),
        new Color32(242, 204, 167, 255),
        new Color32(202, 48, 56, 100),

        new Color32(77, 59, 43, 255),
        new Color32(103, 73, 45, 255),
        new Color32(136, 91, 57, 255),
        new Color32(168, 120, 62, 255),
        new Color32(205, 155, 96, 255),
        new Color32(220, 191, 154, 255),
        new Color32(242, 224, 207, 255),
        new Color32(136, 91, 57, 100),

        new Color32(41, 41, 41, 255),
        new Color32(63, 60, 60, 255),
        new Color32(94, 90, 90, 255),
        new Color32(135, 130, 130, 255),
        new Color32(167, 161, 158, 255),
        new Color32(193, 188, 185, 255),
        new Color32(219, 229, 218, 255),
        new Color32(135, 130, 130, 100),

        new Color32(133, 41, 41, 255),
        new Color32(202, 48, 56, 255),
        new Color32(228, 73, 53, 255),
        new Color32(252, 125, 32, 255),
        new Color32(250, 166, 45, 255),
        new Color32(253, 207, 36, 255),
        new Color32(255, 230, 112, 255),
        new Color32(252, 125, 32, 100),

        new Color32(18, 37, 25, 255),
        new Color32(36, 70, 46, 255),
        new Color32(48, 113, 53, 255),
        new Color32(80, 142, 52, 255),
        new Color32(114, 169, 61, 255),
        new Color32(183, 221, 73, 255),
        new Color32(226, 245, 66, 255),
        new Color32(80, 142, 52, 100),

        new Color32(34, 41, 62, 255),
        new Color32(56, 72, 120, 255),
        new Color32(61, 121, 167, 255),
        new Color32(53, 204, 221, 255),
        new Color32(142, 235, 240, 255),
        new Color32(183, 240, 242, 255),
        new Color32(228, 254, 255, 255),
        new Color32(53, 204, 221, 100),

        new Color32(57, 48, 74, 255),
        new Color32(86, 65, 99, 255),
        new Color32(141, 73, 140, 255),
        new Color32(204, 97, 148, 255),
        new Color32(253, 175, 182, 255),
        new Color32(53, 204, 221, 255),
        new Color32(91, 63, 163, 255),
        new Color32(255, 255, 255, 100),

        new Color32(0, 0, 0, 255),
        new Color32(255, 255, 255, 255),
        new Color32(255, 255, 255, 255),
        new Color32(202, 48, 56, 255),
        new Color32(250, 166, 45, 255),
        new Color32(253, 207, 36, 255),
        new Color32(183, 211, 72, 255),
        new Color32(22, 37, 45, 255),




        };

        [ContextMenu("Create Atlas")]
        public void MakeTexture()
        {
            texture2D = new Texture2D(textureSize, textureSize);

            for (int y = 0; y < textureSize; y++)
            {
                for (int x = 0; x < textureSize; x++)
                {
                    texture2D.SetPixel(x, y, SetColor(x, y));
                }
            }

            texture2D = FlipTexture(texture2D, true);

            texture2D.Apply();
            SaveTextureAsPNG(texture2D, Path.Combine(Application.dataPath, "Test.png"));
        }

        Color SetColor(int x, int y)
        {
            var cellsPerRow = 8;
            var cellWidth = textureSize / cellsPerRow;
            var x_index = Mathf.Floor(x / cellWidth);
            var y_index = Mathf.Floor(y / cellWidth);
            var index = (int)(x_index + cellsPerRow * y_index);

            if (index >= colors.Length)
            {
                return Color.white;
            }

            return colors[index];
        }

        //https://stackoverflow.com/questions/35950660/unity-180-rotation-for-a-texture2d-or-maybe-flip-both
        Texture2D FlipTexture(Texture2D original, bool upSideDown = true)
        {
            Texture2D flipped = new Texture2D(original.width, original.height);

            int xN = original.width;
            int yN = original.height;

            for (int i = 0; i < xN; i++)
            {
                for (int j = 0; j < yN; j++)
                {
                    if (upSideDown)
                    {
                        flipped.SetPixel(j, xN - i - 1, original.GetPixel(j, i));
                    }
                    else
                    {
                        flipped.SetPixel(xN - i - 1, j, original.GetPixel(i, j));
                    }
                }
            }
            flipped.Apply();

            return flipped;
        }

        public static void SaveTextureAsPNG(Texture2D _texture, string _fullPath)
        {
            byte[] _bytes = _texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(_fullPath, _bytes);
            AssetDatabase.Refresh();
        }
    }
}
#endif
