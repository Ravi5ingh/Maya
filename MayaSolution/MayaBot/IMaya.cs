
namespace MayaBot
{
    public interface IMaya
    {
        /// <summary>
        /// The standard greeting
        /// </summary>
        string Greeting { get; }

        /// <summary>
        /// Say something to <see cref="Maya"/> and get a response
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>The response from <see cref="Maya"/></returns>
        string RespondTo(string message);
    }
}
