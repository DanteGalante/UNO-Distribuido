﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UNO_Server.Utilities
{
    public class Smtp
    {
        public SmtpClient createClient()
        {
            SmtpClient client = null;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "gmail.com";
            smtpClient.Port = 2525;
            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("unogame.lis@gmail.com", "UnoLis18012181");

            client = smtpClient;
            
            return client;
        }
    }
}