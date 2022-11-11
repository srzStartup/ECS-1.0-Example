using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gif : MonoBehaviour
{
    [Tooltip(" Gif adýmlarýnýn spritelarý ")]
    public Sprite[] gifSteps;
    [Tooltip(" Her bir adýmýn görünme süresi ")]
    public float stepTime = .1f;
    private bool inCanvas;
    SpriteRenderer? sprite2d;
    Image? spriteCanvas;
    private float _timer = 0;
    private int step = 0;
    void Start()
    {
        if (TryGetComponent<SpriteRenderer>(out sprite2d))
        {
            inCanvas = false;
            sprite2d.sprite = gifSteps[0];
            step++;
        }
        else if (TryGetComponent<Image>(out spriteCanvas))
        {
            inCanvas = true;
            spriteCanvas.sprite = gifSteps[0];
            step++;
        }
        else
        {
            throw new System.Exception("Sprite için component bulunamadý");
        }
    }

    void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        Debug.Log(_timer + "   " + stepTime);
        if (_timer > stepTime)
        {
            if (inCanvas)
                spriteCanvas.sprite = spriteCanvas == null ? null : gifSteps[step];
            else
                sprite2d.sprite = sprite2d == null ? null : gifSteps[step];
            step++;
            step = step == gifSteps.Length ? 0 : step;
            _timer = 0;
        }

    }
}
