using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConBeepLib
{
    class Note
    {
        private int frequention;
        private int duration;

        public Note(int freq, int dur)
        {
            frequention = freq;
            duration = dur;
        }

        public void sound()
        {
            if (frequention == 32767)
            {
                Thread.Sleep(duration);
            }
            else
            {
                Console.Beep(frequention, duration);
            }
        }
    }
































    //// This example demonstrates the Console.Beep(Int32, Int32) method 
    //using System;
    //using System.Threading;

    //class Sample
    //{
 
    //    // Play the notes in a song. 
    //    protected static void Play(Note[] tune)
    //    {
    //        foreach (Note n in tune)
    //        {
    //            if (n.NoteTone == Tone.REST)
    //                Thread.Sleep((int)n.NoteDuration);
    //            else
    //                Console.Beep((int)n.NoteTone, (int)n.NoteDuration);
    //        }
    //    }

    //    // Define the frequencies of notes in an octave, as well as  
    //    // silence (rest). 
    //    protected enum Tone
    //    {
    //        REST = 0,
    //        G3 = 196,
    //        A3 = 220,
    //        A3sharp = 233,
    //        B3 = 247,
    //        C4 = 262,
    //        C4sharp = 277,
    //        D4 = 294,
    //        D4sharp = 311,
    //        E4 = 330,
    //        F4 = 349,
    //        F4sharp = 370,
    //        G4 = 392,
    //        G4sharp = 415,
    //    }

    //    // Define the duration of a note in units of milliseconds. 
    //    protected enum Duration
    //    {
    //        WHOLE = 1600,
    //        HALF = WHOLE / 2,
    //        QUARTER = HALF / 2,
    //        EIGHTH = QUARTER / 2,
    //        SIXTEENTH = EIGHTH / 2,
    //    }

    //    // Define a note as a frequency (tone) and the amount of  
    //    // time (duration) the note plays. 
    //    protected struct Note
    //    {
    //        Tone toneVal;
    //        Duration durVal;

    //        // Define a constructor to create a specific note. 
    //        public Note(Tone frequency, Duration time)
    //        {
    //            toneVal = frequency;
    //            durVal = time;
    //        }

    //        // Define properties to return the note's tone and duration. 
    //        public Tone NoteTone { get { return toneVal; } }
    //        public Duration NoteDuration { get { return durVal; } }
    //    }
    //}
    //public class Note
    //{
    //}
}
