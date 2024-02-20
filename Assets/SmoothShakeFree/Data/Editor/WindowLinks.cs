using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SmoothShakeFree
{
    internal class WindowLinks : Editor
    {
        [MenuItem("Window/SmoothShakeFree/Pro version")]
        public static void ProLink()
        {
            Application.OpenURL("https://prf.hn/l/gxqwDbq");
        }

        [MenuItem("Window/SmoothShakeFree/Showcase and Tutorial")]
        public static void TutorialLink()
        {
            Application.OpenURL("https://youtu.be/SFpfRgB9yh0?si=8H1EVeIFZ1tNjTdt");
        }
    }
}
