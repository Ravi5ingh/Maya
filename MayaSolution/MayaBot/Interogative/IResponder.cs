
namespace MayaBot.Interogative
{
    public interface IResponder
    {
        bool CanRespondTo(string message);

        string RespondTo(string message);
    }
}
