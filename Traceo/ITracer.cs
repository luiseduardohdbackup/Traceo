using System;

namespace Traceo
{
	public interface ITracer
	{
		void Init(string apiKey);
		void Report(Exception ex, string[] extraMessages);
		void IdentifyUser(string userID, string email = "");
	}
}

