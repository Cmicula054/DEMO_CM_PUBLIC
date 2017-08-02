using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoApplication.Models;
using System.Web;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using PostmarkDotNet;
using System.Web.Http.Description;

namespace DemoApplication.Controllers
{
    public class RegisterUserController : ApiController
    {


        [HttpPost]
        [Route("API/RegisterUser")]
        public IHttpActionResult RegisterUser([FromBody]UserRegistraction UR)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var path = HttpContext.Current.Server.MapPath("~/App_Data") + "//Users.xml";

                    var stringwriter = new StringWriter();
                    var serializer = new XmlSerializer(typeof(UserRegistraction));
                    serializer.Serialize(stringwriter, UR);
                    var xmlStr = stringwriter.ToString();

                    // format string to xml 
                    var UserXml = new XmlDocument();
                    UserXml.LoadXml(xmlStr);
                    XmlElement userEl = UserXml.DocumentElement;

                    // assign xmldb to xml document
                    var xmlDb = new XmlDocument();
                    xmlDb.Load(path);


                    // add userEl to root of xmlDb
                    var xe = xmlDb.CreateElement("User"); //[4] Create new User element on xmlDb
                    xe.InnerXml = userEl.InnerXml; //[5] copy UserEL content
                    xmlDb.DocumentElement.AppendChild(xe);

                    xmlDb.Save(path);
                    SendEmailUsingPostMark(UR.Email);
                    
                    return Ok("Registration completed Successfully");
                }

                return Ok("Registration Failed");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);

            }

        }

        [HttpGet]
        [Route("API/CheckUserID")]
        public IHttpActionResult CheckUserID(string username)
        {
            var XMLPath = HttpContext.Current.Server.MapPath("~/App_Data") + "//Users.xml";
            var xml = XDocument.Load(XMLPath);
            List<UserRegistraction> UserList =  xml.Root
                                                    .Elements("User")
                                                    .Select(q => new UserRegistraction
                                                            {
                                                                FirstName = (string)q.Element("FirstName"),
                                                                LastName = (string)q.Element("LastName") ,
                                                                Username = (string)q.Element("Username") ,
                                                                Password = (string)q.Element("Password"),
                                                                AccountTypeId = (int)q.Element("AccountTypeId"),
                                                                Email = (string)q.Element("Email"),
                                                                Phone = (string)q.Element("Phone"),
                                                                Address1 = (string)q.Element("Address1"),
                                                                City = (string)q.Element("City"),
                                                                State = (string)q.Element("State"),
                                                                Zip = (string)q.Element("Zip")
                                                            }).ToList();

            return Ok(UserList.Any(U => U.Username == username));

        }

        [HttpGet]
        [Route("API/GetAllUserssss")]
        [ResponseType(typeof(object))]
        public IHttpActionResult GetAllUsers()
        {
            var XMLPath = HttpContext.Current.Server.MapPath("~/App_Data") + "//Users.xml";
            var xml = XDocument.Load(XMLPath);
            List<UserRegistraction> UserList = xml.Root
                                                    .Elements("User")
                                                    .Select(q => new UserRegistraction
                                                    {
                                                        FirstName = (string)q.Element("FirstName"),
                                                        LastName = (string)q.Element("LastName"),
                                                        Username = (string)q.Element("Username"),
                                                        Password = (string)q.Element("Password"),
                                                        AccountTypeId = (int)q.Element("AccountTypeId"),
                                                        Email = (string)q.Element("Email"),
                                                        Phone = (string)q.Element("Phone"),
                                                        Address1 = (string)q.Element("Address1"),
                                                        City = (string)q.Element("City"),
                                                        State = (string)q.Element("State"),
                                                        Zip = (string)q.Element("Zip")
                                                    }).ToList();
            return Ok(UserList);
        }

        [HttpGet]
        [Route("API/GetValidAccountTypes")]
        public IHttpActionResult GetValidAccountTypes()
        {
            return Ok(AccountType.ValidAccountTypes);
        }

        public void SendEmailUsingPostMark(string email)
        {
            var apikey = ConfigurationManager.AppSettings["PostmarkApiKey"];

            var postmark = new PostmarkClient(ConfigurationManager.AppSettings["PostmarkApiKey"]);

            var message = new PostmarkMessage()
            {
                To = email,
                From = ConfigurationManager.AppSettings["FromAddress"], // This must be a verified sender signature
                Subject = "Test",
                TextBody = "Test",
                HtmlBody = "Test"
            };

            var response = postmark.SendMessageAsync(message);
        }

    }
}
