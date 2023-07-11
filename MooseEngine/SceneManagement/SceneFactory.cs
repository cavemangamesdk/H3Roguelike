using MooseEngine.ECS.Systems;

namespace MooseEngine.SceneManagement;

public interface ISceneFactory
{
    IScene CreateScene();
}

internal sealed class SceneFactory : ISceneFactory
{
    public SceneFactory(IRenderer2DSystem renderer2DSystem, IScriptSystem scriptSystem)
    {
        Renderer2DSystem = renderer2DSystem;
        ScriptSystem = scriptSystem;
    }

    private IRenderer2DSystem Renderer2DSystem { get; }
    private IScriptSystem ScriptSystem { get; }

    public IScene CreateScene()
    {
        return new Scene(Renderer2DSystem, ScriptSystem);
    }
}
