using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace USB_Reader
{
    /**
     *  This section contains all of our essentials to run and construct the algorithm to compensate
     *  for false motion and extract real walking motion.
     */
    class pedometer_algorithm
    {
        public int[] m_accel_raw_data;
        public int[] m_angle_data;

        bool m_devStatus;

        CMPS10_INTERFACE m_compass_interface;

        //Constructor
        public pedometer_algorithm(CMPS10_INTERFACE cmp)
        {
            m_compass_interface = cmp;
            m_devStatus = cmp.connected;
            if (!m_devStatus)
            {
                isRunning = false;
            }

            m_accel_raw_data = new int [3];
            m_angle_data = new int[3];
        }

        /**
         *  This section contains core functions to the algorithms which we will be using to calculate the number
         *  of steps and distance travelled
         **/

        //////STEP ALGORITHM VARIABLES
        //These values here should really be private for good practice, but I've set them to
        //be public to make testing easier
        #region algorithm variables
        uint stepflag, initflag;
        bool isRunning;
        public int i, cycle_count, total_samples, avgconst = 1, latency = 4, avglen = 8, steps, last_cycle;
        public float sum, newmax, newmin, oldavg, newavg, avgthresh = 1.0f;
        public float stride, avgstride;

        //NOTE:
        //The original algorithm used a fixed sized array which was reset when the cycle count reaches a certain point
        //This implementation uses a vector/list since the accelerometer data receieved isn't enough to trigger the clear
        //condition for the algorithm. This really should be fixed in the case of resource usage and efficiency.

        //public float[] accel_data = new float[50];
        public List<float> accel_data = new List<float> { };
        public float maxavg, minavg, accel_avg, velocity, displace, distance;
        public float walk_adjust = 0.0249f;
        public float total_accel;
        public float step_thresh = 100.0f;
        float speed = 1.0f;
        public int count = 0;
        public float sumValue;

        //Step flags we'll be using
        enum StepFlags
        {
            STEP_DOWN = 0,
            STEP_UP = 1,
            CHECK_STEP = 2
        };
        #endregion

        //Calculates steps taken by a person
        public void CalculateSteps(float dt)
        {
            //Note: Can we stick this in the constructor perhaps if it doesn't require a reset everytime we stop...
            if (initflag == 0)
            {
                InitAlgorithm();
            }

            //Initialise our variables
            //The running variable will be made toggable
            if (isRunning)
            {
                //The sliding boxcar average, constantly update our old average to our new average
                if (total_samples > 7)
                {
                    oldavg = newavg;
                    newavg -= accel_data.ElementAt(cycle_count - (avglen - 1));
                }

                //NOTE: This portion of the algorithm must be executed constantly to update and progress it
                //Get the accelerometer data
                m_accel_raw_data = Get_Accelerometer();

                //Now calculate the sum
                sum = (float)Math.Sqrt((m_accel_raw_data[0] * m_accel_raw_data[0] + m_accel_raw_data[1] * m_accel_raw_data[1]) / 16);

                //Add to stack
                accel_data.Add(sum);
                newavg += sum;

                //Check the old vs new average
                if (Math.Abs(newavg - oldavg) < avgthresh)
                {
                    newavg = oldavg;
                }

                if (sum > newmax)
                {
                    newmax = sum;
                }

                if (sum < newmin)
                {
                    newmin = sum;
                }

                cycle_count++;
                total_samples++;

                //Reset the counter, remove the old elements from the stack
                //This way, we can always ensure that we have 8 samples to use which are the latest
                //as we are pushing out the old values
                if (cycle_count > 8 && total_samples > 8)
                {
                    cycle_count = 8;
                    total_samples = 8;

                    //We use a list as a queue, FIFO. The original algorithm uses a fixed size array where it has conditions
                    //to revert the cycle back to 0 but we can't implement it here so we use a queue instead
                    //to keep the averages updated and manage resources
                    accel_data.RemoveAt(0);
                }

                //If we are here, then we have enough to use for our calculations
                if (total_samples >= 8)
                {
                    //If it is a step, perform the calculations needed
                    if (IsStep(newavg, oldavg))
                    {
                        //Find the average of the gathered points and calculate the total distance based on our average.
                        //NOTE: In theory the number of points should be related to how accurate our readings are. 
                        //Another note for the original algorithm is that it uses cycle_count - latency for the 4 latest points
                        //but if we took into 8 points would it still be as accurate as these points are considered from the past...?
                        for (i = latency; i < (cycle_count); i++)
                        {
                            accel_avg += accel_data[i];
                        }

                        accel_avg /= (latency);

                        //Calculate the velocity and displacement
                        for (i = latency; i < cycle_count; i++)
                        {
                            velocity += (accel_data[i] - accel_avg);
                            displace += velocity;
                        }

                        //calculate the length of our step
                        stride = displace * (newmax - newmin) / (accel_avg - newmin);
                        stride = (float)Math.Sqrt(Math.Abs(stride));

                        //Adjust the length
                        //NOTE: This will need to be adjusted according to real size depending on the device
                        stride *= walk_adjust;

                        //Take the averages of the step distances and make a value out of it to add to the total distance
                        if (steps < 2)
                        {
                            avgstride = stride;
                        }
                        else
                        {
                            avgstride = ((avgconst - 1) * avgstride + stride) / avgconst;
                        }

                        //Increment the steps
                        steps++;
                        distance += avgstride;

                        //Assign averages for re-use
                        for (i = 0; i < avglen; i++)
                        {
                            accel_data[i] = accel_data[cycle_count + i - avglen];
                        }

                        //Reset our values for next time
                        cycle_count = avglen;
                        newmax = -10000.0f;
                        newmin = 10000.0f;
                        maxavg = -10000.0f;
                        minavg = 10000.0f;
                        accel_avg = 0;
                        velocity = 0;
                        displace = 0;
                    }
                }
            }
        }

        //Initialise the algorithm above
        private void InitAlgorithm()
        {
            stepflag = (uint)StepFlags.CHECK_STEP;
            maxavg = -10000;
            minavg = 10000;
            newmax = -10000;
            newmin = 10000;
            oldavg = 0.0f;
            newavg = 0.0f;
            cycle_count = 0;
            total_samples = 0;
            steps = 0;
            distance = 0.0f;
            accel_avg = 0.0f;
            velocity = 0.0f;
            displace = 0.0f;
            avgstride = 0.0f;
            initflag = 1;
            isRunning = true;
        }

        //Check if step's incomplete amongst other things
        private bool IsStep(float avg, float oldavg)
        {
            //Start the algorithm by checking the flags
            if (stepflag == (uint)StepFlags.CHECK_STEP)
            {
                //Means we've stepped up
                if (avg > (oldavg + step_thresh))
                {
                    stepflag = (uint)StepFlags.STEP_UP;
                }

                //Means we've stepped down
                if (avg < (oldavg - step_thresh))
                {
                    stepflag = (uint)StepFlags.STEP_DOWN;
                }

                return false; //Exit the algorithm 
            }

            //If we are here, it means the person was moved up
            if (stepflag == (uint)StepFlags.STEP_UP)
            {
                //Means we've finished moving a step, increment the step count
                if ((maxavg > minavg) && (avg > ((maxavg + minavg) / 2)) && (oldavg < (maxavg + minavg / 2)))
                {
                    return true;
                }

                if (avg < (oldavg - step_thresh))
                {
                    stepflag = (uint)StepFlags.STEP_DOWN;
                    if (oldavg > maxavg)
                    {
                        maxavg = oldavg;
                    }
                }
            }

            //If we are here, it means the person was moved down
            if (stepflag == (uint)StepFlags.STEP_DOWN)
            {
                //The person has begun moving up again
                if (avg > (oldavg + step_thresh))
                {
                    stepflag = (uint)StepFlags.STEP_UP;
                    if (oldavg < minavg)
                    {
                        minavg = oldavg;
                    }
                }

                return false;
            }
            return false;
        }

        //Read accelerometer data and return them as values
        private int[] Get_Accelerometer()
        {
            string[] data = m_compass_interface.GetAcceleration();
            int[] data_convert = new int[3];

            data_convert[0] = (Convert.ToInt16(data[2]));
            data_convert[1] = (Convert.ToInt16(data[5]));
            data_convert[2] = (Convert.ToInt16(data[8]));

            return data_convert;
        }
    }
}
