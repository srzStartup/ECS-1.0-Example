using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct PlayerMovementSystem : ISystem
{

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PlayerTag>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        float2 input = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        foreach (PlayerAspect playerAspect in SystemAPI.Query<PlayerAspect>().WithAll<PlayerTag>())
        {
            playerAspect.Move(deltaTime, input);
        }

        //foreach (DynamicBuffer<Child> childrenBuffer in SystemAPI.Query<DynamicBuffer<Child>>().WithAll<PlayerTag>())
        //{
        //    Debug.Log(childrenBuffer.Length);
        //}
    }

}
