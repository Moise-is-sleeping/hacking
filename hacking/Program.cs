using System.Security.Cryptography;
using System.Text;

string password = "!@#$%12345qwert";
string incriptedPassword = Incrypt(password);
BruteForce(incriptedPassword);


void BruteForce(string IUserPassword)
{
    string[] passwords = ReadFile();
    foreach (var psswd in passwords)
    {
        if (Incrypt(psswd) == IUserPassword)
        {
            Console.WriteLine("Password = "+psswd);
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






