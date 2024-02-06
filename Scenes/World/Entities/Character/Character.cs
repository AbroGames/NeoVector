using System;
using Game.Content;
using Godot;
using KludgeBox;
using KludgeBox.Scheduling;
using MicroSurvivors;
using Scenes.World;

public partial class Character : CharacterBody2D
{
	public event Action Died;

	public int BaseXp { get; set; } = 1;
	public double MaxHp { get; protected set; } = 10000;
	public double Hp { get; set; } = 10000;
	protected Sprite2D Sprite => GetNode("Sprite2D") as Sprite2D;
	protected Vector2 SmoothedPosition => _smoothedPos;
	protected double HitFlash = 0;


	public double MovementSpeed { get; set; } = 250; // in pixels/sec
	protected double _rotationSpeed = 300; // in degree/sec
	protected double _regenHpSpeed = 500; // hp/sec
	protected double _attackSpeed = 1; // attack/sec
	protected double _secToNextAttack = 0;
	
	
	
	private Vector2 _smoothedPos;


	public void TakeDamage(Damage damage)
	{
		HitFlash = 1;
		var appliedDamage = Mathf.Min(Hp, damage.Amount);
		Hp -= damage.Amount;
		
		if (Hp <= 0)
		{
			Died?.Invoke();
			if (damage.Source is Player ply)
			{
				ply.AddXp(BaseXp);
			}
			QueueFree();
		}
		
		var dmgLabel =
			GD.Load<PackedScene>("res://Scenes/World/Entities/DamageLabel/FloatingLabel.tscn")
				.Instantiate() as FloatingLabel;
		
		dmgLabel.Configure(appliedDamage.ToString("N0"), damage.LabelColor, Mathf.Max(Math.Log(appliedDamage, 75), 0.8));
		dmgLabel.Position = damage.Position;
		GetParent().AddChild(dmgLabel);
	}
	
	public virtual void Update(double delta)
	{
	}

	public virtual void PhysicsUpdate(double delta)
	{
		
	}

	public virtual void Init()
	{
		
	}

	/// <inheritdoc />
	public override void _Ready()
	{
		_smoothedPos = GlobalPosition;
		Init();
	}

	/// <inheritdoc />
	public override void _Process(double delta)
	{
		Update(delta);
		UpdateSmoothedPosition(delta);
		
		Sprite.GlobalPosition = _smoothedPos;
		// flash effect on hit processing
		HitFlash -= 0.02;
		HitFlash = Mathf.Max(HitFlash, 0);
		var shader = Sprite.Material as ShaderMaterial;
		shader.SetShaderParameter("colorMaskFactor", HitFlash);
	}

	/// <inheritdoc />
	public override void _PhysicsProcess(double delta)
	{
		PhysicsUpdate(delta);
	}

	private void UpdateSmoothedPosition(double delta)
	{
		var requiredMovement = GlobalPosition - _smoothedPos;

		var stepFactor = delta / (1.0 / 60);
		var smoothingFactor = 0.5;
		_smoothedPos += requiredMovement * stepFactor * smoothingFactor;
	}
}