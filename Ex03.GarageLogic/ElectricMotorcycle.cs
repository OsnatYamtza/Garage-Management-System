using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicles
    {
        private const int k_WheelsNumber = 2;
        private const int k_MaxAirPressure = 30;
        private const float k_BatteryMaxTime = 2.3f;
        private eLicenseType m_LicenseType;
        private int m_EngineDisplacement;
        private List<Wheel> m_MotorcycleWheels;

        public ElectricMotorcycle(
    string i_WheelsManufacturer,
    float i_WheelsCurrentAirPressure,
    eLicenseType i_LicenseType,
    int i_EngineDisplacement,
    float i_BatteryLeftTime,
    string i_Model,
    string i_LicenseNumber,
    float i_LeftedEnergyPrecent)
    : base(i_BatteryLeftTime, k_BatteryMaxTime, i_Model, i_LicenseNumber, i_LeftedEnergyPrecent)
        {
            m_LicenseType = i_LicenseType;
            m_EngineDisplacement = i_EngineDisplacement;
            m_MotorcycleWheels = new List<Wheel>();
            for (int i = 0; i < k_WheelsNumber; i++)
            {
                m_MotorcycleWheels.Add(new Wheel(i_WheelsManufacturer, i_WheelsCurrentAirPressure, k_MaxAirPressure));
            }

            Wheels = m_MotorcycleWheels;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineDisplacement
        {
            get
            {
                return m_EngineDisplacement;
            }

            set
            {
                m_EngineDisplacement = value;
            }
        }

        public List<Wheel> MotorcycleWheels
        {
            get
            {
                return m_MotorcycleWheels;
            }

            set
            {
                m_MotorcycleWheels = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0} 
Lisence Type: {1}
Engine Displacement:
{2}",
                base.ToString(),
                m_LicenseType.ToString(),
                m_EngineDisplacement);
        }
    }
}
