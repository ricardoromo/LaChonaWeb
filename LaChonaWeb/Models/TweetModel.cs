using System;
using Newtonsoft.Json;

namespace LaChonaWeb
{
	public class TweetModel
	{
		public TweetModel ()
		{
		}

		public ulong StatusID { get; set; }

		public string ScreenName { get; set; }

		public string Text { get; set; }

		[JsonIgnore]
		public string Date { get { return CreatedAt.ToString("g"); } }
		[JsonIgnore]
		public string RTCount { get { return CurrentUserRetweet == 0 ? string.Empty : CurrentUserRetweet + " RT"; } }

		public string Image { get; set; }

		public DateTime CreatedAt {get;set;}

		public ulong CurrentUserRetweet {get;set;}
	}
}

