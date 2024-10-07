using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only to Determine Panels
/// </summary>
[RequireComponent(typeof(RectTransform))]
public abstract class Panel : MonoBehaviour
{
    protected RectTransform panelRecTransform;

    protected virtual void OnEnable()
    {
        this.panelRecTransform = this.GetComponent<RectTransform>();
    }
    
    
}