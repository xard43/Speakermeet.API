using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SpeakerMeet.API;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace SpeakerMeet.APITests
{
	public class SpeakerControllerSearchTests
	{
		private readonly SpeakerController _controller;
		public SpeakerControllerSearchTests()
		{
			_controller = new SpeakerController();
		}
		[Fact]
		public void ItReturnsOkObjectResult()
		{
			//Arrange
			//Act
			var result = _controller.Search("Jos") as OkObjectResult;
			//Assert
			Assert.NotNull(result);
			Assert.NotNull(result.Value);
			Assert.IsType<OkObjectResult>(result);

		}
		[Fact]
		public void GivenExtactMatchThenOneSpeakerInCollection()
		{
			//Arr
			//Act
			var result = _controller.Search("Janusz") as ObjectResult;
			//Assert
			var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
			Assert.Single(speakers);
		}
		[Theory]
		[InlineData("Janusz")]
		[InlineData("jaNusz")]
		[InlineData("JaNusZ")]
		public void GivenCaseInsensitveMatchThenSpeakerInCollection(string searchString)
		{
			//Arr
			//Act
			var result = _controller.Search(searchString) as OkObjectResult;
			//Ass
			var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
			Assert.Single(speakers);
			Assert.Equal("Janusz", speakers[0].Name);
		}
		[Fact]
		public void ShouldReturnEpmtyCollectionWhenSpeakerDontExist()
		{
			//Arr
			//Act
			var result = _controller.Search("NameNoExist") as OkObjectResult;

			var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
			Assert.Empty(speakers);
		}
		[Fact]
		public void Fiven3MatchThenCollectionWith3Speakers()
		{
			//Arrange
			//Act
			var result = _controller.Search("jan") as OkObjectResult;
			//Assert
			var speakers = ((IEnumerable<Speaker>)result.Value).ToList();

			Assert.True(speakers.Any(x => x.Name == "Janek"));
			Assert.True(speakers.Any(x => x.Name == "Janina"));
			Assert.True(speakers.Any(x => x.Name == "Janek"));


		}
	}
}
