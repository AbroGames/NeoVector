using AbroDraft.Scripts.EventBus;
using Godot;
using KludgeBox;
using ServiceRegistry = AbroDraft.Scripts.Utils.ServiceRegistry;

namespace AbroDraft.Scenes.Root;

public partial class Root : Node2D
{
	
	[Export] [NotNull] public PackedScenesContainer.PackedScenesContainer PackedScenes { get; private set; }
	[Export] [NotNull] public Game.Game Game { get; private set; }
	[Export] [NotNull] public WorldEnvironment Environment { get; private set; }
	
	public ServiceRegistry ServiceRegistry { get; private set; } = new();
	
	public static Root Instance { get; private set; }

	public override void _EnterTree()
	{
		Instance = this;
	}

	public override void _Ready()
	{
		NotNullChecker.CheckProperties(this);
		ServicesInit();
	}

	//Todo вынести в другое место (автоматически через аннотации, например. Хранить сервисы тоже в другом месте, наверн)
	public void ServicesInit()
	{
		ServiceRegistry.RegisterServices();
		EventBus.RegisterListeners(ServiceRegistry);
	}
}