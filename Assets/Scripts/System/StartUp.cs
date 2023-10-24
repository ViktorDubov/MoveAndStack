using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Scripts.System
{
    public class StartUp : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;

        private void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);

            systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            systems.Init();
        }

        private void Update()
        {
            systems.Run();
        }

        private void AddInjections()
        {

        }

        private void AddSystems()
        {
            systems.
                Add(new PlayerInputSystem()).
                Add(new PlayerMovebleSystem()).
                Add(new ThingGeneratorSystem()).
                Add(new PutToStackSystem()).
                Add(new DropFromStackSystem());
        }

        private void AddOneFrames()
        {

        }

        private void OnDestroy()
        {
            if (systems == null) return;

            systems.Destroy();
            systems = null;
            world.Destroy();
            world = null;
        }
    }
}

