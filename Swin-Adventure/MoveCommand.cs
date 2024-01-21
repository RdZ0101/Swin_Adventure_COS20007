using Swin_Adventure;

public class MoveCommand : Command
{
    public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
    { }

    public override string Execute(Player player, string[] text)
    {
        if (text.Length < 2)
        {
            return "Move where?";
        }

        string pathIdentifier = text[1];
        Location currentLocation = player.Location;
        Path path = currentLocation.GetPath(pathIdentifier);

        if (path != null  && !path.Blocked )
        {
            player.Location = path.Destination;
            return $"You have moved to {path.Destination.Name}.";
        }
        else
        {
            return "You can't go that way.";
        }
    }
}
