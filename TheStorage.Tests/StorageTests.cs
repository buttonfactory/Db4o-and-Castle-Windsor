using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TheStorage.Web.DataAccess;
using TheStorage.Model;
using Db4objects.Db4o;


using Db4objects.Db4o.CS;namespace TheStorage.Tests
{
    [TestFixture]
    public class UploadTest
    {
        [Test]
        public void Can_Retrieve_From_Database_With_Multiple_Clients()
        {

           Db4oRepository db = new Db4oRepository(
               Db4oClientServer.OpenClient(Db4oClientServer.NewClientConfiguration(),
                  "localhost", 4433, "db4o", "db4o"));
           
            Db4oRepository db2 = new Db4oRepository(
             Db4oClientServer.OpenClient(Db4oClientServer.NewClientConfiguration(),
                "localhost", 4433, "db4o", "db4o"));

                db.DeleteAll<Upload>();
                db2.DeleteAll<Upload>();
                  
                Upload u = new Upload { name = "presentation.ppt", description = "kick off demo" };
                Upload u2 = new Upload { name = "projectplan.doc", description = "timeline and outline project" };
                    
            db.Save(u);
            db2.Save(u2);
                
            db.CommitChanges();

                var test = db2.Single<Upload>(x => x.name == "presentation.ppt");
                StringAssert.Contains("pres", test.name);
            

        }
    }
}