﻿using UnityEngine;

public class ScriptScrollingBackground : MonoBehaviour
{
    private Vector3 _savedOffset;
    public GameObject Flushi;
    public float scrollSpeed;

    private void Start()
    {
        _savedOffset = Flushi.transform.position;
    }

    private void FixedUpdate()
    {
        var offset = new Vector2(Mathf.Repeat(Flushi.transform.position.x*scrollSpeed, 1),
            Mathf.Repeat(Flushi.transform.position.y*scrollSpeed, 1));
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        transform.Translate(Flushi.transform.position - _savedOffset);
        _savedOffset = Flushi.transform.position;
    }

    private void OnDisable()
    {
        renderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2());
    }
}