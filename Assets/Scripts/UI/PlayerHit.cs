using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : Panel
{
    [SerializeField] private Image bgImage;
    [SerializeField][Range(0F,1F)] private float alpha;
    private Color bgColor;
    private void Awake()
    {
        this.bgColor=   bgImage.color;
    }

    public void Onhit()
    {
        this.gameObject.SetActive(true);
        Color updateColor = new Color(bgColor.r, bgColor.g, bgColor.b,alpha);
        DOVirtual.Color(this.bgColor,updateColor,.1F ,(x) =>
        {
            bgImage.color = x;
        }).OnComplete(() =>
        {
            bgImage.color = bgColor;
            this.gameObject.SetActive(false);
        });
        
    }
}
