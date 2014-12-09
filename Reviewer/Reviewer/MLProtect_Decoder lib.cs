//---------------------------------------------------------------------------
// MLProtect_Decoderlib.cs : Personal protection code for the MediaLooks License system
//---------------------------------------------------------------------------
// Copyright (c) 2012, MediaLooks Soft
// www.medialooks.com (dev@medialooks.com)
//
// Authors: MediaLooks Team
// Version: 3.0.0.0
//
//---------------------------------------------------------------------------
// CONFIDENTIAL INFORMATION
//
// This file is Intellectual Property (IP) of MediaLooks Soft and is
// strictly confidential. You can gain access to this file only if you
// sign a License Agreement and a Non-Disclosure Agreement (NDA) with
// MediaLooks Soft If you had not signed any of these documents, please
// contact <dev@medialooks.com> immediately.
//
//---------------------------------------------------------------------------
// Usage:
//
// 1. Copy MLProxy.dll from the license package to any folder and register it
//    in the system registry by using regsvr32.exe utility
//
// 2. Add the reference to MLProxy.dll in the C# project
//
// 3. Add this file to the project
//
// 4. Call DecoderlibLic.IntializeProtection() method before creating any Medialooks 
//    objects (for e.g. in Form_Load event handler)
//
// 5. Compile the project
//
// IMPORTANT: If your application is running for a period longer than 24 
//            hours, the IntializeProtection() call should be repeated 
//            periodically  (every 24 hours or less).
//
// IMPORTANT: If your have several Medialooks products, don't forget to initialize
//            protection for all of them. For e.g.
//
//             MPlatformLic.IntializeProtection();
//             MDecodersLic.IntializeProtection();
//             etc.

using System;

public class DecoderlibLic
{
    private static MLPROXYLib.CoMLProxyClass m_objMLProxy;
    private static string strLicInfo = @"[MediaLooks]
License.ProductName=Decoder lib
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={5AD922ED-D3C8-4380-8191-B89AF180C206}
License.Key={6E214B67-9BA9-E4D6-3185-610BD1037961}
License.Name=MPlaylist Module
License.UpdateExpirationDate=July 17, 2015
License.Edition=MDecoders
License.AllowedModule=*.*
License.Signature=3B4A0999413CD03B71A7C327F2460B96B1FC65268CDA7CD9F4162BD951D34CC0097CC378958B1D693A85B5F3CEBFCCD077DBDB9771AF87A17773DFDC7E48A90641DE9B71F1F03965D45B3ED2AC8DD31C553C1A071FFDCAA86ECAF29D67147FE53FF1B75B12963F3B6303BC3F4D9081CE7D1D412FAF2D9D24820D3711236255B1

[MediaLooks]
License.ProductName=Decoder lib
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={8915C9B9-90DD-4615-972F-68A9211502C6}
License.Key={6E214B67-6852-97D9-AAC4-E44025A5171A}
License.Name=MFile Module
License.UpdateExpirationDate=July 17, 2015
License.Edition=MDecoders
License.AllowedModule=*.*
License.Signature=2FAEF63257D1230C2CBF3D4C9E5196951F3B66B67E194101F2A9427F4DD240096010C232C0408F4BF063D19D17260CDCC34F938143C71CF0DB3162722A58BAE27A00C27E5073512F1B2B5CF028C1B4357D36721561CF9373CB6D614518CF0E546B60875A9BE0059D8DD2742883B35FDE09C64221E5F557322DAFFBE421C05802

[MediaLooks]
License.ProductName=Decoder lib
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={2750ECF9-7528-4047-8EDC-86F33BACE0C7}
License.Key={238B3B77-54D2-69A7-5579-BE53DAEC87D8}
License.Name=MMixer Module (BETA)
License.UpdateExpirationDate=July 17, 2015
License.Edition=MDecoders
License.AllowedModule=*.*
License.Signature=667C2BC41546193DA5F9286834B8D10354B6325B492D7C4DEA974B6B40F4B8650CB0AEA95356D5588B996365C388D8EEF9E715628953802DFD9A0B9180ED6FF2650E0D650DE8BB4147354CA6DFB9FEA8D6122B22C65FA801D7564D914F7B84872DCDAF877F5D43A30D679DD50E797783EB8D09C49BDE6EAACB05530378F7EF85

";

    //License initialization
    public static void IntializeProtection()
    {
        if (m_objMLProxy == null)
        {
            // Create MLProxy object 
            m_objMLProxy = new MLPROXYLib.CoMLProxyClass();
            m_objMLProxy.PutString(strLicInfo);
        }
        UpdatePersonalProtection();
    }

    private static void UpdatePersonalProtection()
    {
        ////////////////////////////////////////////////////////////////////////
        // MediaLooks License secret key
        // Issued to: Roversoft
        const long _Q1_ = 43859749;
        const long _P1_ = 63339733;
        const long _Q2_ = 41334409;
        const long _P2_ = 61258079;

        try
        {

            int nFirst = 0;
            int nSecond = 0;
            m_objMLProxy.GetData(out nFirst, out  nSecond);

            // Calculate First * Q1 mod P1
            long llFirst = (long)nFirst * _Q1_ % _P1_;
            // Calculate Second * Q2 mod P2
            long llSecond = (long)nSecond * _Q2_ % _P2_;

            uint uRes = SummBits((uint)(llFirst + llSecond));

            // Calculate check value
            long llCheck = (long)(nFirst - 29) * (nFirst - 23) % nSecond;
            // Calculate return value
            int nRand = new Random().Next(0x7FFF);
            int nValue = (int)llCheck + (int)nRand * (uRes > 0 ? 1 : -1);

            m_objMLProxy.SetData(nFirst, nSecond, (int)llCheck, nValue);

        }
        catch (System.Exception) { }

    }

    private static uint SummBits(uint _nValue)
    {
        uint nRes = 0;
        while (_nValue > 0)
        {
            nRes += (_nValue & 1);
            _nValue >>= 1;
        }

        return nRes % 2;
    }
}