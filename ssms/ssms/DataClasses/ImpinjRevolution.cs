using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impinj.OctaneSdk;
using System.ComponentModel;
using System.Collections;


namespace ssms.DataClasses
{
    public class ImpinjRevolution
    {

        ImpinjReader reader;
        public List<string> check = new List<string>();
        public event TagReader TagRead;
        public delegate void TagReader(TagInfo tag, EventArgs e);
        public string HostName { get; set; }
        public string Filter { get; set; }
        public List<LTS.Antenna> Antennas { get; set; }
        public int AntennaCount { get { if (Antennas != null) { return Antennas.Count; } else { return 0; } } }
        public ScanMode ReaderScanMode = ScanMode.FullScan;
        public bool isConnected = false;

        public ImpinjRevolution()
        {
            reader = new ImpinjReader();
        }

        public bool Connect()
        {
            // Connect to the reader.
            try
            {

                reader.Connect(HostName);

                Settings settings = reader.QueryDefaultSettings();
                settings.Report.IncludeAntennaPortNumber = true;
                
                // Set the reader mode, search mode and session
                settings.ReaderMode = ReaderMode.AutoSetDenseReader;     //AutoSetDenseReader;    //KM   DenseReaderM8;
                settings.SearchMode = SearchMode.DualTarget;
                settings.Session = 2;
                
                LowDutyCycleSettings ldc = new LowDutyCycleSettings();  //KM
                ldc.EmptyFieldTimeoutInMs = 1000;  //KM
                ldc.FieldPingIntervalInMs = 200;  //KM
                ldc.IsEnabled = true;  //KM
                settings.LowDutyCycle = ldc;  //KM


                
                settings.Antennas.DisableAll();
                for (ushort i = 0; i < Antennas.Count; i++)
                {
                    ushort x = Convert.ToUInt16(i + 1);
                    settings.Antennas.GetAntenna(x).IsEnabled = true;
                    settings.Antennas.GetAntenna(x).RxSensitivityInDbm = Convert.ToDouble(Antennas[i].RxPower);
                    settings.Antennas.GetAntenna(x).TxPowerInDbm = Convert.ToDouble(Antennas[i].TxPower);
                    settings.Antennas.GetAntenna(x).MaxRxSensitivity = true;
                    settings.Antennas.GetAntenna(x).MaxTransmitPower = true;
                    settings.Antennas.GetAntenna(x).PortNumber = x;

                }
                if (ReaderScanMode == ScanMode.FullScan)
                {
                    settings.ReaderMode = ReaderMode.AutoSetDenseReader;     //AutoSetDenseReader;    //KM   DenseReaderM8;
                    settings.SearchMode = SearchMode.DualTarget;

                }
                else
                {
                    settings.ReaderMode = ReaderMode.AutoSetDenseReader;     //AutoSetDenseReader;    //KM   DenseReaderM8;
                    settings.SearchMode = SearchMode.SingleTarget;
                }

                // Apply the newly modified settings.
                
                reader.ApplySettings(settings);
                reader.TagsReported += OnTagsReported;
                isConnected = true;

                return isConnected;

            }
            catch (Exception ex)
            {
                isConnected = false;
                return false;
            }
            finally
            {

            }
        }

        public bool Disconnect()
        {

            try
            {
                reader.TagsReported -= OnTagsReported;
                reader.Disconnect();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {

            }

        }

        public bool StartRead()
        {
            try
            {
                reader.Start();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        public bool StopRead()
        {
            try
            {
                reader.Stop();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            
            foreach (Tag tag in report)
            {
                TagInfo tagread = new TagInfo();
                tagread.AntennaNo = tag.AntennaPortNumber;
                tagread.TagNo = tag.Epc.ToString();
                tagread.ReaderHostName = HostName;
                TagRead(tagread, null);

                if (!check.Contains(tag.Epc.ToString()))  //add unique TIDs only
                {
                    if (tag.Epc.ToString() != "" && tag.Epc.ToString() != null)
                    {
                        check.Add(tag.Epc.ToString());
                        
                    }
                }

            }
        }



        ~ImpinjRevolution()
        {
            reader = null;
        }


    }

    public class TagInfo
    {
        public string TagNo { get; set; }

        public int AntennaNo { get; set; }
        public string ReaderHostName { get; set; }
        
        public TagInfo()
        {

        }
    }

    

    public enum ScanMode
    {
        ScanItem = 1,
        FullScan = 2
    }
}
