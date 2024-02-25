﻿using AbroDraft.Scripts.Content;
using AbroDraft.Scripts.EventBus;
using KludgeBox;using Godot;

namespace AbroDraft.Scenes.World.Entities.Character.Player;

[GameService]
public class PlayerBasicSkillService
{
    public PlayerBasicSkillService()
    {
        EventBus.Subscribe<PlayerBasicSkillUseEvent>(UseSkill);
    }

    public void UseSkill(PlayerBasicSkillUseEvent useEvent)
    {
        var player = useEvent.Player;
        var node = Root.Root.Instance.PackedScenes.World.Beam.Instantiate();
        var beam = node as Beam.Beam;
        var shaker = player.Camera.ShakeManually();
        beam.Shaker = shaker;
        
        beam.Rotation = player.Rotation - Mathf.Pi / 2;
        player.GetParent().AddChild(beam);
        beam.Position = player.Position;
        beam.Source = player;
        //beam.Modulate = player.Sprite.Modulate;
        beam.Dps *= player.UniversalDamageMultiplier;
        player.Position -= player.Up() * 250;
        
        Audio2D.PlaySoundOn(Sfx.HornImpact3, player);
        Audio2D.PlaySoundOn(Sfx.DeepImpact, player);
    }
}