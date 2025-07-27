﻿using System;
using FFXIVClientStructs.FFXIV.Client.Game;

namespace Ocelot.Gameplay;

public unsafe class Action(ActionType type, uint id)
{
    public float GetRecastTime()
    {
        var recast = ActionManager.Instance()->GetRecastTime(type, id);
        var elapsed = ActionManager.Instance()->GetRecastTimeElapsed(type, id);

        return recast - elapsed;
    }

    public bool CanCast()
    {
        return GetRecastTime() <= 0f;
    }

    public void Cast()
    {
        ActionManager.Instance()->UseAction(type, id);
    }

    public void Cast(uint arg)
    {
        ActionManager.Instance()->UseAction(type, id, arg);
    }

    public Func<Chain.Chain> GetCastChain()
    {
        return () => CastOnChain(Chain.Chain.Create($"Action({type}, {id})"));
    }

    public Chain.Chain CastOnChain(Chain.Chain chain)
    {
        return chain
            .Then(_ => CanCast())
            .Then(_ => Cast());
    }
}
