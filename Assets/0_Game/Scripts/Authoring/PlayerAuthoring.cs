using Unity.Entities;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    public float speed;
}

public class PlayerBaker : Baker<PlayerAuthoring>
{
    public override void Bake(PlayerAuthoring authoring)
    {
        AddComponent(new PlayerSpeedComponentData
        {
            Value = authoring.speed,
        });

        AddComponent(new PlayerInputComponentData { Value = Unity.Mathematics.float2.zero });
        AddComponent(new PlayerTag());
    }
}
