using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CanvasManager : MonoBehaviour
{
    public UVSpaceRenderer[] canvasesInUse;
    RenderTexture[] _canvasRenderTextures;
    int _currentRenderTextureIndex = 0;


    void Start()
    {
        canvasesInUse = FindObjectsOfType(typeof(UVSpaceRenderer)) as UVSpaceRenderer[];
        _canvasRenderTextures = new RenderTexture[canvasesInUse.Length * 2];
    }

    void Update()
    {
        RenderTexture canvasRenderTexture = _canvasRenderTextures[_currentRenderTextureIndex];
        int nextTextureIndex = (_currentRenderTextureIndex + 1) % _canvasRenderTextures.Length;
        CommandBuffer command = new CommandBuffer();
        command.name = "UV Space Renderer";
        
    }
}


/*
Things I learned while making this:

Particle collisions
that _foo is a used for private variables
how to use lists
just some good practice calling methods from other classes


*/