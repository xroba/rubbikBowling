using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ScoreDisplay : MonoBehaviour {

    //define in the display of unity manualy !!!
    public Text[] scoreText, frameText;



    public void FillRolls(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);

        for(int i = 0; i < scoreString.Length; i++)
        {
            scoreText[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for(int i=0; i<frames.Count(); i++)
        {
            frameText[i].text = frames[i].ToString();
        }
    }


    public static string FormatRolls(List<int> bowls)
    {
        string output = "";
        int bowlnumber = 1;
        int roll = 0;
        foreach(int bowl in bowls)
        {
            //first ball of frame
            if(bowlnumber%2 != 0)
            {
                //strike
                if(bowl == 10)
                {
                    bowlnumber++;
                    output = output + "X ";
                } else //not a strike on first ball so just put the score
                {
                    output = output + bowl.ToString();
                }
            } else //second ball of the frame 
            {
                var d = bowls[roll - 1] + bowl;
                //check if spare
                if ( (bowl == 10) || (bowls[roll - 1] + bowl == 10) )
                {
                    output = output + "/";
                } else
                {
                    output = output + bowl.ToString();
                }
            }

            bowlnumber++;
            roll++;
        }


        return output;
    }

}
