using QuoteManager.Models.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace QuoteManager.Helpers
{
    public class XmlMethods
    {
        public string SanitizeXmlString(string xml)
        {
            if (xml == null)
            {
                throw new ArgumentNullException("xml");
            }

            StringBuilder buffer = new StringBuilder(xml.Length);

            foreach (char c in xml)
            {
                if (IsLegalXmlChar(c))
                {
                    buffer.Append(c);
                }
            }

            return buffer.ToString();
        }

        public bool IsLegalXmlChar(int character)
        {
            return
            (
                 character == 0x9 /* == '\t' == 9   */          ||
                 character == 0xA /* == '\n' == 10  */          ||
                 character == 0xD /* == '\r' == 13  */          ||
                (character >= 0x20 && character <= 0xD7FF) ||
                (character >= 0xE000 && character <= 0xFFFD) ||
                (character >= 0x10000 && character <= 0x10FFFF)
            );
        }

        public BvpnViewModel parseBvpnXmlData(string fileContent)
        {
            BvpnViewModel bvpn = new BvpnViewModel();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(fileContent);
            if (xmlDoc.HasChildNodes)
            {
                bvpn.LineItem = new List<BvpnViewModel.BvpnLineItem>();
                XmlNodeList quoteIdentification = xmlDoc.GetElementsByTagName("entry");
                foreach (XmlNode node in quoteIdentification)
                {
                    switch (node.ChildNodes[0].InnerText)
                    {
                        case "ScenarioId":
                            bvpn.scenarioId = node.ChildNodes[1].InnerText;
                            break;
                        case "ServiceCode":
                            bvpn.serviceCode = node.ChildNodes[1].InnerText;
                            break;
                        case "ApprovalID":
                            bvpn.approvalId = node.ChildNodes[1].InnerText;
                            break;
                        case "EndUserID":
                            bvpn.endUserId = Convert.ToInt32(node.ChildNodes[1].InnerText);
                            break;
                        case "EndUserName":
                            bvpn.endUserName = node.ChildNodes[1].InnerText;
                            break;
                        case "BidOwner":
                            bvpn.bidOwner = node.ChildNodes[1].InnerText;
                            break;
                        case "ContractTerm":
                            bvpn.contractTerm = node.ChildNodes[1].InnerText;
                            break;
                        case "Currency":
                            bvpn.currency = node.ChildNodes[1].InnerText;
                            break;
                        case "ExpiryDate":
                            if (node.ChildNodes[1].InnerText != "Null")
                            {
                                bvpn.expiryDate = Convert.ToDateTime(node.ChildNodes[1].InnerText);
                            }
                            break;
                    }
                }
                XmlNodeList quoteLineItem = xmlDoc.GetElementsByTagName("quote-line-item");
                if (quoteLineItem.Count != 0)
                {
                    foreach (XmlNode node in quoteLineItem)
                    {
                        StringBuilder sb = new StringBuilder();
                        var listItem = new List<BvpnViewModel.BvpnLineItem>();
                        
                        var item = new BvpnViewModel.BvpnLineItem();
                        foreach (XmlNode childNode in node)
                        {
                            switch (childNode.ChildNodes[0].InnerText)
                            {
                                case "site name":
                                    item.siteName = childNode.ChildNodes[1].InnerText;
                                    break;
                                case "Primary ISO Country":
                                    item.primaryISOCountry = childNode.ChildNodes[1].InnerText;
                                    break;
                                case "country":
                                    item.country = childNode.ChildNodes[1].InnerText;
                                    break;
                                case "total service bandwidth":
                                    item.bandwidth = childNode.ChildNodes[1].InnerText;
                                    break;
                                case "COS MRC":
                                    item.cosMRC = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;   
                                case "COS OTC":
                                    item.cosOTC = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;                                    
                                case "2nd COS MRC":
                                    item.secondCosMRC = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "2nd COS OTC":
                                    item.secondCosOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "total MRP":
                                    item.totalMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "total OTP":
                                    item.totalOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "SAM / Brick MRP":
                                    item.samBrickMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "SAM / Brick OTP":
                                    item.samBrickOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "PrimaryQuoteLMRP":
                                    item.primaryQuoteLMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary local loop MRP":
                                    item.primaryLocalLoopMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary local loop OTP":
                                    item.primaryLocalLoopOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "SecondaryQuoteLMRP":
                                    item.secondaryQuoteLMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "secondary local loop MRP":
                                    item.secondaryLocalLoopMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "secondary local loop OTP":
                                    item.secondaryLocalLoopOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "air quick start MRP":
                                    item.airQuickStartMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "air quick start OTP":
                                    item.airQuickStartOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "RT voice list MRP":
                                    item.rtVoiceListMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "RT video list MRP":
                                    item.rtVideoListMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "bus.talk list MRP":
                                    item.busTalkListMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "service MRP":
                                    item.serviceMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "telepresence connect MRP":
                                    item.telepresenceConnectMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "advanced features MRP":
                                    item.advancedFeaturesMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "continuity MRP":
                                    item.continuityMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "internet MRP":
                                    item.internetMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "service list OTP":
                                    item.serviceListOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "network site survey list OTP":
                                    item.networkSiteSurveyListOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "advanced features list OTP":
                                    item.advancedFeaturesListOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "continuity list OTP":
                                    item.continuityListOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "ONBH installation list OTP":
                                    item.ONBHInstallationListOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "internet list OTP":
                                    item.internetListOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "MRP relating to amortized OTP":
                                    item.mrpRelatingToAmortizedOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary_VPN_bandwidth_MRP":
                                    item.primaryVpnBandwidthMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "secondary_VPN_bandwidth_MRP":
                                    item.secondaryVpnBandwidthMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "primary_flexible_COS_MRP":
                                    item.primaryFlexibleCosMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "secondary_flexible_COS_MRP":
                                    item.secondaryFlexibleCosMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary_RT_premium_MRP":
                                    item.primaryRtPremiumMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "secondary_RT_premium_MRP":
                                    item.secondaryRtPremiumMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary_virtual_plug_MRP":
                                    item.primaryVirtualPlugMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "secondary_virtual_plug_MRP":
                                    item.secondaryVirtualPlugMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary_virtual_plug_OTP":
                                    item.primaryVirtualPlugOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "secondary_virtual_plug_OTP":
                                    item.secondaryVirtualPlugOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary_valuenet_forced_MRP":
                                    item.primaryValuenetForcedMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary_and_secondary_cascaded_RT_OTP":
                                    item.primaryAndSecondaryCascadedRTOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary_VR_customer_care_MRP":
                                    item.primaryVrCustomerCareMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                                case "primary_internet_usage_MRP":
                                    item.primaryInternetUsageMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "secondary_internet_usage_MRP":
                                    item.secondaryInternetUsageMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "primary_and_secondary_internet_usage_OTP":
                                    item.primaryAndSecondaryInternetUsageOTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "cascaded_1_MRP":
                                    item.cascaded1MRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "CPE_1_hardware_MRP":
                                    item.cpe1HardwareMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "total_cascaded_1_MRP":
                                    item.totalCascaded1MRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "cascaded_installation_1_OTP":
                                    item.cascadedInstallation1OTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "cascaded_2_MRP":
                                    item.cascaded2MRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "CPE_2_hardware_MRP":
                                    item.cpe2HardwareMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "total_cascaded_2_MRP":
                                    item.totalCascaded2MRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "cascaded_installation_2_OTP":
                                    item.cascadedInstallation2OTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "cascaded_3_MRP":
                                    item.cascaded3MRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "CPE_3_hardware_MRP":
                                    item.cpe3HardwareMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "total_cascaded_3_MRP":
                                    item.totalCascaded3MRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "cascaded_installation_3_OTP":
                                    item.cascadedInstallation3OTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "cascaded_4_MRP":
                                    item.cascaded4MRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "CPE_4_hardware_MRP":
                                    item.cpe4hardwareMRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "total_cascaded_4_MRP":
                                    item.totalCascaded4MRP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;
                                case "cascaded_installation_4_OTP":
                                    item.cascadedInstallation4OTP = float.Parse((childNode.ChildNodes[1].InnerText));
                                    break;

                            }
                            switch (childNode.Name)
                            {
                                case "quote-parameter":
                                    sb.Append(childNode["name"].InnerText + ":" + childNode["value"].InnerText).Append("~");
                                    break;
                                case "quote-cost-element":
                                    sb.Append(childNode["name"].InnerText + ":" + childNode["amount"].InnerText).Append("~");
                                    break;

                            }
                        }
                        item.lineData = sb.ToString();
                        listItem.Add(item);
                        
                        bvpn.LineItem.AddRange(listItem);
                    }

                }

            }
            return bvpn;
        }
    }
}