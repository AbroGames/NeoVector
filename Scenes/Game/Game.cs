using System.Linq;
using Godot;
using KludgeBox;
using KludgeBox.Net;

namespace NeoVector;

public partial class Game : Node2D
{
	
	[Export] [NotNull] public NodeContainer MainSceneContainer { get; private set; }
	[Export] [NotNull] public PlayerInfo PlayerInfo { get; private set; }
	[Export] [NotNull] public Console Console { get; private set; }
	
	public override void _Ready()
	{
        NotNullChecker.CheckProperties(this);
        
        if (!OS.GetCmdlineArgs().Contains(ServerParams.ServerFlag) ||
            OS.GetCmdlineArgs().Contains(ServerParams.RenderFlag))
        {
	        Console.QueueFree();
        }
        else
        {
	        Log.AddLogger(Console);
        }
	}
}