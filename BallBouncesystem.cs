using Leopotam.EcsLite;
using System;

public class BallBounceSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var ballFilter = world.Filter<BallComponent>().End();
        var ballPool = world.GetPool<BallComponent>();
        var wallFilter = world.Filter<WallComponent>().End();
        var wallPool = world.GetPool<WallComponent>();

        foreach (var bEntity in ballFilter)
        {
            ref var ball = ref ballPool.Get(bEntity);

            foreach (var wEntity in wallFilter)
            {
                ref var wall = ref wallPool.Get(wEntity);

                bool bounced = false;
                // Vertical wall (X1 == X2)
                if (wall.X1 == wall.X2)
                {
                    if (Math.Abs(ball.X - wall.X1) <= ball.Radius &&
                        ball.Y >= Math.Min(wall.Y1, wall.Y2) && ball.Y <= Math.Max(wall.Y1, wall.Y2))
                    {
                        // Only if ball moves to wall
                        if ((ball.X - wall.X1) * ball.Vx < 0)
                        {
                            ball.Vx = -ball.Vx;
                            bounced = true;
                        }
                    }
                }
                // Horisontal wall (Y1 == Y2)
                else if (wall.Y1 == wall.Y2)
                {
                    if (Math.Abs(ball.Y - wall.Y1) <= ball.Radius &&
                        ball.X >= Math.Min(wall.X1, wall.X2) && ball.X <= Math.Max(wall.X1, wall.X2))
                    {
                        if ((ball.Y - wall.Y1) * ball.Vy < 0)
                        {
                            ball.Vy = -ball.Vy;
                            bounced = true;
                        }
                    }
                }

                if (bounced)
                {
                    Console.WriteLine($"Ball bounced from wall #{wall.Id}");
                    break; // 1 wall at a time
                }
            }
        }
    }
}
