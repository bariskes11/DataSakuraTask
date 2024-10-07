using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : Panel
{
    [SerializeField] private Image bgImage;
    private Color bgColor;
    private void Awake()
    {
        this.bgColor=   bgImage.color;
    }

    public void Onhit()
    {
        this.gameObject.SetActive(true);
        Color updateColor = new Color(bgColor.r, bgColor.g, bgColor.b,90F);
        bgImage.DOColor(updateColor, .1F).OnComplete(() =>
        {
            bgImage.color = bgColor;
            this.gameObject.SetActive(false);
        });
    }
}
