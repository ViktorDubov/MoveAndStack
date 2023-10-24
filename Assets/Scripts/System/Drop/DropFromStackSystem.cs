using UnityEngine;
using Leopotam.Ecs;
using Scripts.Data;

namespace Scripts.System
{
    public class DropFromStackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent> movableComponentFilter = null;
        private readonly EcsFilter<DropComponent> dropComponentFilter = null;
        private readonly EcsFilter<StackComponent> stackComponentFilter = null;
        public void Run()
        {
            foreach (var i in movableComponentFilter)
            {
                ref var player = ref movableComponentFilter.Get1(i);
                foreach (var j in dropComponentFilter)
                {
                    ref var drop = ref dropComponentFilter.Get1(j);
                    foreach (var k in stackComponentFilter)
                    {
                        ref var stack = ref stackComponentFilter.Get1(k);
                        DoRun(ref player, ref drop, ref stack);
                    }
                }
            }
        }

        private void DoRun(ref MovableComponent player, ref DropComponent drop, ref StackComponent stack)
        {
            if (Vector3.Distance(player.transform.position, drop.dropParent.position) < drop.radius)
            {
                for (int i = 0; i < stack.thingsInStack.Count; i++)
                {
                    var thing = stack.thingsInStack[i];
                    thing.transform.parent = drop.dropParent;
                    drop.thingsInDrop.Add(thing);
                    Vector3 temp = drop.dropParent.position + 0.3f * drop.thingsInDrop.Count * Vector3.up;
                    thing.transform.position = temp;
                    thing.isDroped = true;
                }
                stack.thingsInStack.Clear();
            }
        }
    }
}

