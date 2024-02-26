﻿using KludgeBox.Events;

namespace NeoVector.World;

public readonly record struct EnemyStartAttractionEvent(Enemy Enemy) : IEvent;
public readonly record struct EnemyStopAttractionEvent(Enemy Enemy) : IEvent;
public readonly record struct EnemyPhysicsProcessEvent(Enemy Enemy, double Delta) : IEvent;
public readonly record struct EnemyProcessEvent(Enemy Enemy, double Delta) : IEvent;
public readonly record struct EnemyReadyEvent(Enemy Enemy) : IEvent;
public readonly record struct EnemyAttackEvent(Enemy Enemy) : IEvent;