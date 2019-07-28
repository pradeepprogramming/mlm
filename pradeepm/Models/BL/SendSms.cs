using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace pradeepm.Models.BL
{
    public class SendSMS
    {
        //
        //static string auserid = "bestway", apassword = "1234567", senderid = "BSTWAY", mainapi = "http://198.24.149.4/API/pushsms.aspx?loginID={0}&password={1}&senderid={2}&route_id=2&Unicode=0&mobile={3}&text={4}";
        static string auserid = "NSzaid", apassword = "123", senderid = "NTVRSL", mainapi = "http://tube.nessms.com/sendsms/sendsms.php?username={0}&password={1}&type=TEXT&sender={2}&mobile={3}&message={4}";
        public static void Joining(string Accountid, string Name, string Mobile, string password, string tranpin)
        {
            try
            {

                string msg = string.Format("Welcome {1} to Netversal7x, Thank you for joining us. ID : {0} ,Password : {2} and Transaction Password : {3} visit: www.Netversal7x.com", Accountid, Name, password, tranpin);
                string api = string.Format(mainapi, auserid, apassword, senderid, Mobile, msg);
                using (WebClient client = new WebClient())
                {
                    string msgreturn = client.DownloadString(api);
                }
            }
            catch (Exception ex)
            {

            }
        }


        internal static bool PinTransfer(string mobile, int otp)
        {
            try
            {

                string msg = string.Format("Otp is {0}. You are going to transfer your E-pin to other.", otp);
                string api = string.Format(mainapi, auserid, apassword, senderid, mobile, msg);
                using (WebClient client = new WebClient())
                {
                    string msgreturn = client.DownloadString(api);
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static bool AmountDebit(string accountid, decimal amount, string mobile)
        {
            try
            {
                string msg = string.Format("Your Account '{0}' has been debited with {1}/- amount, Thank for working with us", accountid, amount);
                string api = string.Format(mainapi, auserid, apassword, senderid, mobile, msg);
                using (WebClient client = new WebClient())
                {
                    string msgreturn = client.DownloadString(api);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static bool AmountCradit(string accountid, decimal amount, string mobile)
        {
            try
            {
                string msg = string.Format("Your Account '{0}' has been Cradited with {1}/- amount, Thank for working with us", accountid, amount);
                string api = string.Format(mainapi, auserid, apassword, senderid, mobile, msg);
                using (WebClient client = new WebClient())
                {
                    string msgreturn = client.DownloadString(api);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
