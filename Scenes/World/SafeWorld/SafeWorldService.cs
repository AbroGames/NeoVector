using Game.Content;
using Godot;

public class SafeWorldService
{
    
    public SafeWorldService()
    {
        Root.Instance.EventBus.Subscribe<SafeWorldReadyEvent>(OnSafeWorldReadyEvent);
        Root.Instance.EventBus.Subscribe<SafeWorldProcessEvent>(OnSafeWorldProcessEvent);
    }
    
    public void OnSafeWorldReadyEvent(SafeWorldReadyEvent safeWorldReadyEvent)
    {
        InitSafeWorld(safeWorldReadyEvent.SafeWorld);
    }
    
    public void OnSafeWorldProcessEvent(SafeWorldProcessEvent safeWorldProcessEvent)
    {
        
    }

    public void InitSafeWorld(SafeWorld safeWorld)
    {
        safeWorld.Player = Root.Instance.PackedScenes.World.Player.Instantiate<Player>();
        safeWorld.Player.Position = Vec(500, 500);
		
        var camera = new Camera(); //TODO to camera service
        camera.Position = safeWorld.Player.Position;
        camera.TargetNode = safeWorld.Player;
        camera.Zoom = Vec(0.65);
        camera.SmoothingPower = 1.5;
        safeWorld.AddChild(camera);
        camera.Enabled = true;

        var floor = new Floor();
        floor.Camera = camera;
        safeWorld.AddChild(floor);
        
        safeWorld.AddChild(safeWorld.Player); // must be here to draw over the floor
        PlaySafeMusic(); //TODO to music service (safe music service)
    }
    
    public void PlaySafeMusic()
    {
        //var music = Audio2D.PlayMusic(Music.WorldBgm, 0.7f); //TODO set safe music (not WorldBgm)
        //music.Finished += PlaySafeMusic;
    }
}