using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float DelayTime = 1;
    public float FadeTime = 1;
    private float _timer;
    private float _imageAlpha = 1;
    private Image _image;
    void Awake()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        if (_timer > DelayTime)
        {
            _imageAlpha -= Time.deltaTime / FadeTime;
            if (_imageAlpha < 0)
            {
                _imageAlpha = 0;
                gameObject.SetActive(false);
                return;
            }
            var color = _image.color;
            color.a = _imageAlpha;
            _image.color = color;
        }
        else
        {
            _timer += Time.deltaTime;
        }

    }
}
