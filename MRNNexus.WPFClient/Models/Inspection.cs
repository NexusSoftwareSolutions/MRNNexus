using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using MRNNexusDTOs;

namespace MRNNexus.WPFClient.Models
{
    internal class Inspection : BaseModel
    {
        #region Fields
        private int _inspectionID;
        private int _claimID;
        private DateTime _inspectionDate = DateTime.Now;
        private int _roofAge;
        private int _ridgeTypeID;
        private int _shingleTypeID;
        private bool _drivewayDamage = false;
        private bool _skylights = false;
        private bool _lighteningProtection = false;
        private bool _satellite = false;
        private bool _solarPanels = false;
        private bool _gutterDamage = false;
        private bool _coverPool = false;
        private bool _exteriorDamage = false;
        private bool _interiorDamage = false;
        private bool _leaks = false;
        private bool _furnishPermit = true;
        private bool _protectLandscaping = true;
        private bool _tearOff = true;
        private bool _iceWaterShield = true;
        private bool _qualityControl = true;
        private bool _magneticRollers = true;
        private bool _removeTrash = true;
        private bool _emergencyRepairsNeeded = false;
        private double? _emergencyRepairAmount;
        private string _comments;

        #endregion

        #region Properties
        public int InspectionID
        {
            get { return _inspectionID; }
            set
            {
                _inspectionID = value;
                RaisePropertyChanged("InspectionID");
            }
        }
        public int ClaimID
        {
            get { return _claimID; }
            set
            {
                _claimID = value;
                RaisePropertyChanged("ClaimID");
            }
        }
        public DateTime InspectionDate
        {
            get {
                if(_inspectionDate == DateTime.MinValue)
                    return DateTime.Now;
                else return _inspectionDate;
            }
            set {
                _inspectionDate = value;
                RaisePropertyChanged("InspectionDate");
            }
        }
        public int RoofAge
        {
            get { return _roofAge; }
            set {
                if(value > 0 && value != _roofAge)
                _roofAge = value;
                RaisePropertyChanged("RoofAge");
            }
        }
        public int RidgeType
        {
            get
            {
                if (_ridgeTypeID > 0)
                    return _ridgeTypeID;
                else
                    return 0;
                
            }
            set
            {
                _ridgeTypeID = value;
                RaisePropertyChanged("RidgeType");
            }
        }
        public int ShingleType
        {
            get
            {
                if (_shingleTypeID > 0)
                    return _shingleTypeID;
                else
                    return 0;

            }
            set
            {
                _shingleTypeID = value;
                RaisePropertyChanged("ShingleType");
            }
        }
        public bool DrivewayDamage
        {
            get
            {
                return _drivewayDamage;

            }
            set
            {
                _drivewayDamage = value;
                RaisePropertyChanged("DriveWayDamage");
            }
        }
        public bool Skylights
        {
            get { return _skylights; }
            set { 
                _skylights = value;
                RaisePropertyChanged("Skylights");
            }
        }
        public bool LighteningProtection
        {
            get { return _lighteningProtection; }
            set { 
                _lighteningProtection = value;
                RaisePropertyChanged("LighteningProtection");
            }
        }
        public bool Satellite
        {
            get { return _satellite; }
            set { 
                _satellite = value;
                RaisePropertyChanged("LighteningProtection");
            }
        }
        public bool SolarPanels
        {
            get { return _solarPanels; }
            set { 
                _solarPanels = value;
                RaisePropertyChanged("LighteningProtection");
            }
        }
        public bool GutterDamage
        {
            get { return _gutterDamage; }
            set
            {
                _gutterDamage = value;
                RaisePropertyChanged("GutterDamage");
            }
        }
        public bool CoverPool
        {
            get { return _coverPool; }
            set
            {
                _coverPool = value;
                RaisePropertyChanged("CoverPool");
            }
        }
        public bool ExteriorDamage
        {
            get { return _exteriorDamage; }
            set
            {
                _exteriorDamage = value;
                RaisePropertyChanged("ExteriorDamage");
            }
        }
        public bool InteriorDamage
        {
            get { return _interiorDamage; }
            set
            {
                _interiorDamage = value;
                RaisePropertyChanged("InteriorDamage");
            }
        }
        public bool Leaks
        {
            get { return _leaks; }
            set
            {
                _leaks = value;
                RaisePropertyChanged("Leaks");
            }
        }
        public bool FurnishPermit
        {
            get { return _furnishPermit; }
            set
            {
                _furnishPermit = value;
                RaisePropertyChanged("FurnishPermit");
            }
        }
        public bool ProtectLandscaping
        {
            get { return _protectLandscaping; }
            set
            {
                _protectLandscaping = value;
                RaisePropertyChanged("ProtectLandscaping");
            }
        }
        public bool TearOff
        {
            get { return _tearOff; }
            set
            {
                _tearOff = value;
                RaisePropertyChanged("TearOff");
            }
        }
        public bool IceWaterShield
        {
            get { return _iceWaterShield; }
            set
            {
                _iceWaterShield = value;
                RaisePropertyChanged("IceWaterShield");
            }
        }
        public bool QualityControl
        {
            get { return _qualityControl; }
            set
            {
                _qualityControl = value;
                RaisePropertyChanged("QualityControl");
            }
        }
        public bool MagneticRollers
        {
            get { return _magneticRollers; }
            set
            {
                _magneticRollers = value;
                RaisePropertyChanged("MagneticRollers");
            }
        }
        public bool RemoveTrash
        {
            get { return _removeTrash; }
            set
            {
                _removeTrash = value;
                RaisePropertyChanged("RemoveTrash");
            }
        }
        public bool EmergencyRepairsNeeded
        {
            get { return _emergencyRepairsNeeded; }
            set
            {
                _emergencyRepairsNeeded = value;
                RaisePropertyChanged("EmergencyRepairsNeeded");
            }
        }
        public double? EmergencyRepairAmount
        {
            get { return _emergencyRepairAmount; }
            set
            {
                _emergencyRepairAmount = value;
                RaisePropertyChanged("EmergencyRepairAmount");
            }
        }
        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                RaisePropertyChanged("Comments");
            }
        }


        #endregion

        #region Constructors
        public Inspection() { }
        public Inspection(DTO_Inspection inspection)
        {
            InspectionID = inspection.InspectionID;
            ClaimID = inspection.ClaimID;
            RidgeType = inspection.RidgeMaterialTypeID;
            ShingleType = inspection.ShingleTypeID;
            InspectionDate = inspection.InspectionDate;
            Skylights = inspection.SkyLights;
            Leaks = inspection.Leaks;
            GutterDamage = inspection.GutterDamage;
            DrivewayDamage = inspection.DrivewayDamage;
            MagneticRollers = inspection.MagneticRollers;
            IceWaterShield = inspection.IceWaterShield;
            EmergencyRepairsNeeded = inspection.EmergencyRepair;
            EmergencyRepairAmount = inspection.EmergencyRepairAmount;
            QualityControl = inspection.QualityControl;
            ProtectLandscaping = inspection.ProtectLandscaping;
            RemoveTrash = inspection.RemoveTrash;
            FurnishPermit = inspection.FurnishPermit;
            CoverPool = inspection.CoverPool;
            InteriorDamage = inspection.InteriorDamage;
            ExteriorDamage = inspection.ExteriorDamage;
            LighteningProtection = inspection.LighteningProtection;
            TearOff = inspection.TearOff;
            Satellite = inspection.Satellite;
            SolarPanels = inspection.SolarPanels;
            RoofAge = inspection.RoofAge;
            Comments = inspection.Comments;
        }
        #endregion

        public DTO_Inspection toDTO()
        {
            return new DTO_Inspection
            {
                InspectionID = this.InspectionID,
                ClaimID = this.ClaimID,
                RidgeMaterialTypeID = this.RidgeType,
                ShingleTypeID = this.ShingleType,
                InspectionDate = this.InspectionDate,
                SkyLights = this.Skylights,
                Leaks = this.Leaks,
                GutterDamage = this.GutterDamage,
                DrivewayDamage = this.DrivewayDamage,
                MagneticRollers = this.MagneticRollers,
                IceWaterShield = this.IceWaterShield,
                EmergencyRepair = this.EmergencyRepairsNeeded,
                EmergencyRepairAmount = this.EmergencyRepairAmount,
                QualityControl = this.QualityControl,
                ProtectLandscaping = this.ProtectLandscaping,
                RemoveTrash = this.RemoveTrash,
                FurnishPermit = this.FurnishPermit,
                CoverPool = this.CoverPool,
                InteriorDamage = this.InteriorDamage,
                ExteriorDamage = this.ExteriorDamage,
                LighteningProtection = this.LighteningProtection,
                TearOff = this.TearOff,
                Satellite = this.Satellite,
                SolarPanels = this.SolarPanels,
                RoofAge = this.RoofAge,
                Comments = this.Comments
        };
        }


    }
}
