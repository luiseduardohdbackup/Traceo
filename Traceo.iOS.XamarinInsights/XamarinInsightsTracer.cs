using System;
using Xamarin;
using System.Collections;
using System.Collections.Generic;
using Android.Content;

namespace Traceo.Implementation
{
	public class Tracer : ITracer
	{
		protected Context Context { get; set; }

		public Tracer (Context context)
		{
			Context = context;
		}

		#region ITracer implementation

		public void Init (string apiKey)
		{
			Insights.Initialize(apiKey, Context);
		}

		public void Report (Exception ex, string[] extraMessages)
		{
			IDictionary extraList = null;

			if (extraMessages != null && extraMessages.Length > 0) 
			{
				extraList = new Dictionary<string, string> ();
				var count = 0;
				foreach (var msg in extraMessages)
				{
					extraList[count.ToString()] = msg;
					count++;
				}
				Insights.Report (ex, extraList, Insights.Severity.Error);
				return;
			}

			Insights.Report (ex, Insights.Severity.Error);
		}

		public void IdentifyUser (string userID, string email = "")
		{
			IDictionary<string, string> extraList = null;

			if (!String.IsNullOrWhiteSpace(email)) 
			{
				extraList = new Dictionary<string, string> ();
				extraList ["email"] = email;
				Insights.Identify (userID, extraList);
				return;
			}

			Insights.Identify (userID, "userId", userID);
		}

		#endregion
	}
}

