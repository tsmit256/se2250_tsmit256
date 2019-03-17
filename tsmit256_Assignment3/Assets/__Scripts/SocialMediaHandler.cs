using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SocialMediaHandler
{
    private const string _URL = "https://twitter.com/intent/tweet";
    private static string _tweetMessage;
    public static void ShareTweet()
    {
        _tweetMessage = " Wahoo - I just scored " + ScoreManager.SCORE + " in Prospector Solitaire";

        Application.OpenURL(_URL + "?text=" + WWW.EscapeURL(_tweetMessage) + "&amp;lang=" + WWW.EscapeURL("en"));
    }
}
