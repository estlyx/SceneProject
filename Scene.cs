using System.Collections.Generic;

public class Scene
{
    public List<SceneObject> Objects = new List<SceneObject>();

    public IEnumerable<Wall> Walls => Objects.OfType<Wall>();
    public Ball Ball => Objects.OfType<Ball>().FirstOrDefault();

    public void Add(SceneObject obj) => Objects.Add(obj);
}
