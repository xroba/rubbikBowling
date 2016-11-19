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
		public void T00PassingScoreTest(){
			Assert.AreEqual(1,1);
		}

		[Test]
			public void T01FirstBallReturnNull(){
			List<int> pinFallList = new List<int>(){3};
			Assert.AreEqual(null, _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}

		[Test]
		public void T02TwoFirstBall_4_3_Return7 ()
		{
			List<int> pinFallList = new List<int>(){4,3};
			Assert.AreEqual(new List<int>(){7} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}

		[Test]
		public void T03FirstBall_4_3_6_2_Return15 ()
		{
			List<int> pinFallList = new List<int>(){4,3,6,2};
			Assert.AreEqual(new List<int>(){7,15} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}

		[Test]
		public void T04FirstBall_10_Return_null ()
		{
			List<int> pinFallList = new List<int>(){10};
			Assert.AreEqual(null , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}

	[Test]
		public void T05FirstBall_10_4_3_Return17_24 ()
		{
			List<int> pinFallList = new List<int>(){10,4,3};
		Assert.AreEqual(new List<int>(){17,24} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}

	[Test]
		public void T06FirstBall_10_4_Return_10 ()
		{
			List<int> pinFallList = new List<int>(){10,4};
		Assert.AreEqual(new List<int>(){10} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}

	[Test]
		public void T07FirstBall_10_4_3_6_1Return17_24_31 ()
		{
			List<int> pinFallList = new List<int>(){10,4,3,6,1};
		Assert.AreEqual(new List<int>(){17,24,31} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}
	[Test]
		public void T08_2strike_10_10Return_10_10 ()
		{
			List<int> pinFallList = new List<int>(){10,10};
			Assert.AreEqual(new List<int>(){10,10} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}
	[Test]
		public void T09_3strike_10_10_5_Return_25_10 ()
		{
			List<int> pinFallList = new List<int>(){10,10,5};
		Assert.AreEqual(new List<int>(){25,10} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}
	[Test]
		public void T10_3strike_10_10_5_4_Return_25_10 ()
		{
			List<int> pinFallList = new List<int>(){10,10,5,4};
		Assert.AreEqual(new List<int>(){25,44,53} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}
	[Test]
		public void T11_3strike_10_10_10Return_30_10_10 ()
		{
			List<int> pinFallList = new List<int>(){10,10,10};
		Assert.AreEqual(new List<int>(){30,10,10} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
		}
	}