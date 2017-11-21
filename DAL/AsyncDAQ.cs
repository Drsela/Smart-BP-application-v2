using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using NationalInstruments.DAQmx;
using NationalInstruments;

namespace DAL
{
    public class AsyncDAQ
    {
        private AnalogMultiChannelReader analogInReader;
        private NationalInstruments.DAQmx.Task myTask;
        private NationalInstruments.DAQmx.Task runningTask;
        private AsyncCallback analogCallback;
        private AnalogWaveform<double>[] data;
        private readonly ConcurrentQueue<Datacontainer> _datacontainer;
        private int numberOfReadings = 500;

        public AsyncDAQ(ConcurrentQueue<Datacontainer> datacontainer)
        {
            _datacontainer = datacontainer;
        }
        public void InitiateAsyncDaq()
        {
            if (runningTask == null)
            {
                try
                {
                    // Create a new task
                    myTask = new NationalInstruments.DAQmx.Task();

                    // Create a virtual channel
                    myTask.AIChannels.CreateVoltageChannel("Dev1/ai0", "",
                        (AITerminalConfiguration)(-1), 0, 5, AIVoltageUnits.Volts);

                    // Configure the timing parameters
                    myTask.Timing.ConfigureSampleClock("", 1000, // 1000 = frekvensen der læses med i hz
                        SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, numberOfReadings); // 100 = antal samples per læsning

                    // Verify the Task
                    myTask.Control(TaskAction.Verify);

                    runningTask = myTask;
                    analogInReader = new AnalogMultiChannelReader(myTask.Stream);
                    analogCallback = new AsyncCallback(AnalogInCallback);

                    // Use SynchronizeCallbacks to specify that the object 
                    // marshals callbacks across threads appropriately.
                    analogInReader.SynchronizeCallbacks = true;
                    analogInReader.BeginReadWaveform(numberOfReadings, analogCallback, myTask);
                }
                catch (DaqException exception)
                {
                    // Display Errors
                    runningTask = null;
                    myTask.Dispose();
                }
            }
        }

        public void StopMeasurement()
        {
            if (runningTask != null)
            {
                // Dispose of the task
                runningTask = null;
                myTask.Dispose();
            }
        }

        private void AnalogInCallback(IAsyncResult ar)
        {
            try
            {
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                    // Read the available data from the channels
                    data = analogInReader.EndReadWaveform(ar);

                    //DataToDataList(data);
                    Datacontainer measurementDatacontainer= new Datacontainer();
                    measurementDatacontainer.SetRawDataSample(data);
                    _datacontainer.Enqueue(measurementDatacontainer); //Consumer producer patteren

                    analogInReader.BeginMemoryOptimizedReadWaveform(numberOfReadings, analogCallback, myTask, data);
                }
            }
            catch (DaqException exception)
            {
                // Display Errors
                runningTask = null;
                myTask.Dispose();
            }
        }
    }
}