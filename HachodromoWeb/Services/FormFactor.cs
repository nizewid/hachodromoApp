using HachodromoShared.Interfaces;

namespace hachodromoWeb.Services
{
	public class FormFactor : IFormFactor
	{
		public string GetFormFactor() => "Web";

		public string GetPlatform() => Environment.OSVersion.ToString();
	}
}
