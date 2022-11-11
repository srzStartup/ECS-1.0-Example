using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public bool isActive = true;
    public FloatingJoystick joystick;
    public float2 Input;

    private EntityManager _em;

    private void Start()
    {
        _em = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    private void Update()
    {
        if (isActive)
        {
            joystick.SnapX = false;
            joystick.SnapY = false;

            Input = joystick.Direction;
        }
    }

    //private void Move()
    //{
    //    _floatingJoystick.SnapX = false;
    //    _floatingJoystick.SnapY = false;
    //    Vector2 input = _floatingJoystick.Direction;
    //    float angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
    //    if (angle != 0)
    //    {
    //        Quaternion rot = Quaternion.Euler(angle * Vector3.up);
    //        _transform.rotation = Quaternion.Slerp(_transform.rotation, rot, _rotSpeed * Time.deltaTime);
    //    }
    //    Vector3 dir = _transform.position - _poleTransform.position + new Vector3(input.x, 0, input.y);
    //    r = 1;
    //    float distanceSqrRoot = dir.sqrMagnitude;
    //    float rangeSqr = _range * _range;
    //    float t = Mathf.InverseLerp(0, rangeSqr, distanceSqrRoot);
    //    _ropeMaterial.color = _ropeColorGradient.Evaluate(t);
    //    _waistMaterial.color = _ropeColorGradient.Evaluate(t);
    //    if (distanceSqrRoot > rangeSqr) r = 0;
    //    _rigidbody.velocity = new Vector3(input.x, 0, input.y) * _speed * r;
    //    Vector3 desiredPos = _transform.position;
    //    _transform.position = desiredPos;
    //    float animValue = input.magnitude;
    //    _isMoving = animValue > 0f;
    //    _blend = Mathf.Lerp(animValue, _blend, .2f);
    //    if (r == 0) _blend += 1f;
    //    _animator.SetFloat("Blend", _blend);
    //}
}
