using System;
using System.Collections.Generic;
using System.Dynamic;
using CloudCore.Core.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Core.Tests.Serialization
{
    /// <summary>
    /// Summary description for ExpandoTests
    /// </summary>
    [TestClass]
    public class ExpandoTests
    {

        /// <summary>
        /// Summary method that demonstrates some
        /// of the basic behaviors.
        /// 
        /// More specific tests are provided below
        /// </summary>
        [TestMethod]
        public void ExandoModesTest()
        {
            // Set standard properties
            var ex = new ExpandoInstance();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            // set dynamic properties
            dynamic exd = ex;
            exd.Company = "Exclr8";
            exd.Accesses = 10;

            // set dynamic properties as dictionary
            ex["Address"] = "64 Atlantic Beach Drive";
            ex["Email"] = "ahm@centacto.com";
            ex["TotalOrderAmounts"] = 51233.99M;

            // iterate over all properties dynamic and native
            foreach (var prop in ex.GetProperties(true))
            {
                Console.WriteLine(prop.Key + " " + prop.Value);
            }

            // you can access plain properties both as explicit or dynamic
            Assert.AreEqual(ex.Name, exd.Name, "Name doesn't match");

            // You can access dynamic properties either as dynamic or via IDictionary
            Assert.AreEqual(exd.Company, ex["Company"] as string, "Company doesn't match");
            Assert.AreEqual(exd.Address, ex["Address"] as string, "Name doesn't match");

            // You can access strong type properties via the collection as well (inefficient though)
            Assert.AreEqual(ex.Name, ex["Name"] as string);

            // dynamic can access everything
            Assert.AreEqual(ex.Name, exd.Name);  // native property
            Assert.AreEqual(ex["TotalOrderAmounts"], exd.TotalOrderAmounts); // dictionary property
        }




        [TestMethod]
        public void AddAndReadDynamicPropertiesTest()
        {
            // strong typing first
            var ex = new ExpandoInstance();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            // create dynamic and create new props
            dynamic exd = ex;
            string company = "Exclr8";
            int count = 10;

            exd.Company = company;
            exd.Accesses = count;

            Assert.AreEqual(exd.Company, company);
            Assert.AreEqual(exd.Accesses, count);
        }

        [TestMethod]
        public void AddAndReadDynamicIndexersTest()
        {
            var ex = new ExpandoInstance();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            string address = "64 Atlantic Beach Drive";

            ex["Address"] = address;
            ex["Contacted"] = true;

            dynamic exd = ex;

            Assert.AreEqual(exd.Address, ex["Address"]);
            Assert.AreEqual(exd.Contacted, true);
        }


        [TestMethod]
        public void PropertyAsIndexerTest()
        {
            // Set standard properties
            var ex = new ExpandoInstance();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            Assert.AreEqual(ex.Name, ex["Name"]);
            Assert.AreEqual(ex.Entered, ex["Entered"]);
        }

        [TestMethod]
        public void DynamicAccessToPropertyTest()
        {
            // Set standard properties
            var ex = new ExpandoInstance();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            // turn into dynamic
            dynamic exd = ex;

            // Dynamic can access 
            Assert.AreEqual(ex.Name, exd.Name);
            Assert.AreEqual(ex.Entered, exd.Entered);

        }

        [TestMethod]
        public void IterateOverDynamicPropertiesTest()
        {
            var ex = new ExpandoInstance();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            dynamic exd = ex;
            exd.Company = "Exclr8";
            exd.Accesses = 10;

            // Dictionary pseudo implementation
            ex["Count"] = 10;
            ex["Type"] = "NEWAPP";

            // Dictionary Count - 2 dynamic props added
            Assert.IsTrue(ex.Properties.Count == 4);

            // iterate over all properties
            foreach (KeyValuePair<string, object> prop in exd.GetProperties(true))
            {
                Console.WriteLine(prop.Key + " " + prop.Value);
            }
        }




        [TestMethod]
        public void JsonSerializeTest()
        {
            var ex = new ExpandoInstance();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            string address = "64 Atlantic Beach Drive";

            ex["Address"] = address;
            ex["Contacted"] = true;

            dynamic exd = ex;
            exd.Count = 10;
            exd.Completed = DateTime.Now.AddHours(2);


           
            Console.WriteLine("*** Serialized Native object:");
            Console.WriteLine(Core.Utilities.Serialization.SerializeObjectToJson(ex));
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("*** Serialized Dynamic object:");
            Console.WriteLine(Core.Utilities.Serialization.SerializeObjectToJson(exd));
            Console.WriteLine();
        }

        [TestMethod]
        public void XmlSerializeTest()
        {
            var ex = new ExpandoInstance();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            string address = "64 Atlantic Beach Drive";

            ex["Address"] = address;
            ex["Contacted"] = true;

            dynamic exd = ex;
            exd.Count = 10;
            exd.Completed = DateTime.Now.AddHours(2);

            string xml;
            Core.Utilities.Serialization.SerializeObject(ex, out xml);

            Console.WriteLine(xml);

            ExpandoInstance ex2 = Core.Utilities.Serialization.DeSerializeObject(xml, typeof(ExpandoInstance)) as ExpandoInstance;

            Assert.IsNotNull(ex2);
            Assert.IsTrue(ex2["Address"] as string == address);
        }

        [TestMethod]
        public void ExpandoObjectJsonTest()
        {
            dynamic ex = new ExpandoObject();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            string address = "64 Atlantic Beach Drive";

            ex.Address = address;
            ex.Contacted = true;

            ex.Count = 10;
            ex.Completed = DateTime.Now.AddHours(2);


            string json = Core.Utilities.Serialization.SerializeObjectToJson(ex);

            Console.WriteLine(json);
        }

        [TestMethod]
        public void ExpandoObjectXmlTest()
        {
            dynamic ex = new Expando();
            ex.Name = "Alex";
            ex.Entered = DateTime.Now;

            string address = "64 Atlantic Beach Drive";

            ex.Address = address;
            ex.Contacted = true;

            ex.Count = 10;
            ex.Completed = DateTime.Now.AddHours(2);

            string xml = null;
            Assert.IsTrue(Core.Utilities.Serialization.SerializeObject(ex as Expando, out xml, true));


            Console.WriteLine(xml);
        }

        public class NonExpandoClass
        {
            public string Name { get; set; }
            public int Age { get; set; }

        }

        [TestMethod]
        public void Class2ExpandoTest()
        {
            NonExpandoClass myNonExandoClass = new NonExpandoClass() { Name = "Mannetjie", Age = 86 };
            dynamic myExandoClass = new Expando(myNonExandoClass);
            myExandoClass.Snoop = "Snoopy";
            Assert.IsTrue(myExandoClass.Name == "Mannetjie");
            Assert.IsTrue(myExandoClass.Snoop == "Snoopy");


        }


        [TestMethod]
        public void JsonConverterTest()
        {
            NonExpandoClass myNonExandoClass = new NonExpandoClass() { Name = "Mannetjie", Age = 86 };
            var jsonValue = Core.Utilities.Serialization.SerializeObjectToJson(myNonExandoClass);
            Console.WriteLine(jsonValue);
            dynamic myExpando = Core.Utilities.Serialization.DeSerializeJsonToObject(jsonValue);
            Console.WriteLine(myExpando.Name);
            Console.WriteLine(myExpando.Age);
        }

        [TestMethod]
        public void UserExampleTest()
        {
            var user = new User();

            // Set strongly typed properties
            user.Email = "ahm@centacto.com";
            user.Password = "asd12345_ ";
            user.Name = "Alex";
            user.Active = true;

            // Now add dynamic properties
            dynamic duser = user;
            duser.Entered = DateTime.Now;
            duser.Accesses = 1;

            // you can also add dynamic props via indexer 
            user["NickName"] = "Alex";
            duser["WebSite"] = "http://www.frameworkone.co.za";

            // Access strong type through dynamic ref
            Assert.AreEqual(user.Name, duser.Name);

            // Access strong type through indexer 
            Assert.AreEqual(user.Password, user["Password"]);


            // access dyanmically added value through indexer
            Assert.AreEqual(duser.Entered, user["Entered"]);

            // access index added value through dynamic
            Assert.AreEqual(user["NickName"], duser.NickName);


            // loop through all properties dynamic AND strong type properties (true)
            foreach (var prop in user.GetProperties(true))
            {
                object val = prop.Value;
                if (val == null)
                    val = "null";

                Console.WriteLine(prop.Key + ": " + val.ToString());
            }
        }

        [TestMethod]
        public void ExpandoMixinTest()
        {
            // have Expando work on Addresses
            var user = new User(new Address());

            // cast to dynamicAccessToPropertyTest
            dynamic duser = user;

            // Set strongly typed properties
            duser.Email = "ahm@centacto.com";
            user.Password = "nonya123";

            // Set properties on address object
            duser.Address = "64 Atlantic Beach Drive";
            //duser.Phone = "808-123-2131";

            // set dynamic properties
            duser.NonExistantProperty = "This works too";

            // shows default value Address.Phone value
            Console.WriteLine(duser.Phone);
        }
    }

    [Serializable]
    public class ExpandoInstance : Expando
    {
        public string Name { get; set; }
        public DateTime Entered { get; set; }


        public ExpandoInstance() { }

        /// <summary>
        /// Allow passing in of an instance
        /// </summary>
        /// <param name="instance"></param>
        public ExpandoInstance(object instance)
            : base(instance)
        { }
    }



    [Serializable]
    public class Address
    {
        public string FullAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Address()
        {
            FullAddress = "64 Atlantic Beach Drive";
            Phone = "082 MY NUMBER";
            Email = "ahm@centacto.com";
        }
    }

    public class User : Expando
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime? ExpiresOn { get; set; }

        public User()
            : base()
        { }

        // only required if you want to mix in seperate instance
        public User(object instance)
            : base(instance)
        {
        }
    }
}
