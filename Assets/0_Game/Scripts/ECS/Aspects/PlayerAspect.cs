using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct PlayerAspect : IAspect
{
    public readonly Entity entity;

    private readonly TransformAspect m_TransformAspect;

    private readonly RefRW<PlayerSpeedComponentData> m_SpeedData;
    private readonly RefRO<PlayerInputComponentData> m_PlayerInput;

    public float Speed => m_SpeedData.ValueRW.Value;
    public float2 Input => m_PlayerInput.ValueRO.Value;
    public TransformAspect TransformAspect => m_TransformAspect;

    public void Move(float deltaTime, float2 dir)
    {
        m_TransformAspect.Position += new float3(dir.x, 0f, dir.y) * m_SpeedData.ValueRO.Value * deltaTime;
    }
}
