using System;
using System.Collections.Concurrent;
using DTO;
using NationalInstruments;
using NationalInstruments.DAQmx;

namespace DAL
{
    public class AsyncDAQ
    {
        private readonly ConcurrentQueue<Datacontainer> _datacontainer;
        private readonly int numberOfReadings = 1000;
        private AsyncCallback analogCallback;
        private AnalogMultiChannelReader analogInReader;
        private AnalogWaveform<double>[] data;
        private Task myTask;
        private Task runningTask;

        public AsyncDAQ(ConcurrentQueue<Datacontainer> datacontainer)
        {
            _datacontainer = datacontainer;
        }

        public void InitiateAsyncDaq()
        {
            if (runningTask == null)
                try
                {
                    // Create a new task
                    myTask = new Task();

                    // Create a virtual channel
                    myTask.AIChannels.CreateVoltageChannel("Dev1/ai0", "",
                        (AITerminalConfiguration) (-1), 0, 5, AIVoltageUnits.Volts);

                    // Configure the timing parameters
                    myTask.Timing.ConfigureSampleClock("", 1000, // 1000 = frekvensen der læses med i hz
                        SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples,
                        numberOfReadings); // 500 = antal samples per læsning

                    // Verify the Task
                    myTask.Control(TaskAction.Verify);

                    runningTask = myTask;
                    analogInReader = new AnalogMultiChannelReader(myTask.Stream);
                    analogCallback = AnalogInCallback;

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
                    var measurementDatacontainer = new Datacontainer();
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