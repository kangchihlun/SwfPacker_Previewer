using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SpriteSheetEditor
{
    
    class SwfFile
    {
        public SwfFile(string outSwfFilePath, List<ImgInfo> InImageInfo , bool bDeleteAS)
        {
            m_outSwfFilePath = outSwfFilePath;
            m_PngInfo = InImageInfo;
            m_bDeleteAS = bDeleteAS;
        }
        //public bool AddPic(string pPicFileName);
        //public bool RemovePic(int nIndex);
        public void BuildSwf()
        { 
            string     pDirName = Directory.GetCurrentDirectory();   
	        int i;
            string MainAsFilePath="";
            string ClassName="";
            //Parse class name
            string _ClassName = Path.GetFileName(m_outSwfFilePath) ;
            string[] s4 = _ClassName.Split(new Char[] { ' ', '"', '\t', '.' });
            foreach (string ss in s4)
            {
                if (ss.Count() > 0)
                {
                    ClassName = ss;
                    break;
                }
            }

            // 寫入as檔
            MainAsFilePath = Path.GetDirectoryName(m_outSwfFilePath) + ClassName + ".as";
            List<String> ASStr = new List<String>();
            ASStr.Add("package");
            ASStr.Add("	{");
            ASStr.Add("	import flash.display.Sprite;");
            ASStr.Add("	import flash.text.TextField;");
            ASStr.Add("	import flash.display.Bitmap;");
            ASStr.Add("	import flash.events.Event;");
            
            int _SwfWidth_ = 1024;
            int _SwfHeight_ = 768;
            string _ns_ = " 	[SWF(width = \""+_SwfWidth_ +"\", height = \""+_SwfHeight_+"\", backgroundColor = \"#ffffff\", frameRate = \"2\")] " ;
            ASStr.Add(_ns_);
            _ns_ = "	public class " + ClassName + " extends Sprite";
            ASStr.Add(_ns_);
            ASStr.Add("	{");
            int BlockNumH = 0;
            int BlockNumW = m_PngInfo.Count();
            if (BlockNumW > 3)
                BlockNumW = 3;
            if (m_PngInfo.Count() >= 3)
                BlockNumH = 2;
            else
                BlockNumH = 1;

            // 加入BMP#圖片定義
            for (i = 0; i < m_PngInfo.Count(); i++)
            {
                _ns_ = "			public var bmp" + i.ToString() + " : " + ClassName + "_BMP" + i.ToString() + ";";
                ASStr.Add(_ns_);
            }
            ASStr.Add("\n");
            _ns_ = "			public function " + ClassName  + "()";
            ASStr.Add(_ns_);
            ASStr.Add("			{");
            ASStr.Add("				super();");
            ASStr.Add("				addEventListener(Event.ADDED_TO_STAGE, onAddToStage, false, 0, true);");
            ASStr.Add("			}");
            ASStr.Add("			public function onAddToStage(e:Event)");
            ASStr.Add("			{");
            ASStr.Add("				var dispBMP:Bitmap;");
            ASStr.Add("				var dispText:TextField;");
            ASStr.Add("				var picOrgWidth:uint;");
            ASStr.Add("				var picOrgHeight:uint;");
            ASStr.Add("				\n");
            // 顯示背景透明區塊
            ASStr.Add("				graphics.beginFill(0xDDDDDD, 1);");
            ASStr.Add("				var i:uint;");
            ASStr.Add("				var j:uint;");
            ASStr.Add("				for (i = 0; i <= " + _SwfWidth_.ToString()+ "; i += 30 )");
            ASStr.Add("				{");
            ASStr.Add("				    for (j = 0; j <= " + _SwfHeight_.ToString() + "; j += 30 )\n");
            ASStr.Add("					{");
            ASStr.Add("						graphics.drawRect(i, j, 15, 15);");
            ASStr.Add("						graphics.drawRect(i+15, j+15, 15, 15);");
            ASStr.Add("					}");
            ASStr.Add("				}");
            ASStr.Add("				graphics.endFill();");
            ASStr.Add("\n");
            // 顯示圖片和說明
            for (i = 0; i < m_PngInfo.Count(); i++)
            {
                // 顯示圖片
                _ns_ = "				bmp"+i.ToString()+" = new "+ClassName+"_BMP"+i.ToString()+"(0,0);";
                ASStr.Add(_ns_);
                _ns_ = "				dispBMP = new Bitmap(bmp"+i.ToString()+");";
                ASStr.Add(_ns_);
                ASStr.Add("				picOrgWidth = dispBMP.width;");
                ASStr.Add("				picOrgHeight = dispBMP.height;");
                float _n = (i%BlockNumW)* _SwfWidth_ / BlockNumW ;
                _ns_ = "				dispBMP.x = " + _n.ToString() +";" ;
                ASStr.Add(_ns_);
                _n = (i/BlockNumW)*_SwfHeight_/ BlockNumH ;
                _ns_ = "				dispBMP.y = " + _n.ToString() + ";";
                ASStr.Add(_ns_);
                _n = _SwfWidth_ / BlockNumW;
                _ns_ = "				dispBMP.height *= " + _n.ToString() + "/dispBMP.width;";
                ASStr.Add(_ns_);
                _n = _SwfHeight_ / BlockNumH;
                _ns_ = "				if(dispBMP.height>" + _n.ToString() + ")";
                ASStr.Add(_ns_);
                ASStr.Add("				{");
                _n =_SwfWidth_ / BlockNumW;
                float _n2 = _SwfHeight_ / BlockNumH;
                _ns_ = "					dispBMP.width = " + _n.ToString() + "*dispBMP.height/" + _n2.ToString()+";";
                ASStr.Add(_ns_);
                _ns_ = "					dispBMP.height = "+ _n2.ToString()+";";
                ASStr.Add(_ns_);
                ASStr.Add("				}");
                ASStr.Add("				else");
                ASStr.Add("				{");
                _ns_ = "					dispBMP.width = " + _n.ToString()+";";
                ASStr.Add(_ns_);
                ASStr.Add("				}");
                ASStr.Add("				addChild(dispBMP);");
                ASStr.Add("\n");
                ASStr.Add("				dispText = new TextField();");
                _ns_ = "				dispText.text = \"#"+i.ToString()+" "+m_PngInfo[i].FileName+" \" + picOrgWidth + \"x\" + picOrgHeight;";
                ASStr.Add(_ns_);
                _n = (i % BlockNumW) * _SwfWidth_ / BlockNumW + 10;
                _ns_ = "				dispText.x = " + _n.ToString()+ ";";
                ASStr.Add(_ns_);
                _n = (i/BlockNumW)*_SwfHeight_/BlockNumH + _SwfHeight_/BlockNumH - 20;
                _ns_ = "				dispText.y = " +_n.ToString()+ ";";
                ASStr.Add(_ns_);
                _n = _SwfWidth_ / BlockNumW;
                _ns_ = "				dispText.width = " + _n.ToString()+ ";";
                ASStr.Add(_ns_);
                ASStr.Add("				dispText.height = 20;");
                ASStr.Add("				addChild(dispText);");
            }
            ASStr.Add("\n");
            ASStr.Add("				dispText = new TextField();");
            ASStr.Add("				dispText.text = \"ver:1.0.0.2 \";");
            ASStr.Add("				dispText.x = " + (_SwfWidth_ - 100).ToString() + ";");
            ASStr.Add("				dispText.y = " + (_SwfHeight_ - 20).ToString() + ";");
            ASStr.Add("				addChild(dispText);");
            ASStr.Add("\n");
            ASStr.Add("			}");
            ASStr.Add("	}");
            ASStr.Add("}");

            string _Dir = Path.GetDirectoryName(m_outSwfFilePath);
            string ASFilePath = _Dir + "\\" + ClassName + ".as";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@ASFilePath))
            {
                foreach (string line in ASStr)
                {
                    file.WriteLine(line);
                }
            }

            // 建立Pic as檔
            ASStr.Clear();
            for (i = 0; i < m_PngInfo.Count(); i++)
            {
                ASStr.Add("package");
                ASStr.Add("{");
                ASStr.Add("	import flash.display.BitmapData;");
                ASStr.Add("\n");
                _ns_ = "	[Embed(source=\"" +m_PngInfo[i].FileName + "\", mimeType=\"image/png\", compression=\"true\", quality=\"80\")]";
                ASStr.Add(_ns_);
                _ns_ = "	public class "+ClassName+"_BMP"+i.ToString()+" extends flash.display.BitmapData";
                ASStr.Add(_ns_);
                ASStr.Add("	{");
                _ns_ = "		public function " + ClassName + "_BMP" + i.ToString() + "(arg1:Number, arg2:Number) ";
                ASStr.Add(_ns_);
                ASStr.Add("		{");
                ASStr.Add("			super(arg1, arg2);");
                ASStr.Add("		}");
                ASStr.Add("	}");
                ASStr.Add("}");

                //string __FileName__ = Path.GetFileName(m_PngInfo[i].FileName);
                ASFilePath = _Dir + "\\" + ClassName + "_BMP" + i.ToString() + ".as";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@ASFilePath))
                {
                    foreach (string line in ASStr)
                    {
                        file.WriteLine(line);
                    }
                }
                ASStr.Clear();
            }
            string exedir = Directory.GetCurrentDirectory();
            string mxmlcPath = exedir + "\\flex_sdk_4.5.1.21328\\bin\\mxmlc.exe";
            string strParam = " -static-link-runtime-shared-libraries=true ";

            // 呼叫執行檔build swf
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(mxmlcPath,(strParam + _Dir + "\\" + ClassName + ".as"));
            System.Diagnostics.Process rfp = new System.Diagnostics.Process();
            rfp = System.Diagnostics.Process.Start(psi);

            rfp.WaitForExit(90000);

            if ((rfp.HasExited) && (m_bDeleteAS) )
            {
                //刪除主as
                File.Delete(_Dir + "\\" + ClassName + ".as");
                for (i = 0; i < m_PngInfo.Count(); i++)
                {
                    File.Delete(ASFilePath = _Dir + "\\" + ClassName + "_BMP" + i.ToString() + ".as");
                }
            }
            

        }

        public string m_outSwfFilePath;
        public List<ImgInfo> m_PngInfo;
        public bool m_bDeleteAS;
    }

}
