using Godot;
using System;
using System.Diagnostics;

public partial class Bullet : Node2D
{

	[Export] private double _speed = 700; //pixels/sec
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += Vector2.FromAngle(Rotation - Mathf.Pi / 2) * _speed * delta;
	}
}
