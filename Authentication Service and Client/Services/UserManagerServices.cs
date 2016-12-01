//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Models;

//namespace Authentication_Service_and_Client
//{
//    static class UserManagerServices
//    {
//        public static void createUser(User user, String password, String confirmPassword) {
//            if (password.Equals(confirmPassword))
//            {
//                Console.WriteLine("Login - {0}\nFull Name - {1}\nPassword - {2}\nRole - {3}", user.Login, user.FullName, (Object)password.GetHashCode(), user.Role);
//            }   
//        }
//        public static void searchUser(String login, String fullName, String role)
//        {
            
//                Console.WriteLine("Login - {0}\nFull Name - {1}\nRole - {2}", login, fullName, role);
            
//        }
//        //public static void updateUser(User user)
//        //{

//        //    Console.WriteLine("Login - {0}\nFull Name - {1}\nRole - {2}", user.Login, user.FullName, user.Role);

//        }
//        public static void deleteUser(User user) { 

//            Console.WriteLine("Login - {0}", user.Login);

//        }
//        //public static User authorizationUser(String login, String password)
//        //{
//        //    Console.WriteLine("Login - {0}\nPassword - {1}\n", login, (Object)password.GetHashCode());
//        //    return new User(login, "admin", new Role(password));
//        //}
//        public static bool changePassword(User user, String password, String confirmPassword)
//        {
//            if (password.Equals(confirmPassword))
//            {
//                Console.WriteLine("Login - {0}\nPassword - {1}\nConfirm password - {2}\n", user.Login, (Object)password.GetHashCode(), (Object)confirmPassword.GetHashCode());
//                return true;
//            }
//            else
//                return false;
//        }
//        public static void addRole(String roleName)
//        {
//            Console.WriteLine("Role name - {0}", roleName);
//        }
//    }
//}
