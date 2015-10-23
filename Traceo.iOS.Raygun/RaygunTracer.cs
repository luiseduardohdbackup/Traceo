using System;
using Mindscape.Raygun4Net;
using System.Collections.Generic;

namespace Traceo.Implementation
{
	public class Tracer : ITracer
	{
		public static Tracer Instance { get; } = new Tracer();
		private Tracer ()	{}

		#region ITracer implementation

		public void Init (string apiKey)
		{
			RaygunClient.Attach (apiKey);
		}

		public void Report (Exception ex, string[] extraMessages)
		{
			IList<string> extraList = null;

			if (extraMessages != null && extraMessages.Length > 0) 
			{
				extraList = new List<string> ();
				foreach (var msg in extraMessages)
				{
					extraList.Add (msg);
				}
				RaygunClient.Current.Send (ex, extraList);
				return;
			}

			RaygunClient.Current.Send (ex);
		}

		public void IdentifyUser (string userID, string email = "")
		{
			RaygunClient.Current.UserInfo.UUID = userID;

			if (!String.IsNullOrWhiteSpace (email))
				RaygunClient.Current.UserInfo.Email = email;
		}

		#endregion
	}
}

