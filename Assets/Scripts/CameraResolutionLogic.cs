using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraResolutionLogic : MonoBehaviour
{
    [SerializeField]
    private float boundsPadding = 0.5f;
    
    private Camera _camera;
    private bool flag=true;
    
    void Start()
    {
        this._camera = this.GetComponent<Camera>();

    }

    private void Update()
    {
        if (flag)
        {
            this.UpdateCameraProjection();
            flag = false;
        }
    }

    private void UpdateCameraProjection()
    {
        var colliders = FindObjectsOfType<Collider2D>();
        Debug.Log(colliders.Length);
        if (colliders.Length == 0)
        {
            return;
        }
        
        var cameraBounds = colliders[0].bounds;

        foreach (var c in colliders)
        {
            cameraBounds.Encapsulate(c.bounds);
        }
        
        cameraBounds.Expand(this.boundsPadding);

        var verticalBound = cameraBounds.size.y;
        var horizontalBound = cameraBounds.size.x * this._camera.pixelHeight / this._camera.pixelWidth;

        var orthoSizeInBounds = Mathf.Max(verticalBound, horizontalBound);

        this._camera.transform.position = new Vector3(cameraBounds.center.x, cameraBounds.center.y, -1);
        this._camera.orthographicSize = orthoSizeInBounds * 0.5f; // orthographicSize is half-size
    }
}
