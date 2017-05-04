using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AdamOneilSoftware
{
	public class SavedCredentials : IXmlSerializable
	{
		public string UserName { get; set; }
		public string Password { get; set; }		

		public void Save(string fileName)
		{
			string path = Path.GetDirectoryName(fileName);
			if (!Directory.Exists(path)) Directory.CreateDirectory(path);

			XmlSerializer xs = new XmlSerializer(typeof(SavedCredentials));						
			using (StreamWriter writer = File.CreateText(fileName))
			{
				xs.Serialize(writer, this);
				writer.Close();
			}
		}

		public static SavedCredentials Load(string fileName)
		{
			SavedCredentials result = null;
			XmlSerializer xs = new XmlSerializer(typeof(SavedCredentials));
			using (StreamReader reader = File.OpenText(fileName))
			{
				result = (SavedCredentials)xs.Deserialize(reader);
				reader.Close();
			}
			return result;
		}

		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(reader.ReadOuterXml());
			UserName = Encryption.Decrypt(doc.SelectSingleNode("/SavedCredentials/UserName").InnerText);
			Password = Encryption.Decrypt(doc.SelectSingleNode("/SavedCredentials/Password").InnerText);
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteElementString("UserName", Encryption.Encrypt(UserName));
			writer.WriteElementString("Password", Encryption.Encrypt(Password));
		}
	}
}
