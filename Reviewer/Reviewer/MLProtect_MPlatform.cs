//---------------------------------------------------------------------------
// MLProtect_MPlatform.cs : Personal protection code for the MediaLooks License system
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
// 4. Call MPlatformLic.IntializeProtection() method before creating any Medialooks 
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

    public class MPlatformLic
    {        
        private static MLPROXYLib.CoMLProxyClass m_objMLProxy;
        private static string strLicInfo = @"[MediaLooks]
License.ProductName=MPlatform
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={5AD922ED-D3C8-4380-8191-B89AF180C206}
License.Key={62B28181-63BA-164D-F29A-1A868E6F8C11}
License.Name=MPlaylist Module
License.UpdateExpirationDate=July 17, 2015
License.Edition=Standard
License.AllowedModule=*.*
License.Signature=8878382FFBFFD00CEFB860A5DA019968E8D76BC07BB44040384A53BCE085C94BD3F26BC7610D68FC526AEB35375CB939936F581636133602C59C13A05DBADDCD9626CEE9EC8C102C3AA406A424FCBAE9A09C9E1C2A6151843AB407B8E1486E971DC3FF2E8D483637F3F6555E8AF27C46F777EC01DA5A5ABDEFF32B9672D49D10

[MediaLooks]
License.ProductName=MPlatform
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={8915C9B9-90DD-4615-972F-68A9211502C6}
License.Key={6B540D5D-A02A-614C-9373-4266C2E74B5C}
License.Name=MFile Module
License.UpdateExpirationDate=July 17, 2015
License.Edition=Standard
License.AllowedModule=*.*
License.Signature=D29E7CC34D587DE0B0D8658EAAF5B49158820CF2970390BE305EDECD1AABA836EDE67818B477A2CABB55242ABE6CFB3863BBFAA399BDF8E369626EE91CF9EDC591EA122B5C8BAD69FDA5ED132A977F79EF3C58ECDB669227C6621CCED580330289D94D4B52D83FAE5A46A54C2D7097D76269554D1EA190BA611230D9171CA315

[MediaLooks]
License.ProductName=MPlatform
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={CFFC5536-04EC-4748-9032-B060FD35D71D}
License.Key={1585A8AA-154B-5F4D-ACDF-8FFE6DBE3B7B}
License.Name=MLive Module
License.UpdateExpirationDate=July 17, 2015
License.Edition=Standard
License.AllowedModule=*.*
License.Signature=2569C16D241A1DC7C86745AD9171FFA7E269B215A57E1D56F244C9D9A645F67C60AC5A0D64498A453A05EC222FAF1FFFCD11EC278DCC1813BB7A3D07E65A8F1D2AB3543197D43D6F65D76A5C5B5A7ECF1E5B48257AFB6B7FB53B8C9CD7CAA3DB64FC144BF091525EB0960704719F26A5B6903F109423FEBAF17E8F36F4EBD17B

[MediaLooks]
License.ProductName=MPlatform
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={E3044AAF-33E9-40E5-830F-2ECD7643E8FD}
License.Key={1FB41DCD-4BE4-A521-47EC-7F194379C227}
License.Name=MRenderer Module
License.UpdateExpirationDate=July 17, 2015
License.Edition=Standard
License.AllowedModule=*.*
License.Signature=24D8D42A646432F4665337E451ABFBBAF4CF771F2A905BCF5B8CA32541695C8968FB73F92C19575DB607D2A1CCE8CBD5DF3DCF01DFD2803119392F062C049ADD592D7F446A8D3A8774790161A787E8D41E90CFA2EFD14579263DD9B882086F622A9FED025DD857C69FFE568228AD0C03665F646AD8A3C4FB6A193009F2221273

[MediaLooks]
License.ProductName=MPlatform
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={87C22BE2-653F-4F09-A603-0AF98D464A1B}
License.Key={650FDFAB-28F2-5EB3-EE9E-A6B3073DE72C}
License.Name=MTransportDS Module
License.UpdateExpirationDate=July 17, 2015
License.Edition=Standard
License.AllowedModule=*.*
License.Signature=60753E778D5E67AFC2C5DB7FF5204F93E7B03EE1CEA5DD5C5A9ED4614DF4796DF8043CF14899B35994C5F5432CF582B463A18D722F587A5C7792B72273195C66A9B48938166CBCD5579BED5BD4B4C121E5EFEE8923180BC17AFCD7815B235EE7558B0608F0A4CC1CA3BC4BAA82E34B22C83DDE23685FA4B7539D4828C3CAB8A5

[MediaLooks]
License.ProductName=MPlatform
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={2750ECF9-7528-4047-8EDC-86F33BACE0C7}
License.Key={DFAED713-B070-10EB-A58C-4D3E69F7C118}
License.Name=MMixer Module (BETA)
License.UpdateExpirationDate=July 17, 2015
License.Edition=Standard
License.AllowedModule=*.*
License.Signature=543ED1BEF1C7FBF2157229DDF632A0C2A855A6811FA51965730F0A14BBB7F2F5B6E92B7C676F0038356432C270165EB93224D48D60BD58273B8006A1FAA9EFB188AF0A5942D24E3AFFF7A26A76F64444FEAC62ECEEBC590528271A3BE6CDE276F0164480CBB059C8E90B3253815B7B195268BF7AA8E47D3A7B1BAB576EE21AC2

[MediaLooks]
License.ProductName=MPlatform
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={E5F7CAAD-9840-4F57-BF39-6CE9B929D8EC}
License.Key={78802C6E-46D4-2C58-D642-5955A0826B5C}
License.Name=MediaLooks Character Generator
License.UpdateExpirationDate=July 17, 2015
License.Edition=Professional
License.AllowedModule=*.*
License.Signature=856E2D4F837E3FFA57A618A29AA50D345D9CEC849C50431F000F60F14D8A719D27E4938FFE57F2A405494D6E1F7FBE288D88216E9BA661A8344BB956C1B14FC05B2FABEAD30AC7E27809A0C16C58A77F72C576593EF5993E67C7CC07C389DE94006F87EA86C1D366E0F7D265DF31ACAAC72915D9EC51350448CFDBE48B35EA8E

[MediaLooks]
License.ProductName=MPlatform
License.IssuedTo=Roversoft
License.CompanyID=9652
License.UUID={97478B91-4F81-4EA3-A2B4-5A216C00B3B0}
License.Key={C4DD9909-A526-DCBF-AEE8-0AAA723BEEEA}
License.Name=MPlatform Module
License.UpdateExpirationDate=July 17, 2015
License.Edition=Standard
License.AllowedModule=*.*
License.Signature=91F57CF5E46FB51F1D5330785BF01BC9C7DBA78A1A39D010BED9E64FF1BC3CE36D2A2C3F3A2132C6799509A5A1A2B7F63470577FD1170A041788C7AAF07BBEB98144179226EC52CEE42B3E9B3AAEFDDFF4DB321EDA00A8E06A1E6B7CABBFAEC43CB127DFF5507DC11A7298D661D1BDAA06EA4375E82D1385A8706DF13A15A471

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