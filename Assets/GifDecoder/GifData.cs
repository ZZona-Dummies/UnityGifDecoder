/*  Copyright © 2016 Graeme Collins. All Rights Reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

3. The name of the author may not be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY GRAEME COLLINS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. */

using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class GifData
{
    public string header;
    public int canvasWidth;
    public int canvasHeight;
    public bool globalColorTableFlag;
    public int bitsPerPixel;
    public bool sortFlag;
    public int globalColorTableSize;
    public int backgroundColorIndex;
    public int pixelAspectRatio;
    public GifColor[] globalColorTable;

    public List<GifGraphicsControlExtension> graphicsControlExtensions;
    public List<GifImageDescriptor> imageDescriptors;
    public List<GifImageData> imageDatas;

    public GifData()
    {
        graphicsControlExtensions = new List<GifGraphicsControlExtension>();
        imageDescriptors = new List<GifImageDescriptor>();
        imageDatas = new List<GifImageData>();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("GIF Type: " + header);
        sb.AppendLine("Image Size: " + canvasWidth + "x" + canvasHeight);
        sb.AppendLine($"Global Color Table Flag: {globalColorTableFlag}");
        sb.AppendLine($"Color Resolution (Bits per Pixels): {bitsPerPixel}");
        sb.AppendLine($"Sort Flag to Global Color Table: {sortFlag}");
        sb.AppendLine($"Size of Global Color Table: {globalColorTableSize} ({1 << (globalColorTableSize + 1)})"); // 1 << x is equivalent to (int)Math.Pow(2, x)
        sb.AppendLine($"Background Color Index: {backgroundColorIndex}");
        sb.AppendLine($"Pixel Aspect Radio: {pixelAspectRatio}");
        sb.AppendLine($"Global Color Table: {(globalColorTableFlag ? globalColorTable.Length.ToString() : "ColorTableFlag is false!")}");
        sb.AppendLine("Animation Image Count: " + imageDatas.Count);
        //sb.AppendLine("Animation Loop Count (0 is infinite): " + m_appEx.loopCount);
        //sb.AppendLine($"Graphic Control Extension Count: {m_graphicCtrlExList.PrintListLength()}");
        //sb.AppendLine($"Comment Extension Count: {m_commentExList.PrintListLength()}");
        //sb.AppendLine($"Plain Text Extension Count: {m_plainTextExList.PrintListLength()}");

        //bool hasGraphicCtrlEx = m_graphicCtrlExList != null && m_graphicCtrlExList.Count > 0;
        //int frameLength = hasGraphicCtrlEx ? m_graphicCtrlExList.Count : m_imageBlockList.Count;

        //if (frameLength > 0)
        //{
        //    if (hasGraphicCtrlEx && m_imageBlockList.Count != m_graphicCtrlExList.Count)
        //    {
        //        Debug.LogError("Dumping malformed GIF!");
        //        return sb.ToString();
        //    }

        //    //var sbFramesDelays = new StringBuilder();

        //    //sbFramesDelays.Append("\tAnimation Delay Time (in ms): ");

        //    string separator = "";
        //    for (int i = 0; i < frameLength; i++)
        //    {
        //        //if (i > 0)
        //        //    sbFramesDelays.Append(", ");
        //        //sbFramesDelays.Append(m_graphicCtrlExList[i].m_delayTime * 10); // The value is 1/100 sec

        //        int index = i + 1;
        //        string extensionCap = $"Frame #{index.ToString(new string('0', (int)Mathf.Log10(frameLength)))} Data";
        //        separator = new string('=', extensionCap.Length);

        //        sb.AppendLine(separator);
        //        sb.AppendLine(extensionCap);
        //        sb.AppendLine(separator);

        //        if (hasGraphicCtrlEx)
        //        {
        //            sb.AppendLine("\tGraphic Control Extension Data");

        //            var item = m_graphicCtrlExList[i];

        //            // Append properties

        //            var sbProps = new StringBuilder();
        //            sbProps.AppendLine($"\t\tExtension Introducer: {item.m_extensionIntroducer.PrintDetailedByte()}");
        //            sbProps.AppendLine($"\t\tGraphic Control Label: {item.m_graphicControlLabel.PrintDetailedByte()}");
        //            sbProps.AppendLine($"\t\tBlock Size: {item.m_blockSize.PrintDetailedByte(false)}");
        //            sbProps.AppendLine($"\t\tDisposal Method: {item.m_disposalMethod}");
        //            sbProps.AppendLine($"\t\tTransparent Color Flag: {item.m_transparentColorFlag}");
        //            sbProps.AppendLine($"\t\tAnimation Delay Time (in ms): {item.m_delayTime * 10}");
        //            sbProps.AppendLine($"\t\tTransparent Color Index: {item.m_transparentColorIndex.PrintDetailedByte(false)}");
        //            sbProps.AppendLine($"\t\tBlock Terminator: {item.m_blockTerminator.PrintDetailedByte()}");

        //            string sbPropsText = sbProps.ToString();
        //            int longestLine = sbPropsText.SplitIntoLines().GetLongestLine(new Tuple<string, int>(StringHelper.AsString('\t'), 8));

        //            sb.Append(sbPropsText);
        //            sb.AppendLine(new string('-', longestLine));
        //        }

        //        {
        //            sb.AppendLine("\tImage Block Data");

        //            var item = m_imageBlockList[i];

        //            // Append properties

        //            sb.AppendLine($"\t\tImage Separator: {item.m_imageSeparator.PrintDetailedByte()}");
        //            sb.AppendLine($"\t\tImage Left Position: {item.m_imageLeftPosition}");
        //            sb.AppendLine($"\t\tImage Top Position: {item.m_imageTopPosition}");
        //            sb.AppendLine($"\t\tImage Width: {item.m_imageWidth}");
        //            sb.AppendLine($"\t\tImage Height: {item.m_imageHeight}");
        //            sb.AppendLine($"\t\tLocal Color Table Flag: {item.m_localColorTableFlag}");
        //            sb.AppendLine($"\t\tInterlace Flag: {item.m_interlaceFlag}");
        //            sb.AppendLine($"\t\tSort Flag: {item.m_sortFlag}");
        //            sb.AppendLine($"\t\tSize Of Local Color Table: {item.m_sizeOfLocalColorTable} (Count: {item.m_localColorTable.PrintListLength()})");
        //            sb.AppendLine($"\t\tLZW Minimum Code Size: {item.m_lzwMinimumCodeSize.PrintDetailedByte(false)}");
        //            sb.AppendLine($"\t\tImage Data Count: {item.m_imageDataList.PrintListLength()}");

        //            int j = 0;
        //            foreach (var imageData in item.m_imageDataList)
        //            {
        //                sb.AppendLine($"\t\tImage Data #{j}");
        //                sb.AppendLine($"\t\t\tBlock Size: {imageData.m_blockSize} (Length: {imageData.m_imageData.Length})");

        //                ++j;
        //            }
        //        }
        //    }

        //    sb.AppendLine(separator);
        //}
        //sb.AppendLine("Application Identifier: " + m_appEx.applicationIdentifier);
        //sb.AppendLine("Application Authentication Code: " + m_appEx.applicationAuthenticationCode);

        return sb.ToString();
    }
}