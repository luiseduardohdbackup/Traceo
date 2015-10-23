using System;

namespace Traceo
{
	public class Traceo : ITracerProxy
	{
		protected ITracer TracerInternal { get; set; }

		public Traceo ()
		{
		}

		#region ITracerProxy implementation

		public void SetTracer (ITracer tracer)
		{
			TracerInternal = tracer;
		}

		public void Init (string apiKey)
		{
			if (TracerInternal == null)
				throw new InvalidOperationException ("Tracer not set");
			
			TracerInternal.Init (apiKey);
		}

		public void Report (Exception ex, string[] extraMessages)
		{
			if (TracerInternal == null)
				throw new InvalidOperationException ("Tracer not set");
			
			TracerInternal.Report (ex, extraMessages);
		}

		public void IdentifyUser (string userID)
		{
			if (TracerInternal == null)
				throw new InvalidOperationException ("Tracer not set");
			
			TracerInternal.IdentifyUser (userID);
		}

		#endregion
	}
}

