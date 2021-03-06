﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Midgard.Base32.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = new byte[] { 0x12, 0xAB, 0x34 };
            var expected = "CKVTI===";
            var result = Base32Converter.ToBase32String(input);
            StringAssert.Equals(expected, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = new byte[] { 0xbd, 0x78, 0x17, 0x4a, 0x70, 0xcd, 0x4f, 0xfe, 0x46, 0x4e, 0x2f, 0x21, 0x28, 0x2d, 0x45, 0xa0, 0x6e, 0x47, 0xea, 0x50 };
            var expected = "XV4BOSTQZVH74RSOF4QSQLKFUBXEP2SQ";
            var result = Base32Converter.ToBase32String(input);
            StringAssert.Equals(expected, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = new byte[] { 0xC0, 0xFF, 0xEE };
            var expected = "YD764===";
            var result = Base32Converter.ToBase32String(input);
            StringAssert.Equals(expected, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = new byte[] { 0x50, 0xf3, 0xe1, 0xa6, 0x26, 0x85, 0xc6, 0xd9, 0x69, 0x6b, 0x14, 0x3b, 0xbe, 0x14, 0xb8, 0x6c, 0x29, 0xc9, 0x47, 0x4f, 0x43, 0xf0, 0x12, 0xb7, 0x05, 0xc5, 0xa0, 0xc7, 0x15, 0x1e, 0x79, 0xcc, 0x3e, 0xcb, 0x76, 0x7b, 0xe2, 0x06, 0x2b, 0x54, 0xc9, 0x03, 0x7f, 0x2b, 0x26, 0x9b, 0xe5, 0xd0, 0x51, 0x53, 0x76, 0x0a, 0xcc, 0xa3, 0x58, 0x26, 0xf2, 0xd3, 0x7d, 0xd5, 0x59, 0x97, 0xa0, 0xa0, 0x6e, 0xe7, 0x9e, 0xca, 0xfb, 0xac, 0x63, 0x07, 0xbd, 0x75, 0xfb, 0xdf, 0x55, 0x90, 0x90, 0xa1, 0x06, 0x9b, 0xfb, 0x33, 0x30, 0x2f, 0xf3, 0xcb, 0x63, 0xf3, 0x6a, 0x9b, 0x35, 0x8e, 0xce, 0x44, 0x87, 0x47, 0x98, 0xd5, 0x5d, 0x9f, 0xfd, 0xb6, 0xda, 0xd4, 0xdb, 0x6e, 0x0d, 0xa3, 0x82, 0xc2, 0xa1, 0xbf, 0x69, 0x12, 0x22, 0xec, 0x60, 0x51, 0x9b, 0x9c, 0x20, 0xbf, 0x12, 0xbd, 0x14, 0xf1, 0x1a, 0x3b, 0x8c, 0x6b, 0x0c, 0x03, 0x8b, 0xb0, 0x9a, 0x4b, 0x30, 0x57, 0x76, 0xdc, 0x7c, 0x13, 0xb4, 0x32, 0x0b, 0xc2, 0x20, 0x79, 0x7a, 0x48, 0xca, 0x45, 0x27, 0x2e, 0x17, 0xcb, 0xe9, 0x52, 0x91, 0xd5, 0xab, 0x81, 0xfc, 0x86, 0x52, 0x43, 0x33, 0xed, 0x7c, 0x31, 0x29, 0xb0, 0xcd, 0x8a, 0x1a, 0xea, 0x20, 0x12, 0xf5, 0x70, 0x6e, 0xe3, 0x7e, 0x84, 0x40, 0x94, 0x54, 0x00, 0x92, 0x02, 0x05, 0xf9, 0x18, 0xb1, 0x29, 0x85, 0xcf, 0x8b };
            var expected = "KDZ6DJRGQXDNS2LLCQ534FFYNQU4SR2PIPYBFNYFYWQMOFI6PHGD5S3WPPRAMK2UZEBX6KZGTPS5AUKTOYFMZI2YE3ZNG7OVLGL2BIDO46PMV65MMMD325P335KZBEFBA2N7WMZQF7Z4WY7TNKNTLDWOISDUPGGVLWP73NW22TNW4DNDQLBKDP3JCIROYYCRTOOCBPYSXUKPCGR3RRVQYA4LWCNEWMCXO3OHYE5UGIF4EIDZPJEMURJHFYL4X2KSSHK2XAP4QZJEGM7NPQYSTMGNRINOUIAS6VYG5Y36QRAJIVAASIBAL6IYWEUYLT4L";
            var result = Base32Converter.ToBase32String(input);
            StringAssert.Equals(expected, result);
        }

        [TestMethod]
        public void TestMethodException()
        {
            byte[] input = null;
            //var expected = "Exception";
            try
            {
                var result = Base32Converter.ToBase32String(input);
                Assert.Fail("Should has Thrown Exception");
            }
            catch (ArgumentNullException)
            {
                // Evreything is fine :)
            }
        }


    }
}
