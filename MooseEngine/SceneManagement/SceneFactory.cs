using MooseEngine.ECS.Systems;

namespace MooseEngine.SceneManagement;

public interface ISceneFactory
{
    IScene CreateScene();
}

internal sealed class SceneFactory : ISceneFactory
{
    public SceneFactory(IRenderer2DSystem renderer2DSystem)
    {
        Renderer2DSystem = renderer2DSystem;
    }

    private IRenderer2DSystem Renderer2DSystem { get; }

    public IScene CreateScene()
    {
        return new Scene(Renderer2DSystem);
    }
}
