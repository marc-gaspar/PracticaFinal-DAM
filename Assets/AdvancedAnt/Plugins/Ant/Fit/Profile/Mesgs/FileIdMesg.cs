#region Copyright
////////////////////////////////////////////////////////////////////////////////
// The following FIT Protocol software provided may be used with FIT protocol
// devices only and remains the copyrighted property of Dynastream Innovations Inc.
// The software is being provided on an "as-is" basis and as an accommodation,
// and therefore all warranties, representations, or guarantees of any kind
// (whether express, implied or statutory) including, without limitation,
// warranties of merchantability, non-infringement, or fitness for a particular
// purpose, are specifically disclaimed.
//
// Copyright 2016 Dynastream Innovations Inc.
////////////////////////////////////////////////////////////////////////////////
// ****WARNING****  This file is auto-generated!  Do NOT edit this file.
// Profile Version = 16.60Release
// Tag = production-akw-16.60.00-0-g5d3d436
////////////////////////////////////////////////////////////////////////////////

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;


namespace Dynastream.Fit
{
    /// <summary>
    /// Implements the FileId profile message.
    /// </summary>
    public class FileIdMesg : Mesg
    {
        #region Fields
        static class ProductSubfield
        {
            public static ushort GarminProduct = 0;
            public static ushort Subfields = 1;
            public static ushort Active = Fit.SubfieldIndexActiveSubfield;
            public static ushort MainField = Fit.SubfieldIndexMainField;
        }
        #endregion

        #region Constructors
        public FileIdMesg() : base(Profile.GetMesg(MesgNum.FileId))
        {
        }

        public FileIdMesg(Mesg mesg) : base(mesg)
        {
        }
        #endregion // Constructors

        #region Methods
        ///<summary>
        /// Retrieves the Type field</summary>
        /// <returns>Returns nullable File enum representing the Type field</returns>
        new public File? GetType()
        {
            object obj = GetFieldValue(0, 0, Fit.SubfieldIndexMainField);
            File? value = obj == null ? (File?)null : (File)obj;
            return value;
        }

        

        

        /// <summary>
        /// Set Type field</summary>
        /// <param name="type_">Nullable field value to be set</param>
        public void SetType(File? type_)
        {
            SetFieldValue(0, 0, type_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the Manufacturer field</summary>
        /// <returns>Returns nullable ushort representing the Manufacturer field</returns>
        public ushort? GetManufacturer()
        {
            return (ushort?)GetFieldValue(1, 0, Fit.SubfieldIndexMainField);
        }

        

        

        /// <summary>
        /// Set Manufacturer field</summary>
        /// <param name="manufacturer_">Nullable field value to be set</param>
        public void SetManufacturer(ushort? manufacturer_)
        {
            SetFieldValue(1, 0, manufacturer_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the Product field</summary>
        /// <returns>Returns nullable ushort representing the Product field</returns>
        public ushort? GetProduct()
        {
            return (ushort?)GetFieldValue(2, 0, Fit.SubfieldIndexMainField);
        }

        

        

        /// <summary>
        /// Set Product field</summary>
        /// <param name="product_">Nullable field value to be set</param>
        public void SetProduct(ushort? product_)
        {
            SetFieldValue(2, 0, product_, Fit.SubfieldIndexMainField);
        }
        

        /// <summary>
        /// Retrieves the GarminProduct subfield</summary>
        /// <returns>Nullable ushort representing the GarminProduct subfield</returns>
        public ushort? GetGarminProduct()
        {
            return (ushort?)GetFieldValue(2, 0, ProductSubfield.GarminProduct);
        }

        /// <summary>
        ///
        /// Set GarminProduct subfield</summary>
        /// <param name="garminProduct">Subfield value to be set</param>
        public void SetGarminProduct(ushort? garminProduct)
        {
            SetFieldValue(2, 0, garminProduct, ProductSubfield.GarminProduct);
        }
        ///<summary>
        /// Retrieves the SerialNumber field</summary>
        /// <returns>Returns nullable uint representing the SerialNumber field</returns>
        public uint? GetSerialNumber()
        {
            return (uint?)GetFieldValue(3, 0, Fit.SubfieldIndexMainField);
        }

        

        

        /// <summary>
        /// Set SerialNumber field</summary>
        /// <param name="serialNumber_">Nullable field value to be set</param>
        public void SetSerialNumber(uint? serialNumber_)
        {
            SetFieldValue(3, 0, serialNumber_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the TimeCreated field
        /// Comment: Only set for files that are can be created/erased.</summary>
        /// <returns>Returns DateTime representing the TimeCreated field</returns>
        public DateTime GetTimeCreated()
        {
            return TimestampToDateTime((uint?)GetFieldValue(4, 0, Fit.SubfieldIndexMainField));
        }

        

        

        /// <summary>
        /// Set TimeCreated field
        /// Comment: Only set for files that are can be created/erased.</summary>
        /// <param name="timeCreated_">Nullable field value to be set</param>
        public void SetTimeCreated(DateTime timeCreated_)
        {
            SetFieldValue(4, 0, timeCreated_.GetTimeStamp(), Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the Number field
        /// Comment: Only set for files that are not created/erased.</summary>
        /// <returns>Returns nullable ushort representing the Number field</returns>
        public ushort? GetNumber()
        {
            return (ushort?)GetFieldValue(5, 0, Fit.SubfieldIndexMainField);
        }

        

        

        /// <summary>
        /// Set Number field
        /// Comment: Only set for files that are not created/erased.</summary>
        /// <param name="number_">Nullable field value to be set</param>
        public void SetNumber(ushort? number_)
        {
            SetFieldValue(5, 0, number_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the ProductName field
        /// Comment: Optional free form string to indicate the devices name or model</summary>
        /// <returns>Returns byte[] representing the ProductName field</returns>
        public byte[] GetProductName()
        {
            return (byte[])GetFieldValue(8, 0, Fit.SubfieldIndexMainField);
        }

        
        ///<summary>
        /// Retrieves the ProductName field
        /// Comment: Optional free form string to indicate the devices name or model</summary>
        /// <returns>Returns String representing the ProductName field</returns>
        public String GetProductNameAsString()
        {
            return Encoding.UTF8.GetString((byte[])GetFieldValue(8, 0, Fit.SubfieldIndexMainField));
        }
        

        
        ///<summary>
        /// Set ProductName field
        /// Comment: Optional free form string to indicate the devices name or model</summary>
        /// <param name="productName_"> field value to be set</param>
        public void SetProductName(String productName_)
        {
            SetFieldValue(8, 0, System.Text.Encoding.UTF8.GetBytes(productName_), Fit.SubfieldIndexMainField);
        }
        

        /// <summary>
        /// Set ProductName field
        /// Comment: Optional free form string to indicate the devices name or model</summary>
        /// <param name="productName_">field value to be set</param>
        public void SetProductName(byte[] productName_)
        {
            SetFieldValue(8, 0, productName_, Fit.SubfieldIndexMainField);
        }
        
        #endregion // Methods
    } // Class
} // namespace