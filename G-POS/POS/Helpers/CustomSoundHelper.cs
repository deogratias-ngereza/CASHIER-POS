using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace G_POS.POS.Helpers
{
    public class CustomSoundHelper
    {
        public CustomSoundHelper() { }


        //get 
        public void getDefaultTone()
        {

            try
            {
                // do click stuff
                //System.Media.SoundPlayer My_JukeBox = new System.Media.SoundPlayer(@"D:\GRAND_PRO\PROJECTS\Simple Restaurant Manager\res\sounds\beep-08b.wav");
                System.Media.SoundPlayer My_JukeBox = new System.Media.SoundPlayer(get_my_path() + @"extras\audios\beep-08b.wav");
                My_JukeBox.Play();
            }
            catch (Exception ex)
            {

            }
        }

        //
        public string get_my_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\");
            return targetDir;
        }
    }
}
