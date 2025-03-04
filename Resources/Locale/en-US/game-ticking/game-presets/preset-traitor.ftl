
## Traitor

# Shown at the end of a round of Traitor
traitor-round-end-result = {$traitorCount ->
    [one] There was one traitor.
    *[other] There were {$traitorCount} traitors.
}

traitor-round-end-codewords = The codewords were: [color=White]{$codewords}[/color]

# Shown at the end of a round of Traitor
traitor-user-was-a-traitor = [color=gray]{$user}[/color] was a traitor.
traitor-user-was-a-traitor-named = [color=White]{$name}[/color] ([color=gray]{$user}[/color]) was a traitor.
traitor-was-a-traitor-named = [color=White]{$name}[/color] was a traitor.

traitor-user-was-a-traitor-with-objectives = [color=gray]{$user}[/color] was a traitor who had the following objectives:
traitor-user-was-a-traitor-with-objectives-named = [color=White]{$name}[/color] ([color=gray]{$user}[/color]) was a traitor who had the following objectives:
traitor-was-a-traitor-with-objectives-named = [color=White]{$name}[/color] was a traitor who had the following objectives:

preset-traitor-objective-issuer-syndicate = [color=#87cefa]The Syndicate[/color]
preset-traitor-objective-issuer-spiderclan = [color=#33cc00]Spider Clan[/color]

# Shown at the end of a round of Traitor
traitor-objective-condition-success = {$condition} | [color={$markupColor}]Success![/color]

# Shown at the end of a round of Traitor
traitor-objective-condition-fail = {$condition} | [color={$markupColor}]Failure![/color] ({$progress}%)

traitor-title = Traitor
traitor-description = There are traitors among us...
traitor-not-enough-ready-players = Not enough players readied up for the game! There were {$readyPlayersCount} players readied up out of {$minimumPlayers} needed.
traitor-no-one-ready = No players readied up! Can't start Traitor.

## TraitorDeathMatch
traitor-death-match-title = Traitor Deathmatch
traitor-death-match-description = Everyone's a traitor. Everyone wants each other dead.
traitor-death-match-station-is-too-unsafe-announcement = The station is too unsafe to continue. You have one minute.
traitor-death-match-end-round-description-first-line = The PDAs recovered afterwards...
traitor-death-match-end-round-description-entry = {$originalName}'s PDA, with {$tcBalance} TC

## TraitorRole

# TraitorRole
traitor-role-greeting =
    You are a syndicate agent.
    Your objectives and codewords are listed in the character menu.
    Use the uplink loaded into your PDA to buy the tools you'll need for this mission.
    Death to Nanotrasen!
traitor-role-codewords =
    The codewords are:
    {$codewords}.
    Codewords can be used in regular conversation to identify yourself discretely to other syndicate agents.
    Listen for them, and keep them secret.
