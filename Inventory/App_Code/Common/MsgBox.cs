using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Viftech;

/// <summary>
/// Summary description for MsgBox
/// </summary>
public class MsgBox
{
    public MsgBox()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public const int success = 1;
    //{
    //    get
    //    {
    //        return 1;
    //    }
    //}

public const int info = 2;
    //{
    //    get
    //    {
    //        return 2;
    //    }
    //}

public const int warning = 3;
    //{
    //    get
    //    {
    //        return 3;
    //    }
    //}

    public const int danger = 4;
    //{
    //    get
    //    {
    //        return 4;
    //    }
    //}

    public static void Show(Page page, string title, string Msg)
    {
        Show(page, MsgBox.info, title, Msg);
    }

    public static void Show(Page page, string Msg)
    {
         Show(page, MsgBox.danger, "Exception", Msg);
    }

    public static void Show(Page page, string Msg, Object obj)
    {
         Show(page, MsgBox.danger, "Exception", Msg);
    }

    public static void Show(Page page, int msgtype, string title, string Msg)
    {
      //  vt_Common.ReloadJS(page, "msgbox(" + msgtype + ",'" + title + "!','" + Msg + "');");
    }

    //public void MsgBox(String ex, Page pg, Object obj)
    //{
    //    string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
    //    Type cstype = obj.GetType();
    //    ClientScriptManager cs = pg.ClientScript;
    //    cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    //}

    /*
    MsgBox("! your message !", this.Page, this);
    */
}