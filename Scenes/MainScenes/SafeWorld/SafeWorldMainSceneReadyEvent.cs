using KludgeBox.Events;

namespace AbroDraft;

public readonly struct SafeWorldMainSceneReadyEvent(SafeWorldMainScene safeWorldMainScene) : IEvent
{
    public SafeWorldMainScene SafeWorldMainScene { get; } = safeWorldMainScene;
}