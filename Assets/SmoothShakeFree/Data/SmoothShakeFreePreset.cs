using UnityEngine;

namespace SmoothShakeFree
{
    [CreateAssetMenu(fileName = "SmoothShakePreset", menuName = "Smooth Shake Free/Smooth Shake Preset", order = 1)]
    public class SmoothShakeFreePreset : ScriptableObject
    {
        [Header("Time Settings")]
        [Tooltip("Settings for the shake timing")]
        public TimeSettings timeSettings;

        [Header("Position Shake Settings")]
        [Tooltip("Settings for Position Shake")]
        public Shaker positionShake = new();

        [Header("Rotation Shake Settings")]
        [Tooltip("Settings for Rotation Shake")]
        public Shaker rotationShake = new();
    }
}
