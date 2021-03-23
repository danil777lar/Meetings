﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLegMotion : Motion
{
    private Transform _bodyPointer;
    private Rigidbody2D _bodyRb;

    private Vector3 _positionOffset = new Vector3(-0.5f, -1.5f);
    private float _timeOffset = 0.2f;

    public JumpLegMotion(Transform body) 
    {
        _bodyPointer = body;
        _bodyRb = body.GetComponent<Rigidbody2D>();
    }

    public override void UpdateMotion()
    {
        float t = Time.deltaTime / _timeOffset;
        Vector2 targetPosition = _bodyPointer.localPosition + _positionOffset;
        _pointerTransform.localPosition = Vector2.Lerp(_pointerTransform.localPosition, targetPosition, t);

        if (_bodyPointer.position.y <= BodyControllMotion.STAND_HEIGHT && _bodyRb.velocity.y < 0f)
            IsFinished = true;
    }
}