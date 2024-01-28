using System;
using Game.Content;
using Godot;
using MicroSurvivors;

public partial class Character : CharacterBody2D
{
	
	[Export] private double _movementSpeed = 250; // in pixels/sec
	[Export] private double _rotationSpeed = 300; // in degree/sec
	[Export] private double _attackSpeed = 3; // attack/sec
	
	[Export] private PackedScene _bulletBlueprint;

	private double _secToNextAttack = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		RotateToMouse(delta);
		Attack(delta);
	}
	
	public override void _PhysicsProcess(double delta)
	{
		var movementInput = GetInput();
		// Переместить и првоерить физику
		MoveAndCollide(movementInput * _movementSpeed * delta);
	}
	
	private Vector2 GetInput()
	{
		return Input.GetVector(Keys.Left, Keys.Right, Keys.Up, Keys.Down);
	}

	private void RotateToMouse(double delta)
	{
		//Куда хотим повернуться
		double targetAngle = GetAngleToMouse();
		//На какой угол надо повернуться (знак указывает направление)
		double deltaAngleToTargetAngel = Mathf.AngleDifference(Rotation - Mathf.Pi / 2, targetAngle);
		//Только направление (-1, 0, 1)
		double directionToTargetAngel = Mathf.Sign(deltaAngleToTargetAngel);
		//Максимальная скорость поворота (за секунду)
		double rotationSpeedRad = Mathf.DegToRad(_rotationSpeed);
		//Максимальная скорость поворота (за прошедшее время)
		rotationSpeedRad *= delta;
		//Если надо повернуться на угол меньший максимальной скорости, то обрезаем скорость, чтобы повернуться ровно в цель
		rotationSpeedRad = Math.Min(rotationSpeedRad, Math.Abs(deltaAngleToTargetAngel));
		//Добавляем к скорости поворота направление, чтобы поворачивать в сторону цели
		rotationSpeedRad *= directionToTargetAngel;
		//Поворачиваемся на угол
		Rotation += rotationSpeedRad;
	}
	
	private double GetAngleToMouse()
	{
		// Получаем текущую позицию мыши
		var mousePos = GetGlobalMousePosition();
		// Вычисляем вектор направления от объекта к мыши
		var mouseDir = GlobalPosition.DirectionTo(mousePos);
		// Вычисляем направление от объекта к мыши
		return mouseDir.Angle();
	}
	
	private void Attack(double delta)
	{
		_secToNextAttack -= delta;
		if (!Input.IsActionPressed(Keys.Attack)) return;
		if (_secToNextAttack > 0) return;

		_secToNextAttack = 1.0 / _attackSpeed;
		
		// Создание снаряда
		Bullet bullet = _bulletBlueprint.Instantiate() as Bullet;
		// Установка начальной позиции снаряда
		bullet.GlobalPosition = GlobalPosition;
		// Установка направления движения снаряда
		bullet.Rotation = GetAngleToMouse() + Mathf.Pi / 2;
		bullet.AuthorIsPlayer = true;
		
		GetParent().AddChild(bullet);
	}
}