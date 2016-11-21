using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {

    static public List<int> scoreFrameList = new List<int>();
    public int ballNumber = 1;
    int tmpScore = 0;
    int TotalScore = 0;

    int ballNotArray0 = 0;


    static public List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> scoreCumulative = new List<int>();
        int totalScore = 0;

        foreach(int scoreFrame in ScoreFrames(rolls))
        {
            totalScore += scoreFrame;
            scoreCumulative.Add(totalScore);
        }
        return scoreCumulative;
    }

    static public List<int> ScoreFrames(List<int> rolls)
    {
        List<int> ScoreFrames = new List<int>();

        //return rolls;
        int ball = 1;
        int indexFrame = 0;
        int runningTotal = 0;

        foreach (int scoreFrame in rolls)
        {
            if (rolls.Count <= indexFrame - 1 || ball > 20)
            {
                break;
            }
            //check if is not first ball of the frame
            if (ball % 2 == 0)
            {
                runningTotal += scoreFrame;
                //spare
                if (runningTotal == 10 && rolls.Count > ball)
                {
                    runningTotal = runningTotal + rolls[indexFrame + 1];

                    ScoreFrames.Add(runningTotal);
                }
                else if (runningTotal < 10)
                {
                    ScoreFrames.Add(runningTotal);
                }
            }
            else //this is first ball of the frame
            {
                runningTotal = scoreFrame;
                //if runningTotal 10 means Strike
                //check that we do have 2 balls after
                if (runningTotal == 10) //STRIKE
                { 
                    if (rolls.Count > indexFrame + 2 ) //this case we have 2 ball after in order to calculate
                    {
                        runningTotal = runningTotal + (rolls[indexFrame + 1] + rolls[indexFrame + 2]);
                        ScoreFrames.Add(runningTotal);
                    }
                    ball = ball + 1; //as 2nd ball add below
                }
            }
            ball = ball + 1;
            indexFrame = indexFrame + 1;
        }
        return ScoreFrames;
    }
}
