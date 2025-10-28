using Leopotam.EcsLite;

public class BallMoveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var ballPool = world.GetPool<BallComponent>();
        var filter = world.Filter<BallComponent>().End();

        foreach (var entity in filter)
        {
            ref var ball = ref ballPool.Get(entity);
            ball.X += ball.Vx;
            ball.Y += ball.Vy;
            
            if (ball.SceneObject != null)
            {
                ball.SceneObject.X = ball.X;
                ball.SceneObject.Y = ball.Y;
            }
        }
    }
}
