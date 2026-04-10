public class Player
{
    public string Name {get; set;}
    public int PlayerNumber {get; set;}
    public Character PlayerCharacter {get; set;}

    public Player(int playerNumber, string name, Character playerCharacter)
    {
        PlayerNumber = playerNumber;
        Name = name;
        PlayerCharacter = playerCharacter;
    }
}