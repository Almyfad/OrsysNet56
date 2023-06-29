namespace IntroAspNet.Services
{
	public interface IMessagerie
	{
		bool EnvoyerEmail(string message, string destinataire);
	}

	public class Messagerie : IMessagerie
	{
		private readonly ILogger<Messagerie> _logger;

		public Messagerie(ILogger<Messagerie> logger)
		{
			_logger = logger;
		}
		public bool EnvoyerEmail(string message, string destinataire)
		{
			string msg = $"Envoi du message {message} à {destinataire}";
			_logger.LogInformation(msg);
			return true;
		}
	}
}