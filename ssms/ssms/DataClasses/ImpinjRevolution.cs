using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impinj.OctaneSdk;
using System.ComponentModel;
using System.Collections;

namespace PortalTest.Classes
{
    public class ImpinjRevolution 
    {

        ImpinjReader reader;
        public event TagReader TagRead;
        public delegate void TagReader(TagInfo tag, EventArgs e);
        public string HostName { get; set; }
        public string Filter { get; set; }
        //public List<Antenna> Antennas { get; set; }
       // public int AntennaCount { get { if (Antennas!=null) { return Antennas.Count; } else { return 0; } } }
       
        public bool isConnected = false;

        public ImpinjRevolution()
        {
            reader = new ImpinjReader();
        }

        public void Connect()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
 
        
        }



        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Connect to the reader.
            // Change the ReaderHostname constant in SolutionConstants.cs 
            // to the IP address or hostname of your reader.
            try
            {

                reader.Connect(HostName);

                // Get the default settings
                // We'll use these as a starting point
                // and then modify the settings we're 
                // interested in.
                Settings settings = reader.QueryDefaultSettings();

                // Tell the reader to include the antenna number
                // in all tag reports. Other fields can be added
                // to the reports in the same way by setting the 
                // appropriate Report.IncludeXXXXXXX property.
                settings.Report.IncludeAntennaPortNumber = true;
                

                // Set the reader mode, search mode and session
                settings.ReaderMode = ReaderMode.DenseReaderM8;     //AutoSetDenseReader;    //KM   DenseReaderM8;
                settings.SearchMode = SearchMode.DualTarget;
                //settings.Session = 2;
                //settings.Report.IncludeFastId = true;  //KM
                //settings.TagPopulationEstimate = 1;  //KM

                LowDutyCycleSettings ldc = new LowDutyCycleSettings();  //KM
                ldc.EmptyFieldTimeoutInMs = 1000;  //KM
                ldc.FieldPingIntervalInMs = 200;  //KM
                ldc.IsEnabled = true;  //KM
                settings.LowDutyCycle = ldc;  //KM

                // Enable antenna #1. Disable all others.
                settings.Antennas.DisableAll();
                //for (ushort i = 0; i < Antennas.Count; i++)
                //{
                //    settings.Antennas.GetAntenna(Antennas[i].Port).IsEnabled = Antennas[i].Enabled;
                //    settings.Antennas.GetAntenna(Antennas[i].Port).RxSensitivityInDbm = Antennas[i].RXStrength;
                //    // Set the Transmit Power and 
                //    // Receive Sensitivity to the maximum.
                //    // You can also set them to specific values like this...
                //    settings.Antennas.GetAntenna(Antennas[i].Port).TxPowerInDbm = Antennas[i].TXStrength;
                //    settings.Antennas.GetAntenna(Antennas[i].Port).MaxRxSensitivity = false;
                //    settings.Antennas.GetAntenna(Antennas[i].Port).MaxTransmitPower = false;
                //    settings.Antennas.GetAntenna(Antennas[i].Port).PortNumber = Antennas[i].Port;

                   

                //    //settings.Antennas.GetAntenna(1).RxSensitivityInDbm = -70;
                //}
                // Apply the newly modified settings.
                settings.Report.IncludePeakRssi = true;
                
                

                if (Filter != "" && Filter != null)
                {

                    settings.Filters.Mode = TagFilterMode.OnlyFilter1;
                    settings.Filters.TagFilter1.MemoryBank = MemoryBank.Epc;

                    settings.Filters.TagFilter1.BitPointer = BitPointers.Epc;
                    //settings.Filters.TagFilter1.TagMask = Filter;
              
                }
                reader.ApplySettings(settings);
                reader.TagsReported += OnTagsReported;
                isConnected = true;
               
            }
            catch (Exception ex)
            {
                isConnected = false;
            }
            finally
            {

            }
        }

        public bool Disconnect()
        {
          
            try
            {
                reader.Disconnect();
          
                return true;
            }catch(Exception ex)
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
            catch(Exception ex )
            {
                return false;
            }
        }

         void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            // This event handler is called asynchronously 
            // when tag reports are available.
            // Loop through each tag in the report 
            // and print the data.
            
            foreach (Tag tag in report)
            {
                TagInfo tagread = new TagInfo();
                tagread.AntennaNo = tag.AntennaPortNumber;
                tagread.TagNo = tag.Epc.ToString();
                tagread.ReaderHostName = HostName;
                tagread.PeakRSSI = tag.PeakRssiInDbm;
                TagRead(tagread, null);
                //tag.AntennaPortNumber
                //tag.Epc;
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
        public double PeakRSSI { get; set; }
        public int Segment { get; set; }
        public TagInfo()
        {

        }
    }

    public class BestTags : IList<TagInfo>
    {
        private readonly IList<TagInfo> besttags = new List<TagInfo>();
public IEnumerator<TagInfo> GetEnumerator()
    {
        return besttags.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

 

    #region Implementation of ICollection<T>

    public void Add(TagInfo item)
    {
        besttags.Add(item);
    }

    public void Clear()
    {
        besttags.Clear();
    }

    public bool Contains(TagInfo item)
    {
        return besttags.Contains(item);
    }

    public void CopyTo(TagInfo[] array, int arrayIndex)
    {
        besttags.CopyTo(array, arrayIndex);
    }

    public bool Remove(TagInfo item)
    {
        return besttags.Remove(item);
    }

    public int Count
    {
        get { return besttags.Count; }
    }

    public bool IsReadOnly
    {
        get { return besttags.IsReadOnly; }
    }

    #endregion

    #region Implementation of IList<T>

    public int IndexOf(TagInfo item)
    {
        return besttags.IndexOf(item);
    }

    public void Insert(int index, TagInfo item)
    {
        besttags.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        besttags.RemoveAt(index);
    }

    public TagInfo this[int index]
    {
        get { return besttags[index]; }
        set { besttags[index] = value; }
    }

    #endregion

    #region Your Added Stuff

    // Add new features to your collection.

    #endregion
    
    }
}
