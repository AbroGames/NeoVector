﻿using AbroDraft.Scripts.Content;
using AbroDraft.Scripts.EventBus;
using Godot;
using KludgeBox;
using KludgeBox.Events;

namespace AbroDraft.Scenes.World.Entities.Character.Player;

[GameService]
public class PlayerAdvancedSkillService
{

    [GameEventListener]
    public void OnPlayerAdvancedSkillUseEvent(PlayerAdvancedSkillUseEvent playerAdvancedSkillUseEvent)
    {
        var player = playerAdvancedSkillUseEvent.Player;
        var node = Root.Root.Instance.PackedScenes.World.SolarBeam.Instantiate();
        var beam = node as Beam.SolarBeam;
        beam.Rotation = -Mathf.Pi / 2;
        beam.Source = player;
        //beam.Modulate = player.Sprite.Modulate;
        beam.Dps *= player.UniversalDamageMultiplier;
        player.Camera.Shake(10, beam.Ttl, false);
        player.AddChild(beam);
        
        Audio2D.PlaySoundOn(Sfx.LaserBeam, player);
        Audio2D.PlaySoundOn(Sfx.LaserBig, player);
        Audio2D.PlaySoundOn(Sfx.Beam, player);
    }
}