public class Ball : SceneObject
{
    public double X, Y;        // centre
    public double Radius;
    public double Vx, Vy;      // speed

    public Ball(int id, double x, double y, double radius, double vx, double vy)
    {
        Id = id;
        X = x; Y = y;
        Radius = radius;
        Vx = vx; Vy = vy;
    }
}
