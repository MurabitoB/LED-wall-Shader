using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDWallDemo : MonoBehaviour
{
    private float deltaTime = 0;
    public float speed = 1;
    public LEDWall ledWall;

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        switch(Mathf.Floor(deltaTime * speed % 7))
        {
            case 1 :
            ledWall.useSingleColor = false;
            ledWall.useMaskTexture = false;
            ledWall.useLuminanceDotSize = false;
            ledWall.useClip = false;
            ledWall.useFlow = false;
            ledWall.luminanceMultiply = 1;
            ledWall.speedX = 0.1f;
            ledWall.speedY = 0.1f;
            ledWall.innerCircleRadius = 0.3f;
            ledWall.outterCircleRadius = 0.6f;
            ledWall.outterCircleBlendColor = new Color(0.6037f,0.6037f,0.6037f,1f);
            ledWall.backGroundColor = new Color(0,0,0,0);
            ledWall.singleColor = new Color(0,0,0,0);
            break;
            case 2 :
            ledWall.useSingleColor = false;
            ledWall.useMaskTexture = false;
            ledWall.useLuminanceDotSize = true;
            ledWall.useClip = false;
            ledWall.useFlow = false;
            ledWall.luminanceMultiply = 1;
            ledWall.speedX = 0.1f;
            ledWall.speedY = 0.1f;
            ledWall.innerCircleRadius = 0.3f;
            ledWall.outterCircleRadius = 0.6f;
            ledWall.outterCircleBlendColor = new Color(0.6037f,0.6037f,0.6037f,1f);
            ledWall.backGroundColor = new Color(0,0,0,0);
            ledWall.singleColor = new Color(0,0,0,0);
            break;
            case 3 :
            ledWall.useSingleColor = false;
            ledWall.useMaskTexture = false;
            ledWall.useLuminanceDotSize = true;
            ledWall.useClip = true;
            ledWall.useFlow = false;
            ledWall.luminanceMultiply = 1;
            ledWall.speedX = 0.1f;
            ledWall.speedY = 0.1f;
            ledWall.innerCircleRadius = 0.3f;
            ledWall.outterCircleRadius = 0.6f;
            ledWall.outterCircleBlendColor = new Color(0.6037f,0.6037f,0.6037f,1f);
            ledWall.backGroundColor = new Color(0,0,0,0);
            ledWall.singleColor = new Color(0,0,0,0);
            break;
            case 4 :
            ledWall.useSingleColor = true;
            ledWall.useMaskTexture = false;
            ledWall.useLuminanceDotSize = true;
            ledWall.useClip = false;
            ledWall.useFlow = false;
            ledWall.luminanceMultiply = 0.5f;
            ledWall.speedX = 0.1f;
            ledWall.speedY = 0.1f;
            ledWall.innerCircleRadius = 0.3f;
            ledWall.outterCircleRadius = 0.6f;
            ledWall.outterCircleBlendColor = new Color(0.6037f,0.6037f,0.6037f,1f);
            ledWall.backGroundColor = new Color(0,0,0,0);
            ledWall.singleColor = new Color(0,0.3301887f,0.06843842f,0);
            break;
            case 5 :
            ledWall.useSingleColor = true;
            ledWall.useMaskTexture = false;
            ledWall.useLuminanceDotSize = true;
            ledWall.useClip = false;
            ledWall.useFlow = true;
            ledWall.luminanceMultiply = 0.5f;
            ledWall.speedX = 0.1f;
            ledWall.speedY = 0.1f;
            ledWall.innerCircleRadius = 0.3f;
            ledWall.outterCircleRadius = 0.6f;
            ledWall.outterCircleBlendColor = new Color(0.6037f,0.6037f,0.6037f,1f);
            ledWall.backGroundColor = new Color(0,0,0,0);
            ledWall.singleColor = new Color(0,0.3301887f,0.06843842f,0);
            break;
            case 6 :
            ledWall.useSingleColor = false;
            ledWall.useMaskTexture = true;
            ledWall.useLuminanceDotSize = false;
            ledWall.useClip = false;
            ledWall.useFlow = false;
            ledWall.luminanceMultiply = 0.5f;
            ledWall.speedX = 0.1f;
            ledWall.speedY = 0.1f;
            ledWall.innerCircleRadius = 0.3f;
            ledWall.outterCircleRadius = 0.6f;
            ledWall.outterCircleBlendColor = new Color(0.6037f,0.6037f,0.6037f,1f);
            ledWall.backGroundColor = new Color(0,0,0,0);
            ledWall.singleColor = new Color(0,0.3301887f,0.06843842f,0);
            break;
        }
    }
}
