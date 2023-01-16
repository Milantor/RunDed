using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAnimator
{
    public class AnimNode
    {
        public AnimNode()
        {

        }
        public Rect windowRect = new Rect(10, 10, 100, 100);
        public void OnGUI()
        {
            GUILayout.TextArea("Hello");
        }
    }
}