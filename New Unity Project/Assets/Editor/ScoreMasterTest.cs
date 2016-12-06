using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

[TestFixture]
	public class ScoreMasterTest
	{
		
		[SetUp]
		public void Setup(){
			
		}

		[Test]
		public void T00PassingScoreTest(){
			Assert.AreEqual(1,1);
		}

    //	[Test]
    //		public void T01FirstBallReturnNull(){
    //		List<int> pinFallList = new List<int>(){3};
    //		Assert.AreEqual(null, _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}

    //	[Test]
    //	public void T02TwoFirstBall_4_3_Return7 ()
    //	{
    //		List<int> pinFallList = new List<int>(){4,3};
    //		Assert.AreEqual(new List<int>(){7} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}

    //	[Test]
    //	public void T03FirstBall_4_3_6_2_Return15 ()
    //	{
    //		List<int> pinFallList = new List<int>(){4,3,6,2};
    //		Assert.AreEqual(new List<int>(){7,15} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}

    //	[Test]
    //	public void T04FirstBall_10_Return_null ()
    //	{
    //		List<int> pinFallList = new List<int>(){10};
    //		Assert.AreEqual(null , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}

    //[Test]
    //	public void T05FirstBall_10_4_3_Return17_24 ()
    //	{
    //		List<int> pinFallList = new List<int>(){10,4,3};
    //	Assert.AreEqual(new List<int>(){17,24} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}

    //[Test]
    //	public void T06FirstBall_10_4_Return_10 ()
    //	{
    //		List<int> pinFallList = new List<int>(){10,4};
    //	Assert.AreEqual(new List<int>(){10} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}

    //[Test]
    //	public void T07FirstBall_10_4_3_6_1Return17_24_31 ()
    //	{
    //		List<int> pinFallList = new List<int>(){10,4,3,6,1};
    //	Assert.AreEqual(new List<int>(){17,24,31} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}
    //[Test]
    //	public void T08_2strike_10_10Return_10_10 ()
    //	{
    //		List<int> pinFallList = new List<int>(){10,10};
    //		Assert.AreEqual(new List<int>(){10,10} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}
    //[Test]
    //	public void T09_3strike_10_10_5_Return_25_10 ()
    //	{
    //		List<int> pinFallList = new List<int>(){10,10,5};
    //	Assert.AreEqual(new List<int>(){25,10} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}
    //[Test]
    //	public void T10_3strike_10_10_5_4_Return_25_10 ()
    //	{
    //		List<int> pinFallList = new List<int>(){10,10,5,4};
    //	Assert.AreEqual(new List<int>(){25,44,53} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}
    //[Test]
    //	public void T11_3strike_10_10_10Return_30_10_10 ()
    //	{
    //		List<int> pinFallList = new List<int>(){10,10,10};
    //	Assert.AreEqual(new List<int>(){30,10,10} , _scoreMaster.RetrieveScoreFromScoreMasterByList(pinFallList));
    //	}

    	[Test]
    		public void T01Bowl23_return_5(){
    		List<int> pinFallList = new List<int>(){2,3};
            int[] frames = { 5 };
    		Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    	}

    [Test]
    public void T02Bowl2345_return_59()
    {
        List<int> pinFallList = new List<int>() { 2, 3, 4 ,5 };
        int[] frames = { 5,9 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T03Bowl23456_return_59()
    {
        List<int> pinFallList = new List<int>() { 2, 3, 4, 5, 6 };
        int[] frames = { 5, 9 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T04Bowl234561_return_597()
    {
        List<int> pinFallList = new List<int>() { 2, 3, 4, 5, 6, 1 };
        int[] frames = { 5, 9, 7 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T05Bowl2345612_return_597()
    {
        List<int> pinFallList = new List<int>() { 2,3, 4,5, 6,1 , 2 };
        int[] frames = { 5, 9, 7 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T05BowlX1_return_empty()
    {
        List<int> pinFallList = new List<int>() { 10, 1 };
        int[] frames = { };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T06Bowl19_return_empty()
    {
        List<int> pinFallList = new List<int>() { 1, 9 };
        int[] frames = { };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T07Bowl123455_return_37()
    {
        List<int> pinFallList = new List<int>() { 1,2, 3,4, 5,5 };
        int[] frames = { 3, 7};
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T08SpareBonus12355533_return_37138()
    {
        List<int> pinFallList = new List<int>() { 1,2, 3,5 , 5,5, 3,3 };
        int[] frames = { 3, 8, 13, 6 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T09SpareBonus2()
    {
        List<int> pinFallList = new List<int>() { 1,2, 3,5, 5,5, 3,3, 7,1, 9,1, 6 };
        int[] frames = { 3, 8, 13, 6, 8 , 16 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T10StrikeBonus()
    {
        List<int> pinFallList = new List<int>() { 10, 3,4 };
        int[] frames = { 17, 7};
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T10StrikeBonus3()
    {
        List<int> pinFallList = new List<int>() { 1,2, 3,4, 5,4, 3,2, 10, 1,3, 3,4 };
        int[] frames = { 3, 7, 9, 5, 14, 4, 7 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T11MultiStrike()
    {
        List<int> pinFallList = new List<int>() { 10,10, 2,3 };
        int[] frames = { 22, 15, 5 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T12MultiStrike3()
    {
        List<int> pinFallList = new List<int>() { 10, 10, 2,3 ,10 ,5,3 };
        int[] frames = { 22, 15, 5, 18, 8 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T13GutterGame()
    {
        List<int> pinFallList = new List<int>() { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
        int[] frames = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreCumulative(pinFallList));
    }

    [Test]
    public void T14TestAllOnes()
    {
        List<int> pinFallList = new List<int>() { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 };
        int[] frames = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreCumulative(pinFallList));
    }

    [Test]
    public void T15TestAllStrikes()
    {
        List<int> pinFallList = new List<int>() { 10,10,10,10,10,10,10,10,10,10,10,10 };
        int[] frames = { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreCumulative(pinFallList));
    }

    [Test]
    public void T16TestIntermediateStrikeBonus()
    {
        List<int> pinFallList = new List<int>() { 5,5,3 };
        int[] frames = { 13 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreCumulative(pinFallList));
    }

    [Test]
    public void T17SpareInLastFrame()
    {
        List<int> pinFallList = new List<int>() { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,7 };
        int[] frames = { 2,4,6,8,10,12,14,16,18,35 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreCumulative(pinFallList));
    }

    [Test]
    public void T18trikeInLastFrameWoCumulative()
    {
        List<int> pinFallList = new List<int>() { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 2,3 };
        int[] frames = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 15 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreFrames(pinFallList));
    }

    [Test]
    public void T19StrikeInLastFrame()
    {
        List<int> pinFallList = new List<int>() { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 2,3 };
        int[] frames = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 33 };
        Assert.AreEqual(frames.ToList<int>(), ScoreMaster.ScoreCumulative(pinFallList));
    }

  
}