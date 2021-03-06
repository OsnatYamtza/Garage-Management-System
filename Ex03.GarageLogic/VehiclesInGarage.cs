using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehiclesInGarage
    {
        private Vehicle m_Vehicle;
        private string m_VehicleOwner;
        private string m_VehicleOwnerPhone;
        private eVehicleStatus m_VehicleStatus;

        public VehiclesInGarage(Vehicle i_VehicleInGarage, string i_VehicleOwner, string i_VehicleOwnerPhone, eVehicleStatus i_VehicleStatus)
        {
            m_Vehicle = i_VehicleInGarage;
            m_VehicleOwner = i_VehicleOwner;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = i_VehicleStatus;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public string VehicleOwner
        {
            get
            {
                return m_VehicleOwner;
            }

            set
            {
                m_VehicleOwner = value;
            }
        }

        public string VehicleOwnerPhone
        {
            get
            {
                return m_VehicleOwnerPhone;
            }

            set
            {
                m_VehicleOwnerPhone = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }
    }
}
