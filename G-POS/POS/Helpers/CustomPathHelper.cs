using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_POS.POS.Helpers
{
    public class CustomPathHelper
    {
        public CustomPathHelper() { }

        //
        public string get_my_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\");
            return targetDir;
        }

        //manuals
        public string get_manuals_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\extras\manual\");
            return targetDir;
        }

        //audios
        public string get_audios_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\extras\audios\");
            return targetDir;
        }

        //app images
        public string get_app_images_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\extras\app_images\");
            return targetDir;
        }

        //store images
        public string get_store_images_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\extras\store_images\");
            return targetDir;
        }

        //get banners
        public string get_banners_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\extras\gbn\");
            return targetDir;
        }
        //get shortcuts
        public string get_shortcuts_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\extras\shortcuts\");
            return targetDir;
        }
        //get cmds
        public string get_cmds_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\extras\cmds\");
            return targetDir;
        }
        //current user file
        public string get_cur_user_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\temp\users\");
            return targetDir;
        }



        //current reports
        public string get_reports_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path + @"\reports\");
            return targetDir;
        }





    }
}