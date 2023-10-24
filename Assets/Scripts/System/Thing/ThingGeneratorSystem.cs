using UnityEngine;
using Leopotam.Ecs;
using Scripts.Data;

namespace Scripts.System
{
    public class ThingGeneratorSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<ThingGeneratorComponent, GeneratorTimerComponent, ThingsHolder> generatorFilter = null;

        public void Init()
        {
            foreach (var i in generatorFilter)
            {
                ref var holder = ref generatorFilter.Get3(i);
                ref var generatorData = ref generatorFilter.Get1(i);
                holder.isCreate = new bool[generatorData.sizeX, generatorData.sizeZ];
            }
        }

        public void Run()
        {
            foreach (var i in generatorFilter)
            {
                ref var timer = ref generatorFilter.Get2(i);
                timer.currentGenerateTime -= Time.deltaTime;
                if (timer.currentGenerateTime <= 0)
                {
                    ref var generatorData = ref generatorFilter.Get1(i);
                    ref var holder = ref generatorFilter.Get3(i);
                    if (holder.things.Count >= holder.isCreate.Length)
                    {
                        break;
                    }

                    int x, z;
                    do
                    {
                        x = Random.Range(0, generatorData.sizeX);
                        z = Random.Range(0, generatorData.sizeZ);
                    } while (holder.isCreate[x, z]);

                    holder.isCreate[x, z] = true;
                    GameObject newGO = GameObject.Instantiate(generatorData.thingPrefab, generatorData.parent);
                    if(newGO.TryGetComponent<OneThing>(out OneThing thing))
                    {
                        thing.Initiate(x, z);
                        holder.things.Add(thing.data);
                    }
                    else
                    {
                        Debug.LogError("There is no OneThing in GameObject in ThingGeneratorSystem script");
                    }
                    timer.currentGenerateTime = timer.generateTime;
                }
            }
            
        }
    }
}