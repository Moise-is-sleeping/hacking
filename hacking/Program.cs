using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

string password = "!@#$%12345qwert";
string incriptedPassword = Incrypt(password);
string[] passwords = ReadFile();

bool stop = false;



Stopwatch timer = new Stopwatch();

var hilo = new Thread(Thread1);
var hilo2 = new Thread(Thread2);


timer.Start();
hilo.Start();
hilo2.Start();




void Thread1()
{
    
    for (int i = 0; 0 < passwords.Length/2; i++)
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

void Thread2()
{
    for (int x = passwords.Length/2; 0 > passwords.Length*(2/3); x++)
    {
        if (stop)
        {
            break;
        }
        if (Incrypt(passwords[x]) == incriptedPassword)
        {
            Console.WriteLine("Password = " + passwords[x] + x);
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






