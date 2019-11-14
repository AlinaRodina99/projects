using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;


namespace SimpleFTP_task3
{
    public class Server
    {
        private TcpListener tcpListener;

        /// <summary>
        /// request object
        /// </summary>
        private FtpWebRequest ftpWebRequest = null;

        /// <summary>
        /// response object
        /// </summary>
        private FtpWebResponse ftpWebResponse;

        private Stream ftStream;

        private string Host { get; set; }

        public async void List(string directory)
        {
            try
            {
                ftpWebRequest = (FtpWebRequest) FtpWebRequest.Create(string.Format(Host));
                ftpWebRequest.Method = Web
            }
        }
    }
}
