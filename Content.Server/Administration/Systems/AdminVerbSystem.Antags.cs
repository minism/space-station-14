using Content.Server.GameTicking.Rules;
using Content.Server.Mind.Components;
using Content.Server.Ninja.Systems;
using Content.Server.Zombies;
using Content.Shared.Administration;
using Content.Shared.Database;
using Content.Shared.Verbs;
using Robust.Server.GameObjects;
using Robust.Shared.Configuration;
using Robust.Shared.Utility;

namespace Content.Server.Administration.Systems;

public sealed partial class AdminVerbSystem
{
    [Dependency] private readonly ZombifyOnDeathSystem _zombify = default!;
    [Dependency] private readonly TraitorRuleSystem _traitorRule = default!;
    [Dependency] private readonly NinjaSystem _ninja = default!;
    [Dependency] private readonly NukeopsRuleSystem _nukeopsRule = default!;
    [Dependency] private readonly PiratesRuleSystem _piratesRule = default!;

    // All antag verbs have names so invokeverb works.
    private void AddAntagVerbs(GetVerbsEvent<Verb> args)
    {
        if (!EntityManager.TryGetComponent<ActorComponent?>(args.User, out var actor))
            return;

        var player = actor.PlayerSession;

        if (!_adminManager.HasAdminFlag(player, AdminFlags.Fun))
            return;

        var targetHasMind = TryComp(args.Target, out MindComponent? targetMindComp);
        if (!targetHasMind || targetMindComp == null)
            return;

        Verb traitor = new()
        {
            Text = "Make Traitor",
            Category = VerbCategory.Antag,
            Icon = new SpriteSpecifier.Rsi((new ResourcePath("/Textures/Structures/Wallmounts/posters.rsi")), "poster5_contraband"),
            Act = () =>
            {
                if (targetMindComp.Mind == null || targetMindComp.Mind.Session == null)
                    return;

                _traitorRule.MakeTraitor(targetMindComp.Mind.Session);
            },
            Impact = LogImpact.High,
            Message = Loc.GetString("admin-verb-make-traitor"),
        };
        args.Verbs.Add(traitor);

        Verb zombie = new()
        {
            Text = "Make Zombie",
            Category = VerbCategory.Antag,
            Icon = new SpriteSpecifier.Rsi(new ResourcePath("/Textures/Structures/Wallmounts/signs.rsi"), "bio"),
            Act = () =>
            {
                TryComp(args.Target, out MindComponent? mindComp);
                if (mindComp == null || mindComp.Mind == null)
                    return;

                _zombify.ZombifyEntity(targetMindComp.Owner);
            },
            Impact = LogImpact.High,
            Message = Loc.GetString("admin-verb-make-zombie"),
        };
        args.Verbs.Add(zombie);


        Verb nukeOp = new()
        {
            Text = "Make nuclear operative",
            Category = VerbCategory.Antag,
            Icon = new SpriteSpecifier.Rsi(new ResourcePath("/Textures/Structures/Wallmounts/signs.rsi"), "radiation"),
            Act = () =>
            {
                if (targetMindComp.Mind == null || targetMindComp.Mind.Session == null)
                    return;

                _nukeopsRule.MakeLoneNukie(targetMindComp.Mind);
            },
            Impact = LogImpact.High,
            Message = Loc.GetString("admin-verb-make-nuclear-operative"),
        };
        args.Verbs.Add(nukeOp);

        Verb pirate = new()
        {
            Text = "Make Pirate",
            Category = VerbCategory.Antag,
            Icon = new SpriteSpecifier.Rsi(new ResourcePath("/Textures/Clothing/Head/Hats/pirate.rsi"), "icon"),
            Act = () =>
            {
                if (targetMindComp.Mind == null || targetMindComp.Mind.Session == null)
                    return;

                _piratesRule.MakePirate(targetMindComp.Mind);
            },
            Impact = LogImpact.High,
            Message = Loc.GetString("admin-verb-make-pirate"),
        };
        args.Verbs.Add(pirate);

        Verb spaceNinja = new()
        {
            Text = "Make space ninja",
            Category = VerbCategory.Antag,
            Icon = new SpriteSpecifier.Rsi(new ResourcePath("/Textures/Objects/Weapons/Melee/energykatana.rsi"), "icon"),
            Act = () =>
            {
                if (targetMindComp.Mind == null || targetMindComp.Mind.Session == null)
                    return;

                _ninja.MakeNinja(targetMindComp.Mind);
            },
            Impact = LogImpact.High,
            Message = Loc.GetString("admin-verb-make-space-ninja"),
        };
        args.Verbs.Add(spaceNinja);
    }
}
