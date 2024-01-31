public interface IYepProtocol
{
    public const int VALID_MSG_LENGTH = 7;

    string ProcessInput(string message);

}