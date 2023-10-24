using UnityEngine;
using Leopotam.Ecs;
using Scripts.Data;

namespace Scripts.System
{
    public class PutToStackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent> movableComponentFilter = null;
        private readonly EcsFilter<ThingsHolder> thingsHolderFilter = null;
        private readonly EcsFilter<StackComponent> stackComponentFilter = null;

        public void Run()
        {
            foreach (var i in movableComponentFilter)
            {
                ref var player = ref movableComponentFilter.Get1(i);
                foreach (var j in thingsHolderFilter)
                {
                    ref var holder = ref thingsHolderFilter.Get1(j);
                    foreach (var k in stackComponentFilter)
                    {
                        ref var stack = ref stackComponentFilter.Get1(k);
                        DoRun(ref player, ref holder, ref stack);
                    }
                }
            }
        }

        private void DoRun(ref MovableComponent player, ref ThingsHolder holder, ref StackComponent stack)
        {
            float powRadius = stack.radius * stack.radius;
            Vector3 playerPosition = player.transform.position;
            int count = holder.things.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                var thing = holder.things[i];
                if (!thing.isDroped && Mathf.Pow(thing.x - playerPosition.x, 2) + Mathf.Pow(thing.z - playerPosition.z, 2) < powRadius)
                {
                    if (stack.thingsInStack.Count < stack.maxCount)
                    {
                        stack.thingsInStack.Add(thing);
                        thing.transform.parent = stack.stackParent;
                        thing.transform.position = stack.stackParent.position + stack.thingsInStack.Count * 0.3f * Vector3.up + 2f * Vector3.up;

                        holder.isCreate[thing.x, thing.z] = false;
                        holder.things.Remove(thing);
                    }
                }
            }
        }
    }
}

