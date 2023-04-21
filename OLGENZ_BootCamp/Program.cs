using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OLGENZ_BootCamp
{
    public class Program
    {
       static double Area_V(double a,double b)//metodi romelic daitvlis vadratis fartobs
        {
            return a * b;
        }
        static double Area_V(double a, double b,double c)//metodi romelic daitvlis moculobas
        {
            return a * b*c;
        }


        //mesame davalebis sxva varianti
        static double AllInOne(double a,double b,double c=1.0)
        {
            return a * b * c;
        }
        static void Main(string[] args)
        {
            #region Pirveli_Davaleba
            /*1) დაწერეთ შემდეგი პროგრამა:
            კონსოლიდან შეიყვანეთ იუზერის სახელი და პაროლი. თუ დაემთხვა თქვენს მიერ შექმნილ
            იუზერს და პაროლს, კონსოლზე დაიბეჭდოს წარმატება. 5 ცდის შემდეგ კი დააბრუნოს
             შეცდომის შეტყობინება*/
            Dictionary<string, string> DataBaseforusers = new Dictionary<string, string>();// dictionarys viyenebt  bazis stilshi
            // dictionari kargia amistvis radgan is ar gaushvebs ertnairi  emailis mqone momxmareblebs shesabamisad amit shevdzlebt momxmarebelta
            //unikalurobas
            DataBaseforusers.Add("guram.apkhazava908@ens.tsu.ge", "Guga2002");
            DataBaseforusers.Add("gapkhazava@camp.com", "Bootcamp");
            DataBaseforusers.Add("aapkhazava22@gmail.com", "Guram2002");
            DataBaseforusers.Add("admin","admin");

            try
            {
                Console.WriteLine("Hello , Welcome");
                int countattempt = 0;
                do
                {
                   
                    Console.WriteLine("Please Enter your Email");
                    string email = Console.ReadLine();
                    Console.WriteLine("Plase Enter your Password");
                    string password = Console.ReadLine();
                    email = email.Trim().ToLower();// davtrimot  rata stringi iyos wamogebuli zedmeti sicarielebis gareshe
                    //agretve mail sheidzleba iyos uppercase da lower , mati mnishvneloba erti da igive iqneba
                    password = password.Trim();
                    bool success = false;// bool cvali  tu paroli iqneba bazashi mashin is gaxdeba true
                    for (int i = 0; i < DataBaseforusers.Count; i++)
                    {
                        if (DataBaseforusers.ContainsKey(email) && DataBaseforusers.ContainsValue(password))
                        {
                            success = true;
                            break;// ase davachqarebt algoritms da ar iqneba sachiro mtliani ciklis shemovla
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if(success==true)
                    {
                        Console.WriteLine($"Tqven warmatebit shexvedit sistemashi,gamarjoba {email} !");
                        break;
                    }
                    countattempt++;
                    if (countattempt == 5)//mexute cdaze visvrit exceptions
                    {
                       // Console.WriteLine("tqveni mcdeloba dablokilia, gtxovt scadot mogvianebit");
                        throw new TimeoutException("tqveni mcdeloba dablokilia , gtxovt scadot mogvianebit");
                    }
                }
                while (countattempt < 5);//momxmarebewls aqvs sull 5 mcdeloba
            }
            catch (TimeoutException tim)
            {
                Console.WriteLine(tim.Message);// exceptions visvrit  roca  5 jer arasworad akribavs momxmarebeli parols da logins
            }

            #endregion

            #region Atobiti_orobitshi
            /*
             * 2) დაწერეთ პროგრამა, რომელიც კონსოლიდან შეყვანილ რიცხვს გადაიყვანს ორობით ფორმატში.
                შედეგი დაბეჭდეთ კონსოლზე.
             */

            int ricxvi;
            do
            {
                Console.WriteLine("shemoitanet  ricxvi romelsac gadaviyvant orobitshi");
            }
            while (!int.TryParse(Console.ReadLine(), out ricxvi));//sanam momxmarebeli sworad ar shemoitans manamde movtxovt rom shemoitanos

            string decimaltobinar = "";//sashedego cvladi
            int forprint = ricxvi;

            do
            {   
                decimaltobinar += (ricxvi % 2).ToString();//vigebt ricxvis nashts
                ricxvi = ricxvi / 2;
            }while (ricxvi> 0);//vasrulebt operacias manam  ricxvi dadebitia  

            string ans = "";
            for (int i = decimaltobinar.Length-1; i >=0 ; i--)
            {
                ans += decimaltobinar[i];//stringis shebruneba Reverse();
            }
            Console.WriteLine($"{forprint} to binary is :  {ans} \n");
            #endregion

            #region Metodebis gadatvirtva

            /*3) შექმენით ორი გადატვირთული მეთოდი.
            პირველი მეთოდი უნდა ითვლიდეს ფართობს (სიგრძე * სიგანეზე), მეორე მეთოდი
             მოცულობას (სიგრძე * სიგანე * სიმაღლე). გადაეცით მეთოდებს შესაბამისი რაოდენობის
            პარამეტრები*/
            Console.WriteLine(" S(3.4,5.6) is: ");
            Console.WriteLine(Area_V(3.4, 5.6));
            Console.WriteLine(" V(3.4,5.6,8.9) is: ");
            Console.WriteLine(Area_V(3.4, 5.6, 8.9));

            Console.WriteLine("\n  meore varianti \n");

            Console.WriteLine(" S(3.4,5.6) is: ");
            Console.WriteLine(AllInOne(3.4, 5.6));
            Console.WriteLine(" V(3.4,5.6,8.9) is: ");
            Console.WriteLine(AllInOne(3.4, 5.6, 8.9));

            #endregion



        }
    }
}
