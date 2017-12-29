
namespace MayaBot.Response
{
    public interface IResponder
    {
        bool CanRespondTo(string message);

        string RespondTo(string message);
    }
}
