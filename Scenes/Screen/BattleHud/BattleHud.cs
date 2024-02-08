using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;


public partial class BattleHud : Control
{
	[Export] [NotNull] public ProgressBar Xp { get; private set; }
	[Export] [NotNull] public TwoColoredBar HpBar { get; private set; }
	[Export] [NotNull] public Label XpLabel { get; private set; }
	[Export] [NotNull] public Label Waves { get; private set; }
	[Export] [NotNull] public Label Enemies { get; private set; }
	[Export] [NotNull] public Label Level { get; private set; }
	[Export] [NotNull] public Label WaveMessage { get; private set; }
	[Export] [NotNull] public Label Fps { get; private set; }
	
	public Vector2 WaveMessageInitialPosition { get; set; }
	public BattleWorld BattleWorld { get; set; }
	public Queue<double> Deltas { get; set; } = new();
	
	public override void _Ready()
	{
		NotNullChecker.CheckProperties(this);
		Root.Instance.EventBus.Publish(new BattleHudReadyEvent(this));
	}

	public override void _Process(double delta)
	{
		Root.Instance.EventBus.Publish(new BattleHudProcessEvent(this, delta));
	}
}
