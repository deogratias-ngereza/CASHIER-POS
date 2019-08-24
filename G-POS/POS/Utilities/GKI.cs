//https://tekeye.uk/visual_studio/encrypt-decrypt-c-sharp-string
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

using System.Management;

namespace GKM
{
    public class GKI
    {

        public static string PARTIAL_KEY;


        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "gmtechconsultltd";//"pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;


        public static int getRemainDays()
        {
            DateTime expiration_date = Convert.ToDateTime(getEndDate());
            DateTime currentDateTime = DateTime.Now;
            int daydiff = (int)((expiration_date - currentDateTime).TotalDays);
            return daydiff + 1;
        }
        public static bool isDateValid()
        {
            DateTime expiration_date = Convert.ToDateTime(getEndDate());
            DateTime currentDateTime = DateTime.Now;
            if (expiration_date <= currentDateTime)
            {
                // expired 
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool isCodeValid(string c)
        {
            if (getCode() == c) return true;
            else return false;
        }
        public static bool isProcessorValid()
        {
            //System.Windows.Forms.MessageBox.Show(MotherboardInfo.ProcessorId + " vs " + getProcessorID());
            if (MotherboardInfo.ProcessorId == getProcessorID()) return true;
            return false;
        }
        public static bool isSysNameValid()
        {
            if (MotherboardInfo.SystemName == getSysName()) return true;
            return false;
        }
        public static string getEndDate()
        {
            try
            {
                string rawDate = PARTIAL_KEY.Substring(8, 6);//250101
                return "20" + rawDate.Substring(0, 2) + "-" + rawDate.Substring(2, 2) + "-" + rawDate.Substring(4, 2);
            }
            catch (Exception ex)
            {
                return "2001-01-01";
            }
        }
        public static string getCode()
        {
            try
            {
                return PARTIAL_KEY.Substring(4, 4);//0001
            }
            catch (Exception ex)
            {
                return "0000";
            }
        }
        public static int getEncCategory()
        {
            try
            {
                return Convert.ToInt32(PARTIAL_KEY.Substring(14, 1));//0/1/2
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        public static string getProcessorID()
        {
            try
            {
                int procLen = Convert.ToInt32(PARTIAL_KEY.Substring(0, 2));
                return PARTIAL_KEY.Substring(15, procLen);//BFEBFBFF00040651
            }
            catch (Exception ex)
            {
                return "0000000000000000";
            }
        }
        public static string getSysName()
        {
            try
            {
                int procLen = Convert.ToInt32(PARTIAL_KEY.Substring(0, 2));
                int sysNLen = Convert.ToInt32(PARTIAL_KEY.Substring(2, 2));
                return PARTIAL_KEY.Substring(15 + procLen, sysNLen);//DESKTOP-VA8FUHA
            }
            catch (Exception ex)
            {
                return "DESKTOP-0000000";
            }
        }

        public static bool isKeyValid(string code)
        {
            int opt = getEncCategory();
            if (opt == 0)
            {
                if (isDateValid() == true) return true;
                else return false;
            }
            else if (opt == 1)
            {
                if (isDateValid() == true && isCodeValid(code) == true) return true;
                else return false;
            }
            else if (opt == 2)
            {
                if (isDateValid() == true && isCodeValid(code) == true && isProcessorValid() == true && isSysNameValid() == true) return true;
                else return false;
            }
            return false;
        }


        //Decrypt
        public static string DecryptString(string cipherText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();

                PARTIAL_KEY = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
            catch (Exception ex)
            {
                PARTIAL_KEY = "ERROR";
                return "ERROR";
            }

        }

        public static string DecryptString2(string cipherString, bool useHashing, string key = "my_token")
        {
            try
            {

                byte[] keyArray;
                //get the byte code of the string

                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                System.Configuration.AppSettingsReader settingsReader =
                                                    new AppSettingsReader();

                if (useHashing)
                {
                    //if hashing was used get the hash code with regards to your key
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    //release any resource held by the MD5CryptoServiceProvider

                    hashmd5.Clear();
                }
                else
                {
                    //if hashing was not implemented get the byte code of the key
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);
                }

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes. 
                //We choose ECB(Electronic code Book)

                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                                     toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor                
                tdes.Clear();
                //return the Clear decrypted TEXT
                PARTIAL_KEY = UTF8Encoding.UTF8.GetString(resultArray);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                PARTIAL_KEY = "ERROR";
                return "ERROR";
            }

        }
    }



    public class KM
    {

        public string endDate { set; get; }
        public int code { set; get; }
        public string processor_id { set; get; }
        public string sys_name { set; get; }

    }

    static public class MotherboardInfo
    {
        private static ManagementObjectSearcher baseboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        private static ManagementObjectSearcher motherboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");

        static public string Availability
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return GetAvailability(int.Parse(queryObj["Availability"].ToString()));
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string ProcessorId
        {
            get
            {
                try
                {
                    string cpuInfo = string.Empty;
                    ManagementClass mc = new ManagementClass("win32_processor");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        //Get only the first CPU's ID
                        cpuInfo = mo.Properties["processorID"].Value.ToString();
                        return cpuInfo;
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }



        static public bool HostingBoard
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        if (queryObj["HostingBoard"].ToString() == "True")
                            return true;
                        else
                            return false;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        static public string InstallDate
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return ConvertToDateTime(queryObj["InstallDate"].ToString());
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string Manufacturer
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Manufacturer"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string Model
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Model"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string PartNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["PartNumber"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string PNPDeviceID
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["PNPDeviceID"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string PrimaryBusType
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["PrimaryBusType"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string Product
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Product"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public bool Removable
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        if (queryObj["Removable"].ToString() == "True")
                            return true;
                        else
                            return false;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        static public bool Replaceable
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        if (queryObj["Replaceable"].ToString() == "True")
                            return true;
                        else
                            return false;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        static public string RevisionNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["RevisionNumber"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string SecondaryBusType
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["SecondaryBusType"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string SerialNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["SerialNumber"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string Status
        {
            get
            {
                try
                {
                    foreach (ManagementObject querObj in baseboardSearcher.Get())
                    {
                        return querObj["Status"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string SystemName
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["SystemName"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string Version
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Version"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        private static string GetAvailability(int availability)
        {
            switch (availability)
            {
                case 1: return "Other";
                case 2: return "Unknown";
                case 3: return "Running or Full Power";
                case 4: return "Warning";
                case 5: return "In Test";
                case 6: return "Not Applicable";
                case 7: return "Power Off";
                case 8: return "Off Line";
                case 9: return "Off Duty";
                case 10: return "Degraded";
                case 11: return "Not Installed";
                case 12: return "Install Error";
                case 13: return "Power Save - Unknown";
                case 14: return "Power Save - Low Power Mode";
                case 15: return "Power Save - Standby";
                case 16: return "Power Cycle";
                case 17: return "Power Save - Warning";
                default: return "Unknown";
            }
        }

        private static string ConvertToDateTime(string unconvertedTime)
        {
            string convertedTime = "";
            int year = int.Parse(unconvertedTime.Substring(0, 4));
            int month = int.Parse(unconvertedTime.Substring(4, 2));
            int date = int.Parse(unconvertedTime.Substring(6, 2));
            int hours = int.Parse(unconvertedTime.Substring(8, 2));
            int minutes = int.Parse(unconvertedTime.Substring(10, 2));
            int seconds = int.Parse(unconvertedTime.Substring(12, 2));
            string meridian = "AM";
            if (hours > 12)
            {
                hours -= 12;
                meridian = "PM";
            }
            convertedTime = date.ToString() + "/" + month.ToString() + "/" + year.ToString() + " " +
            hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString() + " " + meridian;
            return convertedTime;
        }
    }
}
