using UnityEngine;

public static class TimerInterpritator 
{
    public static string InterpritationTime(float time)
    {
        string interptitationTime = "Time: ";

        if (time / 3600 >= 1)
        {
            float hours = time / 3600;
            hours = Mathf.Round(hours);
            interptitationTime += $"{hours}h";
        }
        else if (time / 60 >= 1)
        {
            float minuts = time / 60;
            minuts = Mathf.Round(minuts);
            interptitationTime += $"{minuts}m";
        }
        else
        {
            time = Mathf.Round(time);
            interptitationTime += $"{time}s";
        }


        return interptitationTime;
    }
}
