using System;

namespace LaChonaWeb
{
	public class FeedsModel
	{
		public FeedsModel ()
		{
			
		}

		public string Title { get; set; }
		public string PublishDate { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public string Autor { get; set; }
		public string Link { get; set; }
		public string LogoSource {get{return Constants.AppLogo;}
		}
	}
}

