using UnityEngine;
using Leopotam.Ecs;
using Scripts.Data;

namespace Scripts.System
{
    public class PlayerMovebleSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DirectionComponent, MovableComponent> moveFilter = null;
        public void Run()
        {
            foreach (var i in moveFilter)
            {
                ref var move = ref moveFilter.Get2(i);
                ref var dir = ref moveFilter.Get1(i);

                move.transform.Translate(dir.direction * move.speed * Time.deltaTime);
            }
        }
    }
}

