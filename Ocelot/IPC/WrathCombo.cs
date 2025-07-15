using System;
using ECommons.EzIpcManager;

namespace Ocelot.IPC;

public class WrathCombo() : IPCSubscriber("WrathCombo")
{
    [EzIPC] public readonly Func<string, string, Guid?> RegisterForLease = null!;

    [EzIPC] public readonly Action<Guid> ReleaseControl = null!;

    [EzIPC] public readonly Func<Guid, AutoRotationConfigOption, object, SetResult> SetAutoRotationConfigState = null!;

    [EzIPC] public readonly Func<Guid, string, bool, SetResult> SetComboOptionState = null!;


    // These enums have been copied from Wrath
    public enum AutoRotationConfigOption
    {
        InCombatOnly = 0,
        DPSRotationMode = 1,
        HealerRotationMode = 2,
        FATEPriority = 3,
        QuestPriority = 4,
        SingleTargetHPP = 5,
        AoETargetHPP = 6,
        SingleTargetRegenHPP = 7,
        ManageKardia = 8,
        AutoRez = 9,
        AutoRezDPSJobs = 10,
        AutoCleanse = 11,
        IncludeNPCs = 12,
    }

    public enum SetResult
    {
        IGNORED = -1,
        Okay = 0,
        OkayWorking = 1,
        IPCDisabled = 10,
        InvalidLease = 11,
        BlacklistedLease = 12,
        Duplicate = 13,
        PlayerNotAvailable = 14,
        InvalidConfiguration = 15,
        InvalidValue = 16,
    }
}
