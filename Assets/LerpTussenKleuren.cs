using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTussenKleuren : MonoBehaviour
{
    private Color color1 = new Vector4(0.3396f, 0.2771f, 0.3128f, 0);
    private Color color2 = new Vector4(0.2872f, 0.2784f, 0.3411f, 0);
    private Color activeColor;

    Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        activeColor = Color.Lerp(color1, color2, Mathf.PingPong(Time.deltaTime, 1));
        cam.backgroundColor = activeColor;
    }


}
