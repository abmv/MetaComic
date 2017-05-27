//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//namespace MetaComics.Client.Code.Utils
//{
//    class FeedFetchStatsController
//    {
//    }
//}

# region Namespaces

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using MetaComics.Client.Code;

# endregion

namespace EmployessInformation
{
    public class Controller
    {
        #region Member Variables

        //private FrmFeedFetchStatsInfo _parent = null;
        private static string _XsdName = "../../XSDService/FeedFetchStatsListSchema.xsd";
        private static string _fileName = "FeedFetchStats.xml";
        public bool _Success;

        # endregion

        #region Common Methods

        /// <summary>
        /// Setting property of Parent form
        /// </summary>
        //public FrmFeedFetchStatsInfo Parent
        //{
        //    set { _parent = value; }
        //}
        /// Deserialization XML string to object using XML Schema(FeedFetchStatsListSchema.xsd) 
        /// and FeedFetchStatsList.cs file.
        /// </summary>
        /// <param name="xmlBuffer"></param>
        /// <returns>object</returns>
        public static object DeserializeToObject(string xmlBuffer)
        {
            FeedFetchStatsList objFeedFetchStat = null;
            try
            {
                using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlBuffer)))
                {
                    var xml = new XmlSerializer(typeof (FeedFetchStatsList));
                    var reader = new XmlTextReader(memStream);
                    object newObj = xml.Deserialize(reader);
                    objFeedFetchStat = newObj as FeedFetchStatsList;
                }
            }
            catch
            {
                return null;
            }
            return objFeedFetchStat;
        }

        /// <summary>
        /// Serialization of object to XML using XML Schema(FeedFetchStatsListSchema.xsd),
        /// FeedFetchStatsList.cs,FeedFetchStatsListCollecion.cs file.
        /// </summary>
        /// <param name="objFeedFetchStats"></param>
        /// <param name="nodetype"></param>
        /// <returns>status</returns>
        public static bool SerializeToXml(object value, Type node)
        {
            try
            {
                TextWriter writer = new StreamWriter(_fileName);
                var serializer = new XmlSerializer(node);
                serializer.Serialize(writer, value);
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validating XML via XML Schema(FeedFetchStatsListSchema.xsd)
        /// </summary>
        /// <param name="xmlBuffer"></param>
        /// <returns>status</returns>
        public bool ValidationXml(string xmlBuffer)
        {
            bool success = true;
            if (xmlBuffer != string.Empty)
            {
                XmlValidatingReader xmlValidationReader = null;
                var schemaCollection = new XmlSchemaCollection();
                try
                {
                    var context = new XmlParserContext(null, null, string.Empty, XmlSpace.None);
                    xmlValidationReader = new XmlValidatingReader(xmlBuffer, XmlNodeType.Element, context);
                    schemaCollection.Add(string.Empty, _XsdName);
                    xmlValidationReader.ValidationType = ValidationType.Schema;
                    xmlValidationReader.Schemas.Add(schemaCollection);
                    while (xmlValidationReader.Read())
                    {
                        success = true;
                    }
                }
                catch (XmlException XmlExp)
                {
                    MessageBox.Show("Incorrect XML, " + XmlExp.Message,
                                    "FeedFetchStats Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
                catch (XmlSchemaException XmlSchExp)
                {
                    MessageBox.Show("Incorrect XML, " + XmlSchExp.Message,
                                    "FeedFetchStats Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
                catch (Exception GenExp)
                {
                    MessageBox.Show("Incorrect XML, " + GenExp.Message,
                                    "FeedFetchStats Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
            }
            return success;
        }

        #endregion

        #region UI and FeedFetchStats.xml Communication Methods

        /// <summary>
        /// Get FeedFetchStats information from FeedFetchStats.xml file as string of XML
        /// </summary>
        /// <returns>xmlstring</returns>
        public string GetFeedFetchStatsInformation()
        {
            string xmlBuffer = string.Empty;
            try
            {
                var sr = new StreamReader(_fileName);
                xmlBuffer = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                xmlBuffer = string.Empty;
            }
            return xmlBuffer;
        }

        /// <summary>
        /// Deleting selected FeedFetchStat's information from FeedFetchStats.xml file
        /// </summary>
        /// <returns>_status</returns>
        public bool DeleteFeedFetchStatInformation()
        {
            FeedFetchStatsList objFeedFetchStat = null;
            bool _status = false;
            string xmlBuffer = GetFeedFetchStatsInformation();
            if (xmlBuffer != null && xmlBuffer != string.Empty)
            {
                //Validating xmlBuffer string 
                _Success = ValidationXml(xmlBuffer);
                if (!_Success)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        //Deserializing XML string to object
                        objFeedFetchStat = (FeedFetchStatsList)
                                           DeserializeToObject(xmlBuffer);
                        if (objFeedFetchStat != null)
                        {
                            var InstCollec = new FeedFetchStatCollection();
                            int Length = objFeedFetchStat.FeedFetchStats.Length;
                            if (Length > 1)
                            {
                                for (int i = 0; i < Length; i++)
                                {
                                    FeedFetchStatsList.FeedFetchStat inst = objFeedFetchStat.FeedFetchStats[i];
                                    //if (i == _parent.SelectedFeedFetchStatIndex)
                                    //{
                                    //    // If Array index is equal to selected FeedFetchStat index
                                    //    //then deleting from array
                                    //    InstCollec.Delete(inst);
                                    //}
                                    //else
                                    //{
                                    //    //if Array index not equal to seleted FeedFetchStat index
                                    //    //then add into array
                                    //    InstCollec.Add(inst);
                                    //}
                                }
                                //Serialization of object to xml, and updating into FeedFetchStats.xml file.
                                _status = SerializeToXml(InstCollec, InstCollec.GetType());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        _status = false;
                    }
                }
            }
            else
            {
                return false;
            }
            return _status;
        }

        /// <summary>
        /// Updating selected FeedFetchStat's information into FeedFetchStats.xml file
        /// </summary>
        /// <returns>_status</returns>
        //public bool UpdateFeedFetchStatInformation()
        //{
        //    FeedFetchStatsList objFeedFetchStat = null;
        //    bool _status = false;
        //    string xmlBuffer = GetFeedFetchStatsInformation();
        //    if (xmlBuffer != null && xmlBuffer != string.Empty)
        //    {
        //        _Success = ValidationXml(xmlBuffer);
        //        if (!_Success)
        //        {
        //            _status = false;
        //        }
        //        else
        //        {
        //            FeedFetchStatsList.FeedFetchStat instNew = new FeedFetchStatsList.FeedFetchStat(_parent.txtEmpFirstName.Text, _parent.txtEmpLastName.Text,
        //             _parent.txtEmpAddress1.Text, _parent.txtEmpAddress2.Text, _parent.txtEmpCity.Text,
        //             _parent.txtEmpState.Text, _parent.txtEmpCountry.Text, _parent.txtEmpZip.Text,
        //             _parent.txtEmpHomePhone.Text, _parent.txtEmpWorkPhone.Text);
        //            try
        //            {
        //                objFeedFetchStat = (FeedFetchStatsList)DeserializeToObject(xmlBuffer);
        //                if (objFeedFetchStat != null)
        //                {
        //                    FeedFetchStatCollection InstCollec = new FeedFetchStatCollection();
        //                    int Length = objFeedFetchStat.FeedFetchStats.Length;
        //                    for (int i = 0; i < Length; i++)
        //                    {
        //                        FeedFetchStatsList.FeedFetchStat inst = (FeedFetchStatsList.FeedFetchStat)objFeedFetchStat.FeedFetchStats[i];
        //                        if (i == _parent.SelectedFeedFetchStatIndex)
        //                        {
        //                            // If Array index is equal to selected FeedFetchStat index
        //                            //then updating FeedFetchStat 
        //                            InstCollec.Update(i, instNew);
        //                        }
        //                        else
        //                        {
        //                            InstCollec.Add(inst);
        //                        }
        //                    }
        //                    _status = SerializeToXml(InstCollec, InstCollec.GetType());
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //                _status = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    return _status;
        //}
        /// <summary>
        /// Adding new FeedFetchStat's information into FeedFetchStats.xml file
        /// </summary>
        /// <returns>_status</returns>
        //public bool AddNewFeedFetchStatInformation()
        //{
        //   FeedFetchStatsList objFeedFetchStat = null;
        //    bool _status = false;
        //    string xmlBuffer = string.Empty;
        //    xmlBuffer = GetFeedFetchStatsInformation();
        //    FeedFetchStatCollection InstCollec = new FeedFetchStatCollection();
        //    FeedFetchStatsList.FeedFetchStat instNew = new FeedFetchStatsList.FeedFetchStat(_parent.txtEmpFirstName.Text, _parent.txtEmpLastName.Text,
        //        _parent.txtEmpAddress1.Text, _parent.txtEmpAddress2.Text, _parent.txtEmpCity.Text, _parent.txtEmpState.Text,
        //     _parent.txtEmpCountry.Text, _parent.txtEmpZip.Text, _parent.txtEmpHomePhone.Text,
        //      _parent.txtEmpWorkPhone.Text);
        //        if (xmlBuffer != null && xmlBuffer != string.Empty)
        //        {
        //            _Success = ValidationXml(xmlBuffer);
        //            if (_Success)
        //            {
        //                try
        //                {
        //                    objFeedFetchStat = (FeedFetchStatsList)DeserializeToObject(xmlBuffer);
        //                    if (objFeedFetchStat != null)
        //                    {
        //                        int Length = objFeedFetchStat.FeedFetchStats.Length;
        //                        for (int i = 0; i < Length; i++)
        //                        {
        //                            FeedFetchStatsList.FeedFetchStat inst = (FeedFetchStatsList.FeedFetchStat)objFeedFetchStat.FeedFetchStats[i];
        //                            InstCollec.Add(inst);
        //                        }
        //                        // adding new FeedFetchStat's information 
        //                        InstCollec.Add(instNew);
        //                        //Serializing to XML
        //                        _status = SerializeToXml(InstCollec, InstCollec.GetType());
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message);
        //                    _status = false;
        //                }
        //            }
        //            else
        //            {
        //                _status= false;
        //            }
        //        }
        //        else
        //        {
        //            InstCollec.Add(instNew);
        //            _status = SerializeToXml(InstCollec, InstCollec.GetType());
        //        }
        //        return _status;
        //}

        # endregion
    }
}