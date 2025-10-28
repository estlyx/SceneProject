using System;
using Leopotam.EcsLite;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // 1. System init
        var scene = new Scene();
        // Add 4 walls (box 0,0 - 10,0 - 10,10 - 0,10)
        scene.Add(new Wall(1, 0, 0, 10, 0));
        scene.Add(new Wall(2, 10, 0, 10, 10));
        scene.Add(new Wall(3, 10, 10, 0, 10));
        scene.Add(new Wall(4, 0, 10, 0, 0));
        // Add 1 ball
        scene.Add(new Ball(5, 5, 5, 0.5, 0.2, 0.1));

        // 2. ECS world
        var world = new EcsWorld();
        var systems = new EcsSystems(world);

        // 3. SceneAdapter <-> ECS
        var adapter = new EcsSceneAdapter(world, scene);
        adapter.SyncSceneToWorld();

        // 4. add systems
        systems
            .Add(new BallMoveSystem())
            .Add(new BallBounceSystem());

        systems.Init();

        // 5. main cycle
        for (int step = 0; step < 100; step++)
        {
            systems.Run();

            // Print ball position
            var ball = scene.Ball;
            Console.WriteLine($"Step {step}: Ball at ({ball.X:F2}, {ball.Y:F2})");
            Thread.Sleep(100); // slow down a bit
        }

        systems.Destroy();
        world.Destroy();
    }
}
