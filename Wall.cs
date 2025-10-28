public class Wall : SceneObject
{
    public double X1, Y1, X2, Y2;

    public Wall(int id, double x1, double y1, double x2, double y2)
    {
        Id = id;
        X1 = x1; Y1 = y1;
        X2 = x2; Y2 = y2;
    }
}
