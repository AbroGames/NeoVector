﻿using KludgeBox.Events;

namespace NeoVector;

public readonly record struct CameraProcessEvent(Camera Camera, double Delta) : IEvent;
public readonly record struct CameraDeferredProcessEvent(Camera Camera, double Delta) : IEvent;
public readonly record struct CameraReadyEvent(Camera Camera) : IEvent;