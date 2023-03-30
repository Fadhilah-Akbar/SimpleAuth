using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace SimpleAuth;

public class Auth
{
    public static void Main(string[] args)
    {
        List<Data> users = new List<Data>();
        int i = 0;
        do
        {
            Console.WriteLine("== BASIC AUTHENTICATION ==");
            Console.WriteLine("1.Create User");
            Console.WriteLine("2.Show User");
            Console.WriteLine("3.Search User");
            Console.WriteLine("4.Login User");
            Console.WriteLine("5.Exit");
            Console.Write("Input : ");
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
            }catch(Exception e) { }
            finally 
            {
                Console.Clear();
                Console.WriteLine("Peringatan!! jangan masukkan selain angka");
            }
            

            if(i != null)
            {
                switch (i)
                {
                    //create user
                    case 1:
                        Console.Clear();
                        bool isValid1 = true;
                        string firstName = "";
                        string lastName = "";
                        do
                        {
                            Console.Write("First name : ");
                            firstName = Console.ReadLine();
                            if (Regex.IsMatch(firstName, "^(?=.*[A-Za-z])[A-Za-z\\d]{2,}"))
                            {
                                isValid1 = false;
                            }
                            else
                            {
                                Console.WriteLine("FirstName much have at least 2 charachter");
                            }
                        } while (isValid1);
                        do
                        {
                            isValid1 = true;
                            Console.Write("Last name  : ");
                            lastName = Console.ReadLine();
                            if (Regex.IsMatch(lastName, "^(?=.*[A-Za-z])[A-Za-z\\d]{2,}"))
                            {
                                isValid1 = false;
                            }
                            else
                            {
                                Console.WriteLine("LastName much have at least 2 charachter");
                            }
                        } while (isValid1);
                        string username = $"{firstName[..2]}{lastName[..2]}";
                        bool x = true;
                        do
                        {
                            Console.Write("Password   : ");
                            string password = Console.ReadLine();
                            if (!Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$"))
                            {
                                Console.WriteLine("Password must have at least 8 characters");
                                Console.WriteLine("at least one Upper Case letter, one Lower Case letter and one number.");
                            }
                            else
                            {
                                Console.WriteLine("");
                                users.Add(new Data(firstName, lastName, username, password));
                                Console.WriteLine("Data Berhasil disimpan");
                                x = false;
                            }
                        } while (x);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //END OF Create user

                    case 2:
                    //Show User
                        Console.Clear();                                             
                        int input = 0;
                        do
                        {
                            Console.WriteLine("== SHOW USER ==");
                            Console.WriteLine("========================");
                            if (users.Any())
                            {
                                int id=0;
                                foreach (Data data in users)
                                {
                                    Console.WriteLine("====================");
                                    Console.WriteLine("ID       : "+id);
                                    data.WriteData();
                                    Console.WriteLine("========================");
                                    id++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Data tidak tersedia");
                            }
                            Console.WriteLine("Menu");
                            Console.WriteLine("1.Edit User");
                            Console.WriteLine("2.Delete User");
                            Console.WriteLine("3.Back");
                            Console.Write("input :");
                            try
                            {
                                input = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                Console.WriteLine("Peringatan!! jangan masukkan selain angka");
                            };
                            switch (input)
                            {
                                case 1:
                                    Console.Write("Id yang ingin diubah :");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    bool isVal = true;
                                    string FirstName = "";
                                    string Lastname = "";
                                    string Password = "";
                                    Console.Clear();
                                    do
                                    {
                                        Console.WriteLine("FirstName :");
                                        FirstName = Console.ReadLine();
                                        if (Regex.IsMatch(FirstName, "^(?=.*[A-Za-z])[A-Za-z\\d]{2,}"))
                                        {
                                            isVal = false;
                                        }
                                        else {
                                            Console.WriteLine("FirstName much have at least 2 charachter");
                                        }
                                    } while (isVal);
                                    do
                                    {
                                        isVal = true;
                                        Console.WriteLine("LastName :");
                                        Lastname = Console.ReadLine();
                                        if (Regex.IsMatch(Lastname, "^(?=.*[A-Za-z])[A-Za-z\\d]{2,}"))
                                        {
                                            isVal = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("LastName much have at least 2 charachter");
                                        }
                                    } while (isVal);
                                    string UserName = $"{FirstName[..2]}{Lastname[..2]}";
                                    do
                                    {
                                        isVal = true;
                                        Console.WriteLine("Password :");
                                        Password = Console.ReadLine();
                                        if (!Regex.IsMatch(Password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$"))
                                        {
                                            Console.WriteLine("Password must have at least 8 characters");
                                            Console.WriteLine("at least one Upper Case letter, one Lower Case letter and one number.");
                                        }
                                        else
                                        {
                                            isVal = false;
                                        }
                                    } while (isVal);

                                    users[id] = new Data(FirstName,Lastname,UserName,Password);
                                    Console.WriteLine("Data Berhasil diubah");                                         
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.Write("Id yang ingin dihapus :");
                                    int id1 = Convert.ToInt32(Console.ReadLine());
                                    users.RemoveAt(id1);
                                    Console.WriteLine("Data Berhasil dihapus");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 3:
                                    break;
                                default:
                                    Console.WriteLine("Silahkan pilih 1-3");
                                    break;
                            }
                        } while (input != 3 || input == null);
                        Console.Clear();
                        break;
                    //End Of Show User

                    case 3:
                    //Search User
                        Console.Clear();
                        Console.WriteLine("== Cari Akun ==");
                        Console.Write("Masukkan Nama :");
                        string cari = Console.ReadLine();
                        var result = users.Where(u =>
                                                u.FirstName.ToLower().Contains(cari.ToLower()) ||
                                                u.LastName.ToLower().Contains(cari.ToLower()));//from s in users where s.FirstName == cari || s.LastName == cari select s;

                        if (result.Any())
                        {
                            int count = 0;
                            foreach (var item in result)
                            {
                                Console.WriteLine("====================");
                                item.WriteData();
                                Console.WriteLine("====================");
                                count++;
                            }
                            Console.WriteLine("Jumlah data yang ditemukan : "+ count);
                        }
                        else
                        {
                            Console.WriteLine("Data tidak ditemukan");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //End Of Search User

                    case 4:
                    //Login
                        Console.Clear();
                        Console.WriteLine("== Login ==");
                        string usernameCek = "";
                        string passwrodCek = "";
                        do
                        {
                            Console.Write("Username :");
                            usernameCek = Console.ReadLine();
                            if (usernameCek == null || usernameCek == "")
                            {
                                Console.WriteLine("Silahkan isi Username");
                            }
                        } while (usernameCek == null || usernameCek == "");

                        do
                        {
                            Console.Write("Passwrod :");
                            passwrodCek = Console.ReadLine();
                            if (passwrodCek == null || passwrodCek == "")
                            {
                                Console.WriteLine("Silahkan isi Password");
                            }
                        } while (passwrodCek == null || passwrodCek == "");                     
                        var login = users.SingleOrDefault(u => 
                                            u.Username == usernameCek &&
                                            u.Password == passwrodCek);
                        if (login != null)
                        {
                            Console.WriteLine("Login Berhasil");
                            Console.WriteLine("Hi " + login.FirstName);
                        }
                        else
                        {
                            Console.WriteLine("Login Gagal");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //End of Login
                    case 5:
                        break;

                    default:
                        Console.WriteLine("Silahkan Pilih angka 1-5");
                        Console.Clear();
                        break;
                }
            }
            
        } while (i != 5);
    }
}