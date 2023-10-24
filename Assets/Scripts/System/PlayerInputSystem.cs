using Leopotam.Ecs;
using Scripts.Input;
using Scripts.Data;

namespace Scripts.System
{
    public class PlayerInputSystem : IEcsRunSystem
    {

        private readonly EcsFilter<DirectionComponent> directionFilter = null;

        float moveX;
        float moveZ;

        public void Run()
        {
            GetDirection();

            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get1(i);
                ref var direction = ref directionComponent.direction;

                direction.x = moveX;
                direction.z = moveZ;
            }
        }

        private void GetDirection()
        {
            moveX = InputHelper.Instance.Direction.x;
            moveZ = InputHelper.Instance.Direction.y;
        }
    }
}

