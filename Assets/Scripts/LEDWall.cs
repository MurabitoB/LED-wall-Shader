using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDWall : MonoBehaviour {
    public Camera liveCamera;
    public bool useMaskTexture, useLuminanceDotSize, useClip, useFlow,useSingleColor;
    public float luminanceMultiply = 1;
    public float speedX = 0.1f;
    public float speedY = 0.1f;

    public float clipThreshold = 0.01f;
    [Range (0, 0.7072f)]
    public float innerCircleRadius = 0.5f;
    [Range (0, 0.7072f)]
    public float outterCircleRadius = 0.6f;
    public Color outterCircleBlendColor = new Color ();
    public Color backGroundColor = new Color ();
    public Color singleColor = new Color();

    public Texture2D maskTexture;
    public FilterMode renderTextureFilterMode = FilterMode.Point;
    private RenderTexture _texture;
    private Renderer _r;
    [Range (1, 4096)]
    public int width = 1;
    [Range (1, 4096)]

    public int height = 1;

    void Awake () {
        _texture = new RenderTexture (width, height, 0, RenderTextureFormat.ARGB32);
        _texture.filterMode = renderTextureFilterMode;
        _texture.Create ();

        _r = GetComponent<Renderer> ();

        liveCamera.targetTexture = _texture;
    }

    void Update () {
        if (useMaskTexture) {
            _r.material.EnableKeyword ("USE_MASK");
            _r.material.SetTexture ("_MaskTex", maskTexture);
        } else {
            _r.material.DisableKeyword ("USE_MASK");
            _r.material.SetFloat ("_InnerCircleRange", innerCircleRadius);
            _r.material.SetFloat ("_OutterCircleRange", outterCircleRadius);
            _r.material.SetColor ("_OutterCircleBlendColor", outterCircleBlendColor);
            _r.material.SetColor ("_BackGroundColor", backGroundColor);
        }
        if (useLuminanceDotSize) {
            _r.material.EnableKeyword ("USE_LUMINANCEDOTSIZE");
            _r.material.SetFloat ("_LuminanceMultiply", luminanceMultiply);
        } else {
            _r.material.DisableKeyword ("USE_LUMINANCEDOTSIZE");
        }
        if (useClip) {
            _r.material.EnableKeyword ("USE_CLIPBACKGROUND");
            _r.material.SetFloat ("_ClipThreshold", 0.2f);
        } else {
            _r.material.DisableKeyword ("USE_CLIPBACKGROUND");
        }
        if (useFlow) {
            _r.material.EnableKeyword ("USE_FLOW");
            _r.material.SetFloat ("_Speedx", speedX);
            _r.material.SetFloat ("_Speedy", speedY);
        } else {
            _r.material.DisableKeyword ("USE_FLOW");
        }
        if(useSingleColor)
        {
            _r.material.EnableKeyword("USE_SINGLECOLOR");
            _r.material.SetColor("_SingleColor",singleColor);
        }
        else{
            _r.material.DisableKeyword("USE_SINGLECOLOR");
        }
        _r.material.mainTexture = _texture;
    }
}