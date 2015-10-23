using System;

namespace Traceo
{
	public interface ITracerProxy
	{
		void SetTracer(ITracer tracer);
		void Init(string apiKey);
		void Report(Exception ex, string[] extraMessages);
		void IdentifyUser(string userID);
	}
}

