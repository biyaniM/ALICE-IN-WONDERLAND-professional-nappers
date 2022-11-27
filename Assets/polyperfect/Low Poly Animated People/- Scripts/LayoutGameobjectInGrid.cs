using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polyperfect.People
{
    public class LayoutGameobjectInGrid : MonoBehaviour
    {
        public Vector2 scale;
        public int columns;

        [ContextMenu("Layout Grid")]
        void Start()
        {
            int index = 0;
            foreach (Transform item in transform)
            {
                int row = index / columns;
                int column = index % columns;

                Vector3 position = new Vector3(scale.x * column, 0, row * -scale.y);
                item.transform.localPosition = position;
                index++;
            }
        }
    }
}
