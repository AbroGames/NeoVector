using Godot;

public partial class MainMenuMainScene : Node2D
{

	[Export] [NotNull] public NodeContainer BackgroundContainer { get; private set; }
	[Export] [NotNull] public NodeContainer MenuContainer { get; private set; }
	[Export] [NotNull] public NodeContainer ForegroundContainer { get; private set; }
	
	public override void _Ready()
	{
		NotNullChecker.CheckProperties(this);
		Root.Instance.EventBus.Publish(new MainMenuMainSceneReadyEvent(this));
	}
}