using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    public Texture first;
    public Texture second;

    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectOneSkin()
    {
        meshRenderer.material.SetTexture("_MainTex", first);
    }

    public void SelectTwoSkin()
    {
        meshRenderer.material.SetTexture("_MainTex", second);
    }
}
