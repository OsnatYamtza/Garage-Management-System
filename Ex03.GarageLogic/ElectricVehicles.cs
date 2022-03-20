using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicles : Vehicle
    {
        private readonly float r_BatteryMaxTime;
        private float m_BatteryLeftTime;

        public ElectricVehicles(float i_BatteryLeftTime, float i_BatteryMaxTime, string i_Model, string i_LicenseNumber, float i_LeftedEnergyPrecent)
    : base(i_Model, i_LicenseNumber, i_LeftedEnergyPrecent)
        {
            if (i_BatteryLeftTime < i_BatteryMaxTime)
            {
                m_BatteryLeftTime = i_BatteryLeftTime;
                r_BatteryMaxTime = i_BatteryMaxTime;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    i_BatteryMaxTime,
                    0,
                    string.Format("Battery time {0} exceeds max battery time {1}!", i_BatteryLeftTime, i_BatteryMaxTime));
            }
        }

        public float BatteryLeftTime
        {
            get
            {
                return m_BatteryLeftTime;
            }

            set
            {
                m_BatteryLeftTime = value;
            }
        }

        public float BatteryMaxTime
        {
            get
            {
                return r_BatteryMaxTime;
            }
        }

        public void BatteryCharge(float i_HoursToAdd)
        {
            if (m_BatteryLeftTime + i_HoursToAdd <= r_BatteryMaxTime)
            {
                m_BatteryLeftTime += i_HoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    r_BatteryMaxTime,
                    0,
                    string.Format("Battery time {0} exceeds max battery time {1}!", m_BatteryLeftTime + i_HoursToAdd, r_BatteryMaxTime));
            }
        }
    }
}
