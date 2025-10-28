using Leopotam.EcsLite;

public struct WallComponent
{
    public int Id;
    public double X1, Y1, X2, Y2;
}

public struct BallComponent
{
    public double X, Y, Radius, Vx, Vy;
    public Ball SceneObject;
}

public class EcsSceneAdapter
{
    private EcsWorld _world;
    private Scene _scene;

    public EcsSceneAdapter(EcsWorld world, Scene scene)
    {
        _world = world;
        _scene = scene;
    }

    public void SyncSceneToWorld()
    {
        var wallPool = _world.GetPool<WallComponent>();
        var ballPool = _world.GetPool<BallComponent>();

        foreach (var obj in _scene.Objects)
        {
            int entity = _world.NewEntity();
            if (obj is Wall wall)
            {
                ref var wallComp = ref wallPool.Add(entity);
                wallComp.X1 = wall.X1;
                wallComp.Y1 = wall.Y1;
                wallComp.X2 = wall.X2;
                wallComp.Y2 = wall.Y2;
                wallComp.Id = wall.Id;
            }
            else if (obj is Ball ball)
            {
                ref var ballComp = ref ballPool.Add(entity);
                ballComp.X = ball.X;
                ballComp.Y = ball.Y;
                ballComp.Radius = ball.Radius;
                ballComp.Vx = ball.Vx;
                ballComp.Vy = ball.Vy;
                ballComp.SceneObject = ball;
            }
        }
    }
}
