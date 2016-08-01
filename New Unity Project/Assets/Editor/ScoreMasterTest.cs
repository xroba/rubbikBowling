using System;
using System.Collections.Generic;
using NUnit.Framework;



	[TestFixture]
	public class ScoreMasterTest
	{
		ScoreMaster _scoreMaster;

		[SetUp]
		public void Setup(){
			_scoreMaster = new ScoreMaster();
		}

		[Test]
		public void PassingScoreTest(){
			Assert.AreEqual(1,1);
		}

		[Test]
			public void FirstBallReturnNull(){
			List<int> pinFallList = new List<int>(){3};
			Assert.AreEqual(null, _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}

		[Test]
		public void TwoFirstBall_4_3_Return7 ()
		{
			List<int> pinFallList = new List<int>(){4,3};
			Assert.AreEqual(new List<int>(){7} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}
	}