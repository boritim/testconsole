using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;

namespace ItisDeBestTests
{
    [TestFixture]
    public class GroupTests : AuthBase
    {
        public static IEnumerable<AddressData> AddressDataFromXmlFile()
        {
            return (List<AddressData>) new XmlSerializer(typeof(List<AddressData>))
                .Deserialize(new StreamReader(@"D:/AutoTestHomework/Generator/bin/Release/address.xml"));
        }

        [Test, TestCaseSource("AddressDataFromXmlFile"), Order(1)]
        public void AddingToGroup(AddressData address)
        {
            app.Navigation.OpenAddresses();
            app.Group.AddNewAddress(address);
            app.Group.SelectLastCreatedGroup();
            AddressData newGroup = app.Group.GetCreatedGroupDate();
            Assert.AreEqual(address.FirstName, newGroup.FirstName);
            Assert.AreEqual(address.LastName, newGroup.LastName);
            Assert.AreEqual(address.Address, newGroup.Address);
            Assert.AreEqual(address.City, newGroup.City);
            Assert.AreEqual(address.State, newGroup.State);
            Assert.AreEqual(address.PostCode, newGroup.PostCode);
            Assert.AreEqual(address.Country, newGroup.Country);
            Assert.AreEqual(address.MobileNumber, newGroup.MobileNumber);
            Assert.AreEqual(address.Title, newGroup.Title);
        }

        [Test, Order(2)]
        public void UpdateGroup()
        {
            app.Navigation.OpenAddresses();
            AddressData updateAddressData = new AddressData()
            {
                Address = "ITIS One love", City = "Niggeria", State = 5,
                PostCode = "31953", MobileNumber = "79127145885"
            };
            app.Group.UpdateAddress(updateAddressData);
        }

        [Test, Order(3)]
        public void DeleteGroup()
        {
            app.Navigation.OpenAddresses();
            app.Group.DeleteCreatedGroup();
        }
    }
}
