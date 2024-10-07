using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerFollowGuide : MonoBehaviour
{
    
    
    private void Awake()
    { 
        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
}
