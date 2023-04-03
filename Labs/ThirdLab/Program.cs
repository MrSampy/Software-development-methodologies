using System.Net;
using System.Text;
using System.Threading;
HttpListener _httpListener = new HttpListener();

Main();

void Main()
{
    Console.WriteLine("Starting server...");
    _httpListener.Prefixes.Add("http://localhost:8888/"); // add prefix "http://localhost:8888/"
    _httpListener.Start(); // start server (Run application as Administrator!)
    Console.WriteLine("Server started.");
    Thread _responseThread = new Thread(ResponseThread);
    _responseThread.Start(); // start the response thread
}

void ResponseThread()
{
    while (true)
    {
        HttpListenerContext context = _httpListener.GetContext(); // get a context
                                                                  // Now, you'll find the request URL in context.Request.Url
        byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost server -- port 8888</title></head>" +
        "<body>Welcome to the <strong>Localhost server</strong> -- <em>port 8888!</em></body></html>"); // get the bytes to response
        context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); // write bytes to the output stream
        context.Response.KeepAlive = false; // set the KeepAlive bool to false
        context.Response.Close(); // close the connection
        Console.WriteLine("Respone given to a request.");
    }
}