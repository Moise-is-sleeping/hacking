using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

string password = "!@#$%12345qwert";
string incriptedPassword = Incrypt(password);
string[] passwords = ReadFile();
bool stop = false;
int size = passwords.Length;
int NumbThreads = 2;
int jump = size / NumbThreads;

var threads = new List<Thread>();

Stopwatch timer = new Stopwatch();


for (int i = 0; i < NumbThreads; i++)
{
    if (i+1 > NumbThreads)
    {
        break;
    }

    var start = jump * i;
    var end = (jump*(i+1))-1;
    var hilo = new Thread(()=>FunThread(start,end));
    // Thread.Sleep(10);
    threads.Add(hilo);
}



timer.Start();
foreach (var hilo in threads)
{
    hilo.Start();
}






void FunThread(int start, int end)
{
    for (int i = start;  i < end; i++)
    {
        if (stop)
        {
            break;
        }
        if (Incrypt(passwords[i]) == incriptedPassword)
        {
            Console.WriteLine("Password = "+passwords[i]+i);
            stop = true;
            timer.Stop();
            Console.WriteLine($"Time : {timer.Elapsed.TotalSeconds}");
            break;
        }
    }
}







string[] ReadFile()
{
    string[] passwords = File.ReadAllLines("C:\\Users\\usuariot\\RiderProjects\\hacking\\hacking\\passwords");
    return passwords;
}

string Incrypt(string str)
{
    SHA256 sha256 = SHA256Managed.Create();
    ASCIIEncoding encoding = new ASCIIEncoding();
    byte[] stream = null;
    StringBuilder sb = new StringBuilder();
    stream = sha256.ComputeHash(encoding.GetBytes(str));
    for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
    return sb.ToString();
}






