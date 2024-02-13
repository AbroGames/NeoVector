using Godot;
using System;
using KludgeBox;
using Scenes.World;

public partial class Beam : Node2D
{
	public Player Source { get; set; }
	public double Dps { get; set; } = 6000;
	[Export] [NotNull] public Area2D OuterHitArea { get; private set; }
	[Export] [NotNull] public Sprite2D OuterSpawnSprite { get; set; }
	[Export] [NotNull] public Sprite2D OuterBeamSprite { get; set; }
	
	[Export] [NotNull] public Area2D InnerHitArea { get; private set; }
	[Export] [NotNull] public Sprite2D InnerSpawnSprite { get; set; }
	[Export] [NotNull] public Sprite2D InnerBeamSprite { get; set; }
	[Export] [NotNull] public Curve SizeCurve { get; set; }

	public ManualShake Shaker;
	
	private double _ttl = 2;
	private double _startTtl;
	private double _innerStartWidth;
	private double _outerStartWidth;
	private double _ang;
	private float _startGlow;
	private double _interpolationFactor = (240.0 / 60) * 60;
	private double _shakeDist = 500;
	
	public override void _Ready()
	{
		NotNullChecker.CheckProperties(this);
		_startTtl = _ttl;
		_outerStartWidth = OuterBeamSprite.Scale.Y;
		_innerStartWidth = InnerBeamSprite.Scale.Y;
		var env = Root.Instance.Environment.Environment;
		_startGlow = env.GlowStrength;
		env.GlowStrength *= 1.1f;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_ttl <= 0)
		{
			var env = Root.Instance.Environment.Environment;
			env.GlowStrength = _startGlow;
			Shaker.IsAlive = false;
			QueueFree();
		}

		var ttlFactor = _ttl / _startTtl;
		var sizeFactor = SizeCurve.Sample(ttlFactor);

		Shaker.Strength = 10 * Mathf.Max(0, 1 - Source.DistanceTo(this) / _shakeDist); 
		
		_ttl -= delta;

		InnerSpawnSprite.Rotation += Mathf.DegToRad(360 * delta);
		OuterSpawnSprite.Rotation -= Mathf.DegToRad(360 * delta);
		OuterBeamSprite.Scale = OuterBeamSprite.Scale with { Y = _outerStartWidth * sizeFactor };
		InnerBeamSprite.Scale = InnerBeamSprite.Scale with { Y = _innerStartWidth * sizeFactor };
		
		var outerDamage = new Damage(Bullet.AuthorEnum.PLAYER, new Color(1, 0, 0), Dps * delta * 0.5, Source);
		var innerDamage = new Damage(Bullet.AuthorEnum.PLAYER, new Color(1, 0, 0), Dps * delta * 2, Source);
		
		var outerOthers = OuterHitArea.GetOverlappingAreas();
		var innerOthers = InnerHitArea.GetOverlappingAreas();
		
		foreach (var area in outerOthers)
		{
			if(area.GetParent() is not Enemy body) continue;
			var distFactor = Mathf.Max(0, 1 - (body.Position - Source.Position).Length() / 2000);
			body.Position += this.Right() * distFactor * 10 * Source.UniversalDamageMultiplier * 0.5 * delta * _interpolationFactor;
			body.TakeDamage(outerDamage);
		}
		
		foreach (var area in innerOthers)
		{
			if(area.GetParent() is not Enemy body) continue;
			var distFactor = Mathf.Max(0, 1 - (body.Position - Source.Position).Length() / 2000);
			body.Position += this.Right() * distFactor * 10 * Source.UniversalDamageMultiplier * delta * _interpolationFactor;
			body.TakeDamage(innerDamage);
		}
	}
}
