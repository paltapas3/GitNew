using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIApp.Models;
using System.Xml.Linq;
using WebAPICore.Models;

namespace WebAPICore.Controllers
{
    public class UsersController : ApiController
    {
        public List<Users> GetAllUser()

        {            

            List<Users> users = new List<Users>();    

            XDocument doc = XDocument.Load("D:\\GitNew\\WebAPICore\\User.Xml");

            foreach (XElement element in doc.Descendants("DocumentElement")

                .Descendants("Users"))

            {

                Users user = new Users();


                user.Customer_Name = element.Element("Customer_Name").Value;

                user.Address =element.Element("Address").Values;

                user.Pan_no =element.Element("Pan_no").Values;

                user.Aadhar_no =element.Element("Aadhar_no").Values;

                user.Phone =element.Element("Phone").Values;

                user.Account_type =element.Element("Account_type").Values;

                user.Gender =element.Element("Gender").Values;

                user.DOB =element.Element("DOB").Values;



                users.Add(user);   

            }

            return users;

        }

        public Users GetUsers(int Pan_no)

        {

           Users user = new Users();

           XDocument doc = XDocument.Load("D:\\GitNew\\WebAPICore\\User.Xml");

            XElement element = doc.Element("DocumentElement")

                                .Elements("Users").Elements("Pan_no").

                                SingleOrDefault(x => x.Value == Pan_no.ToString());

                       if (element != null)

            {

                XElement parent = element.Parent;



                user.Customer_Name =

                        parent.Element("Customer_Name").Value;

                user.Pan_no =

                        parent.Element("Pan_no").Value;

                user.Aadhar_no =

                        parent.Element("Aadhar_no").Value;

                user.Address =

                        parent.Element("Address").Value;

                user.Gender =

                        parent.Element("Gender").Value;

                user.Phone =

                        parent.Element("Phone").Value;

                user.Account_type =

                        parent.Element("Account_type").Value;
     
                user.DOB =

                        parent.Element("DOB").Value;



                return user;

            }

            else

            {

                throw new HttpResponseException

                    (new HttpResponseMessage(HttpStatusCode.NotFound));

            }

        }

    }
}


