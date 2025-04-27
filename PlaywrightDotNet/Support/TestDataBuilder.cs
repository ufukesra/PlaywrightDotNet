using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using Bogus;

namespace PlaywrightDotNet.Support{
    public class TestDataBuilder{
        

       public static string EmailGenerator(){
           var faker= new Faker();
           string email = faker.Internet.Email();//$"{Guid.NewGuid():N}@mail.com";
           return  email;
       } 

       public static string PasswordGenerator(){
           var faker = new Faker();
        
           return  faker.Internet.Password();
       }


       public static string FullNameGenerator()
       {
            return firstName() + " " + lastName();
        }

        public static string DOBGenerator(){
            int dayInt = new Random().Next(1, 31);
            int monthInt = new Random().Next(1, 12);
            int yearInt = new Random().Next(1900, 2021);
            if (monthInt == 2 && dayInt > 28)
            {
                dayInt = new Random().Next(1,28);
            }
            string[] monthNames= {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

            string day = dayInt.ToString();
            string month = monthNames[monthInt-1];
            string year = yearInt.ToString();

            return day+"/"+month+"/"+year;
        }

        public static string firstName(){
            var faker = new Faker();
            string firstName = faker.Name.FirstName();
            return firstName;
        }

        public static string lastName(){
            var faker = new Faker();
            string lastName = faker.Name.LastName();
            return lastName;
        }

        
    }
}