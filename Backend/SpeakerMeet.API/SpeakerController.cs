using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeakerMeet.API
{
	[Route("api/[controller]")]
	public class SpeakerController : Controller
	{
		// GET: api/<controller>
		[Route("search")]
		[HttpGet]
		public IActionResult Search(string speakerName)
		{
			List<Speaker> speakers = new List<Speaker>
			{
				new Speaker(){Name = "Janusz"},
				new Speaker(){Name = "Janina"},
				new Speaker(){Name = "Janek"},
				new Speaker(){Name = "Marek"},
				new Speaker(){Name = "Mariusz"}
			};

			return Ok(speakers.Where(x => x.Name.ToLower().StartsWith(speakerName.ToLower())));
			
			 
		}
		
	}
}
