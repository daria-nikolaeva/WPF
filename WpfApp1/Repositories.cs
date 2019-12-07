using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WpfApp1
{
    class Repositories
    {
        public delegate void CollectionCengedEventHandler(ArrayList phones);
        public event CollectionCengedEventHandler CollectionCanged;

      


       private ArrayList phones = new ArrayList();
    
        


        public void Add(Phone phone)
        {
            phones.Add(phone);
            CollectionCanged?.Invoke(phones);
        }
        public void RemoveAt(int index)
        {
            if (index >= 0)
            {
                phones.RemoveAt(index);
                CollectionCanged?.Invoke(phones);
            }
           
        }
        public bool tryGetAt(int index, out Phone phone)
        {
            if (index >= 0 && index<phones.Count)
            {
                phone = phones[index] as Phone;
                return true;
            }
            phone = null;
            return false;
        }

        public ArrayList getPhones()
        {
            return phones;
        }
       

        public void SaveToXML(string path)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Async = false;
            using(StreamWriter streamWriter=new StreamWriter(path))
            {
                using (XmlWriter xml = XmlWriter.Create(streamWriter,xmlWriterSettings))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("PhoneList");

                         xml.WriteStartElement("Phones");
                    for(int i = 0; i < phones.Count; i++)
                    {
                        Phone phone = phones[i] as Phone;

                        xml.WriteStartElement("Phone");
                        xml.WriteAttributeString("Name", phone.Name);
                        xml.WriteAttributeString("Count", phone.Count.ToString());
                        xml.WriteAttributeString("Cost", phone.Cost.ToString());
                        xml.WriteAttributeString("Image", phone.Image);

                        xml.WriteEndElement();
                    }
                   
                    xml.WriteEndElement();
                    xml.WriteStartElement("PhonesCount");
                    xml.WriteAttributeString("TotalCount", phones.Count.ToString());
                    xml.WriteEndElement();
                    xml.WriteEndElement();
                }
            }
           
        }
        public void LoadXML(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlElement xRoot = xml.DocumentElement;
            XmlElement xmlPhones = xRoot.GetElementsByTagName("Phones")[0] as XmlElement;
            foreach (XmlElement xmlPhone in xmlPhones.ChildNodes)
            {
                this.phones.Add(new Phone(xmlPhone));
            }
            
        }
    }
}
